using Dima.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Dima.Api.Data.Mappings;

public class CategoryMapping : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Category");

        builder
            .HasKey(x => x.Id)
            .HasName("PK_Category_Id");

        builder
            .Property(x => x.Id)
            .HasColumnName("Id")
            .HasColumnType("BIGINT")
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        builder
            .Property(x => x.Title)
            .HasColumnName("Title")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(80)
            .IsRequired();

        builder
            .Property(x => x.Description)
            .HasColumnName("Description")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(255)
            .IsRequired(false);

        builder
            .Property(x => x.UserId)
            .HasColumnName("UserId")
            .HasColumnType("VARCHAR")
            .HasMaxLength(160)
            .IsRequired();
    }
}