using System.Runtime.InteropServices;
using Blog.Models;
using Microsoft.EntityFrameworkCore;
namespace Blog.Data;
public class BlogDataContext : DbContext 
{
	public DbSet<Category>? Categories { get; set; }
	public DbSet<Post>? Posts { get; set; }
	public DbSet<User>? Users { get; set; }
	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseSqlServer("Server=localhost,9090;Database=Blog;User ID=sa;Password=1q2w3e4r@#$;TrustServerCertificate=True");
		
		// optionsBuilder.LogTo(Console.WriteLine);
		/* -----------------------------------------------------------------------
		 * Isso fará com que seja exibido no console as consultas ao banco 
		 * que estão sendo exececutada, para achar você pode ir na parte de
		 * que tem o tópico 'info'
		 * ----------------------------------------------------------------------- */
	}
}