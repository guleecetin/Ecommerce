using Ecommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infrastructure.Persistence
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Product>Products=>Set<Product>();
        public DbSet<WareHouse> WareHouses => Set<WareHouse>();
        public DbSet<Stock> Stocks => Set<Stock>();
        public DbSet<Cart> Carts => Set<Cart>();
        public DbSet<CartItem> CartItems => Set<CartItem>();
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<OrderItem> OrderItems => Set<OrderItem>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Stock>()
                .HasOne(s => s.Product)
                .WithMany(p => p.Stocks)
                .HasForeignKey(s => s.ProductId);

            modelBuilder.Entity<Stock>()
               .HasOne(s => s.Warehouse)
               .WithMany(p => p.Stocks)
               .HasForeignKey(s => s.WareHouseId);

            modelBuilder.Entity<Cart>()
               .HasMany(c => c.Items)
               .WithOne()
               .HasForeignKey(s => s.CartId);

            modelBuilder.Entity<Order>()
               .HasMany(s => s.Items)
               .WithOne()
               .HasForeignKey(s => s.OrderId);

            base.OnModelCreating(modelBuilder);
        }


    }
}
