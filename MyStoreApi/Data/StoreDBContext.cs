using Microsoft.EntityFrameworkCore;
using MyStoreApi.Models;

namespace MyStoreApi.Data
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options)
        {
        }

        // DbSets represent our database tables
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerAddress> CustomerAddress { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure table names to match our database
            modelBuilder.Entity<Customer>().ToTable("customers");
            modelBuilder.Entity<CustomerAddress>().ToTable("customer_address");
            modelBuilder.Entity<Product>().ToTable("products");
            modelBuilder.Entity<Order>().ToTable("orders");
            modelBuilder.Entity<OrderItem>().ToTable("order_items");

            // Configure primary keys for tables that don't follow convention
            modelBuilder.Entity<CustomerAddress>()
                .HasKey(ca => ca.CustomerId);  // Single key, but not named "Id"

            modelBuilder.Entity<OrderItem>()
                .HasKey(oi => new { oi.OrderId, oi.ProductId });  // Composite key

            // Map C# property names to database column names
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.CustomerId).HasColumnName("customer_id");
                entity.Property(e => e.FullName).HasColumnName("full_name");
                entity.Property(e => e.Email).HasColumnName("email");
                entity.Property(e => e.Phone).HasColumnName("phone");
                entity.Property(e => e.Age).HasColumnName("age");
                entity.Property(e => e.RegisterDate).HasColumnName("register_date");
                entity.Property(e => e.LastOnlineDate).HasColumnName("last_online_date");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.ProductId).HasColumnName("product_id");
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.Price).HasColumnName("price");
                entity.Property(e => e.AmountInStock).HasColumnName("amount_in_stock");
            });
            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.OrderId).HasColumnName("order_id");
                entity.Property(e => e.CustomerId).HasColumnName("customer_id");
                entity.Property(e => e.OrderDate).HasColumnName("order_date");
                entity.Property(e => e.OrderTotal).HasColumnName("order_total");
            });

            modelBuilder.Entity<CustomerAddress>(entity =>
            {
                entity.Property(e => e.CustomerId).HasColumnName("customer_id");
                entity.Property(e => e.FullAddress).HasColumnName("full_address");
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.Property(e => e.OrderId).HasColumnName("order_id");
                entity.Property(e => e.ProductId).HasColumnName("product_id");
                entity.Property(e => e.UnitPrice).HasColumnName("unit_price");
            });
        }
    }
}