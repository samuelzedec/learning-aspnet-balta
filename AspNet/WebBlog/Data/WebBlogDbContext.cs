using WebBlog.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using WebBlog.Models;
namespace WebBlog.Data;

public class BlogDataContext : DbContext
{
	public DbSet<Category>? Categories { get; set; }
	public DbSet<Post>? Posts { get; set; }
	public DbSet<User>? Users { get; set; }


	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseSqlServer("Server=localhost,9090;Database=WebBlog;User ID=sa;Password=1q2w3e4r@#$;TrustServerCertificate=True");
	}
	
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfiguration(new CategoryMap());
		modelBuilder.ApplyConfiguration(new PostMap());
		modelBuilder.ApplyConfiguration(new UserMap());
	}

}