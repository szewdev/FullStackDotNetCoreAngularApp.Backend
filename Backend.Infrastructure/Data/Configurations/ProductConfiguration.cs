using Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Infrastructure.Data.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        BaseEntityConfiguration.ConfigureBaseEntity(builder);

        builder.Property(b => b.Name).IsRequired().HasMaxLength(75);
        builder.Property(b => b.Price).IsRequired().HasColumnType("decimal").HasPrecision(18, 2);
        builder.Property(b => b.Description).HasMaxLength(255);
    }
}
