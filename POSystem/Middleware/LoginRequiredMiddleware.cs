using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace POSystem.Middleware
{
    public class LoginRequiredMiddleware
    {
        private readonly RequestDelegate _next;

        public LoginRequiredMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var path = context.Request.Path.ToString().ToLower();

            // ✅ Allow login, static files, and feedback page for customers
            if (
                path.StartsWith("/login") ||
                path.StartsWith("/feedback/create") ||
                path.StartsWith("/css") ||
                path.StartsWith("/js") ||
                path.StartsWith("/lib") ||
                path.StartsWith("/favicon") ||
                path.Contains(".")
            )
            {
                await _next(context);
                return;
            }

            // ✅ Check if logged in
            var role = context.Session.GetString("UserRole");
            if (string.IsNullOrEmpty(role))
            {
                context.Response.Redirect("/Login");
                return;
            }

            await _next(context);
        }
    }
}
