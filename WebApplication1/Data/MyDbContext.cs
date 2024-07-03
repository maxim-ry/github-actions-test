using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
       
        public DbSet<Order> Orders { get; set; } // Added extra DbSet property for Order Model

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>()
                .HasMany(e => e.Orders)
                .WithOne(e => e.Product)
                .HasForeignKey(e => e.ProductId)
                .IsRequired();
                .HasPrincipalKey(e => e.Id);
            */
            modelBuilder.Entity<Product>()
                .HasKey(p => p.Id);
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Product1", Price = 10.00M, Description = "Description1" },
                new Product { Id = 2, Name = "Product2", Price = 20.00M, Description = "Description2" }
            );

        }
    }
}
