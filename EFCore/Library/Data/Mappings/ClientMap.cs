using Library.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Library.Data.Mappings;

public class ClientMap : IEntityTypeConfiguration<Client>
{
	public void Configure(EntityTypeBuilder<Client> builder)
	{
		builder.ToTable("Client");

		builder.HasKey(c => c.Id);
		builder
			.Property(c => c.Id)
			.HasColumnName("Id")
			.HasColumnType("INT")
			.ValueGeneratedOnAdd()
			.UseIdentityColumn();

		builder
			.Property(c => c.Name)
			.IsRequired()
			.HasColumnName("Name")
			.HasColumnType("NVARCHAR")
			.HasMaxLength(100);

		builder
			.Property(c => c.BirthDate)
			.IsRequired()
			.HasColumnName("BirthDate")
			.HasColumnType("DATE");

		builder
			.Property(c => c.Email)
			.IsRequired()
			.HasColumnName("Email")
			.HasColumnType("VARCHAR")
			.HasMaxLength(255);
		builder
			.HasIndex(c => c.Email, "IX_Client_Email")
			.IsUnique();
		
		builder
			.Property(c => c.Phone)
			.IsRequired()
			.HasColumnName("Phone")
			.HasColumnType("VARCHAR")
			.HasMaxLength(20);

		builder
			.HasOne(c => c.Address)
			.WithOne(ad => ad.Client)
			.HasForeignKey<Address>("ClientId")
			.HasConstraintName("FK_Address_ClientId")
			.IsRequired();
			
		/* ====================================================================
		 * Para não ocorrer erros ao usar o IsRequired() em Chaves Estrangeiras
		 * É bom usar ela sempre por último. 
		 * ==================================================================== */
	}
}