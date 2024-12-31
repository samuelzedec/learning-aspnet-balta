using Library.Data.Mappings;
using Library.Models;
using Microsoft.EntityFrameworkCore;
namespace Library.Data;

public class LibraryDataContext : DbContext
{
	/* =============================================================================
	 * O operador (null!) indica ao compilador que você sabe que essas propriedades 
	 * serão inicializadas em tempo de execução, mesmo que você não as esteja 
	 * inicializando no momento da declaração.  
	 * ============================================================================= */
	public DbSet<Author> Authors { get; set; } = null!;
	public DbSet<Book> Books { get; set; } = null!;
	public DbSet<Client> Clients { get; set; } = null!;
	public DbSet<Gender> Genders { get; set; } = null!;
	public DbSet<Address> Addresses { get; set; } = null!;

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseSqlServer("Server=localhost,9090;Database=Library;User ID=sa;Password=1q2w3e4r@#$;TrustServerCertificate=True");
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfiguration(new AuthorMap());
		modelBuilder.ApplyConfiguration(new AddressMap());
		modelBuilder.ApplyConfiguration(new BookMap());
		modelBuilder.ApplyConfiguration(new ClientMap());
		modelBuilder.ApplyConfiguration(new GenderMap());
	}
	
}