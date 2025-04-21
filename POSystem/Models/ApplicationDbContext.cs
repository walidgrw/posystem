using Microsoft.EntityFrameworkCore;
using POSystem.Models;

namespace POSystem.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }

        public DbSet<Payment> Payments { get; set; }

        // Override OnModelCreating to specify decimal precision
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Set precision for decimal properties to avoid truncation
            modelBuilder.Entity<MenuItem>()
                .Property(m => m.Price)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<Order>()
                .Property(o => o.Subtotal)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<Order>()
                .Property(o => o.Total)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<Order>()
                .Property(o => o.VAT)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<OrderItem>()
                .Property(oi => oi.Price)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<Payment>()
                .Property(p => p.Amount)
                .HasColumnType("decimal(18, 2)");
        }
    }
}
