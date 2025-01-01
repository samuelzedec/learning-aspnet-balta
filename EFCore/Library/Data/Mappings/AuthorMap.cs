using Library.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Library.Data.Mappings;

public class AuthorMap : IEntityTypeConfiguration<Author>
{
	public void Configure(EntityTypeBuilder<Author> builder)
	{
		// Setting the table name
		builder.ToTable("Author");
		
		// Setting the Author ID
		builder.HasKey(a => a.Id);
		builder
			.Property(a => a.Id)
			.HasColumnName("Id")
			.HasColumnType("INT")
			.ValueGeneratedOnAdd()
			.UseIdentityColumn();

		// Setting the Author Name
		builder
			.Property(a => a.Name)
			.IsRequired()
			.HasColumnName("Name")
			.HasColumnType("NVARCHAR")
			.HasMaxLength(100);
		builder // Setting the Index for Author Name
			.HasIndex(a => a.Name, "IX_Author_Name")
			.IsUnique();
			
		// Setting the Author Age
		builder
			.Property(a => a.Age)
			.IsRequired()
			.HasColumnName("Age")
			.HasColumnType("TINYINT");
			
		// Setting the Author BirthDate
		builder
			.Property(a => a.BirthDate)
			.IsRequired()
			.HasColumnName("BirthDate")
			.HasColumnType("DATE");

		// Setting the Author Nationality
		builder
			.Property(a => a.Nationality)
			.IsRequired()
			.HasColumnName("Nationality")
			.HasColumnType("VARCHAR")
			.HasMaxLength(100);
			
		// Setting the Author Biography
		builder
			.Property(a => a.Biography)
			.HasColumnName("Biography")
			.HasColumnType("NVARCHAR(MAX)")
			.HasDefaultValue("## Não há registro informado sobre sua biografia ##");

		// Setting the relationship between Author and Book
		builder
			.HasMany(a => a.Books)
			.WithOne(b => b.Author)
			.HasForeignKey("AuthorId")
			.HasConstraintName("FK_Book_AuthorId")
			.OnDelete(DeleteBehavior.Cascade)
			.IsRequired();
	}
}
