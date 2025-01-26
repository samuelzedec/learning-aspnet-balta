using WebBlog.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using WebBlog.Models;
namespace WebBlog.Data;

public class BlogDataContext : DbContext
{
	public DbSet<Category> Categories { get; set; } = null!;
	public DbSet<Post> Posts { get; set; } = null!;
	public DbSet<User> Users { get; set; } = null!;


	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseSqlServer("Server=localhost,1433;Database=blog-modulo-6;User ID=sa;Password=1q2w3e4r@#$;TrustServerCertificate=True");
	}
	
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfiguration(new CategoryMap());
		modelBuilder.ApplyConfiguration(new PostMap());
		modelBuilder.ApplyConfiguration(new UserMap());
	}

}