using WebBlog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace WebBlog.Data.Mappings;

public class CategoryMap : IEntityTypeConfiguration<Category>
{
	public void Configure(EntityTypeBuilder<Category> builder)
	{
		builder.ToTable("Category");
		
		builder.HasKey(m => m.Id);

		builder.Property(m => m.Id)
			.ValueGeneratedOnAdd()
			.UseIdentityColumn();

		builder.Property(m => m.Name)
			.IsRequired()
			.HasColumnName("Name")
			.HasColumnType("NVARCHAR")
			.HasMaxLength(80);
		
		builder.Property(m => m.Slug)
			.IsRequired() 
			.HasColumnName("Slug") 
			.HasColumnType("VARCHAR") 
			.HasMaxLength(80);

		builder.HasIndex(x => x.Slug, "IX_Category_Slug")
			.IsUnique(); 
	}
}