using eShopManagement.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.EntitiesConfiguration
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id)
                   .ValueGeneratedOnAdd();
            builder.Property(x => x.Name).HasMaxLength(40);
            builder.Property(x => x.Description).HasMaxLength(100);
            builder.HasOne(p => p.Category);
            builder.Property(p => p.Price).HasColumnType("decimal(18,2)");
            builder.HasOne(p => p.Category)
               .WithMany() 
               .HasForeignKey(p => p.CategoryId);
        }
    }
}
