using WebBlog.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using WebBlog.Models;
namespace WebBlog.Data;

public class BlogDataContext : DbContext
{
	// DbContextOptions irá fazer com que recebamos opções de configurações
	public BlogDataContext(DbContextOptions<BlogDataContext> options) 
		: base(options) { }
	
	public DbSet<Category> Categories { get; set; } = null!;
	public DbSet<Post> Posts { get; set; } = null!;
	public DbSet<User> Users { get; set; } = null!;
	
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfiguration(new CategoryMap());
		modelBuilder.ApplyConfiguration(new PostMap());
		modelBuilder.ApplyConfiguration(new UserMap());
	}
}