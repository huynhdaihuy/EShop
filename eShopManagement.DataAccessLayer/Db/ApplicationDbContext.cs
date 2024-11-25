using eShopManagement.DataAccess.Entities;
using eShopManagement.DataAccessLayer.EntitiesConfiguration;
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
            var categoriesJsonPath = Path.Combine(Directory.GetCurrentDirectory(), "SeedData", "categories.json");

            // Seed Categories
            if (File.Exists(categoriesJsonPath))
            {
                var categoriesJson = File.ReadAllText(categoriesJsonPath);
                var categories = JsonConvert.DeserializeObject<List<Category>>(categoriesJson);
                if (categories != null && categories.Any())
                {
                    // Here, we're ensuring the data is seeded dynamically
                    foreach (var category in categories)
                    {
                        modelBuilder.Entity<Category>().HasData(category);
                    }
                }
            }

        }

    }
}
