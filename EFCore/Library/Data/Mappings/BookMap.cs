using Library.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Data.Mappings;
public class BookMap : IEntityTypeConfiguration<Book>
{
	public void Configure(EntityTypeBuilder<Book> builder)
	{
		builder.ToTable("Book");
		
		builder.HasKey(b => b.Id);
		builder
			.Property(b => b.Id)
			.HasColumnName("Id")
			.HasColumnType("INT")
			.ValueGeneratedOnAdd()
			.UseIdentityColumn();

		builder
			.Property(b => b.Title)
			.IsRequired()
			.HasColumnName("Title")
			.HasColumnType("NVARCHAR")
			.HasMaxLength(100);
		builder
			.HasIndex(b => b.Title, "IX_Book_Title")
			.IsUnique();

		builder
			.Property(b => b.PublicationYear)
			.IsRequired()
			.HasColumnName("PublicationYear")
			.HasColumnType("SMALLINT")
			.HasDefaultValue(DateTime.Now.Year);

		builder
			.HasMany(b => b.Genders)
			.WithMany(b => b.Books)
			.UsingEntity<Dictionary<string, object>>(
				"GenderBook",
				gender => gender
						.HasOne<Gender>()
						.WithMany()
						.HasForeignKey("GenderId")
						.HasConstraintName("FK_GenderBook_GenderId")
						.OnDelete(DeleteBehavior.Cascade),
				
				book => book
						.HasOne<Book>()
						.WithMany()
						.HasForeignKey("BookId")
						.HasConstraintName("FK_GenderBook_BookId")
						.OnDelete(DeleteBehavior.Cascade)
			);

		builder
			.HasMany(b => b.Clients)
			.WithMany(c => c.Books)
			.UsingEntity<Dictionary<string, object>>(
				"ClientBook",
				client => client
						.HasOne<Client>()
						.WithMany()
						.HasForeignKey("ClientId")
						.HasConstraintName("FK_ClientBook_ClientId")
						.OnDelete(DeleteBehavior.Cascade),
				book => book
						.HasOne<Book>()
						.WithMany()
						.HasForeignKey("BookId")
						.HasConstraintName("FK_ClientBook_BookId")
						.OnDelete(DeleteBehavior.Cascade)
			);
	}
}