using Blog.Models;
using Microsoft.EntityFrameworkCore;
namespace Blog.Data;
public class BlogDataContext : DbContext 
{
	public DbSet<Category>? Categories { get; set; }
	public DbSet<Post>? Posts { get; set; }
	public DbSet<User>? Users { get; set; }
	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		=> optionsBuilder.UseSqlServer ("Server=localhost,9090;Database=Blog;User ID=sa;Password=1q2w3e4r@#$;TrustServerCertificate=True");
	 
}