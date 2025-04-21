using POSystem.Models;
using POSystem.Middleware; 
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// ? Add session support
builder.Services.AddSession();

// ? Register your ApplicationDbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=POSystemDB;Trusted_Connection=True;"));

builder.Services.AddControllersWithViews();

var app = builder.Build();

// ? Seed database
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    DataSeeder.Seed(services);
}

// ? Configure middleware pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// ? Enable session and restrict access unless logged in
app.UseSession();
app.UseMiddleware<LoginRequiredMiddleware>(); // ?? This is the custom protection

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
