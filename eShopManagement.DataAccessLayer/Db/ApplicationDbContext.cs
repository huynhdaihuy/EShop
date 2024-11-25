using DataAccessLayer.EntitiesConfiguration;
using eShopManagement.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace eShopManagement.DataAccessLayer.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            SeedData(modelBuilder);
            base.OnModelCreating(modelBuilder);

        }
        private static void SeedData(ModelBuilder modelBuilder)
        {
            var productsJsonPath = Path.Combine(Directory.GetCurrentDirectory(), "SeedData", "products.json");

            // Seed Products
            if (File.Exists(productsJsonPath))
            {
                var productsJson = File.ReadAllText(productsJsonPath);
                var products = JsonConvert.DeserializeObject<List<Product>>(productsJson);
                if (products != null && products.Any())
                {
                    modelBuilder.Entity<Product>().HasData(products);
                }
            }
        }

    }
}
