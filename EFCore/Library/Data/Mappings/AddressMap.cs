using Library.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Data.Mappings;
public class AddressMap : IEntityTypeConfiguration<Address>
{
	public void Configure(EntityTypeBuilder<Address> builder)
	{
		builder.ToTable("Address");

		builder.HasKey(a => a.Id);
		builder
			.Property(a => a.Id)
			.HasColumnName("Id")
			.HasColumnType("INT")
			.ValueGeneratedOnAdd()
			.UseIdentityColumn();

		builder
			.Property(a => a.Road)
			.IsRequired()
			.HasColumnName("Road")
			.HasColumnType("NVARCHAR")
			.HasMaxLength(120);

		builder
			.Property(a => a.Number)
			.IsRequired()
			.HasColumnName("Number")
			.HasColumnType("INT");
		
		builder
			.Property(a => a.Neighborhood)
			.IsRequired()
			.HasColumnName("Neighborhood")
			.HasColumnType("NVARCHAR")
			.HasMaxLength(120);
		
		builder
			.Property(a => a.City)
			.IsRequired()
			.HasColumnName("City")
			.HasColumnType("NVARCHAR")
			.HasMaxLength(120);
		
		builder
			.Property(a => a.State)
			.IsRequired()
			.HasColumnName("State")
			.HasColumnType("NVARCHAR")
			.HasMaxLength(120);
		
		builder
			.Property(a => a.ZipCode)
			.IsRequired()
			.HasColumnName("ZipCode")
			.HasColumnType("NVARCHAR")			
			.HasMaxLength(20);
		
	}
}