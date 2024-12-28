using Blog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FluentMapping.Data.Mappings;
public class UserMap : IEntityTypeConfiguration<User>
{
	public void Configure(EntityTypeBuilder<User> builder)
	{
		builder.ToTable("User");

		builder.HasKey(u => u.Id);

		builder.Property(u => u.Id)
			.ValueGeneratedOnAdd()
			.UseIdentityColumn();

		builder
			.Property(u => u.Name)
			.IsRequired()
			.HasColumnName("Name")
			.HasColumnType("NVARCHAR")
			.HasMaxLength(80);

		builder.Property(u => u.Bio);
		builder.Property(u => u.Email);
		builder.Property(u => u.Image);
		builder.Property(u => u.PasswordHash);
		builder.Property(x => x.GitHub);
		
		builder
			.Property(u => u.Slug)
			.IsRequired()
			.HasColumnName("Slug")
			.HasColumnType("NVARCHAR")
			.HasMaxLength(80);

		builder
			.HasIndex(u => u.Slug, "IX_User_Slug")
			.IsUnique();

		builder
			.HasMany(u => u.Roles)
			.WithMany(r => r.Users)
			.UsingEntity<Dictionary<string, object>>(
				"UserRole",
				role => role.HasOne<Role>()
						.WithMany()
						.HasForeignKey("RoleId")
						.HasConstraintName("FK_UserRole_RoleId")
						.OnDelete(DeleteBehavior.Cascade),
						
				user => user.HasOne<User>()
						.WithMany()
						.HasForeignKey("UserId")
						.HasConstraintName("FK_UserRole_UserId")
						.OnDelete(DeleteBehavior.Cascade));
	}
}