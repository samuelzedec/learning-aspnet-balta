using WebBlog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebBlog.Data.Mappings;
public class PostMap : IEntityTypeConfiguration<Post>
{
	public void Configure(EntityTypeBuilder<Post> builder)
	{
		builder.ToTable("Post");

		builder.HasKey(p => p.Id);

		builder
			.Property(p => p.Id)
			.ValueGeneratedOnAdd()
			.UseIdentityColumn();

		builder
			.Property(p => p.LastUpdateDate)
			.IsRequired()
			.HasColumnName("LastUpdateDate")
			.HasColumnType("SMALLDATETIME")
			.HasDefaultValue(DateTime.Now.ToUniversalTime());
			 

		builder.
			HasIndex(p => p.Slug, "IX_Post_Slug")
			.IsUnique();

		builder
			.HasOne(p => p.Author)
			.WithMany(a => a.Posts) 
			.HasConstraintName("FK_Post_Author")
			.OnDelete(DeleteBehavior.Cascade); 

		builder
			.HasMany(p => p.Tags)
			.WithMany(t => t.Posts)
			.UsingEntity<Dictionary<string, object>>(
				"PostTag",
				post => post.HasOne<Tag>()
						.WithMany()
						.HasForeignKey("PostId")
						.HasConstraintName("FK_PostTag_PostId")
						.OnDelete(DeleteBehavior.Cascade),
						
				tag => tag.HasOne<Post>()
						.WithMany()
						.HasForeignKey("TagId")
						.HasConstraintName("FK_PostTag_TagId")  
						.OnDelete(DeleteBehavior.Cascade)
			);
	}
}