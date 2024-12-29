using Library.Models;
using Microsoft.EntityFrameworkCore;
namespace Library.Data;

public class LibraryDataContext : DbContext
{
	public DbSet<Author>? Authors { get; set; }
	public DbSet<Book>? Books { get; set; }
	public DbSet<Client>? Clients { get; set; }
	public DbSet<Gender>? Genders { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseSqlServer("Server=localhost,9090;Database=Library;User ID=sa;Password=1q2w3e4r@#$;TrustServerCertificate=True");
	}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
		modelBuilder.Entity<Author>();
    }
	
}