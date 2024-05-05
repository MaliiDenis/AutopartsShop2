using System.Data.Entity;
using Motora.Domain.Models;

namespace Motora.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("SqlServer")
        {
        }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductFeature> ProductFeatures { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<WarehouseStock> WarehouseStocks { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
    }
}