using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RepositoryStore.Models;

namespace RepositoryStore.Data.Mappings;

public class ProductMap : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Product");

        builder
            .HasKey(x => x.Id)
            .HasName("PK_Product_Id");

        builder
            .Property(x => x.Id)
            .HasColumnName("Id")
            .HasColumnType("INT")
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        builder
            .Property(x => x.Title)
            .HasColumnName("Title")
            .HasMaxLength(255)
            .HasColumnType("NVARCHAR")
            .IsRequired();
    }
}