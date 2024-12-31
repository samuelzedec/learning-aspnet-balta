using Library.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Library.Data.Mappings;

public class GenderMap : IEntityTypeConfiguration<Gender>
{
	public void Configure(EntityTypeBuilder<Gender> builder)
	{
		builder.ToTable("Gender");

		builder.HasKey(g => g.Id);
		builder
			.Property(g => g.Id)
			.HasColumnName("Id")
			.HasColumnType("INT")
			.ValueGeneratedOnAdd()
			.UseIdentityColumn();

		builder
			.Property(g => g.Name)
			.IsRequired()
			.HasColumnName("Name")
			.HasColumnType("VARCHAR")
			.HasMaxLength(100);
		builder
			.HasIndex(g => g.Name, "IX_Gender_Name")
			.IsUnique();
	}
}
