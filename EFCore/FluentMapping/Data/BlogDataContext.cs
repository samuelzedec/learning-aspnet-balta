using Blog.Models;
using FluentMapping.Data.Mappings;
using Microsoft.EntityFrameworkCore;
namespace Blog.Data;
public class BlogDataContext : DbContext 
{
	public DbSet<Category>? Categories { get; set; }
	public DbSet<Post>? Posts { get; set; }
	public DbSet<User>? Users { get; set; }
	
	
	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		=> optionsBuilder.UseSqlServer("Server=localhost,9090;Database=Blog;User ID=sa;Password=1q2w3e4r@#$;TrustServerCertificate=True");

	/* ===========================================================================
	 * O método OnModelCreating no DbContext do Entity Framework Core é utilizado para configurar o modelo de 
	 * dados antes de ele ser utilizado para gerar o banco de dados ou realizar operações. Ele é chamado 
	 * automaticamente pelo EF Core durante o processo de inicialização do contexto e permite que você defina 
	 * ou customize como suas entidades se comportam no banco de dados.  
	 * =========================================================================== */
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfiguration(new CategoryMap());
		modelBuilder.ApplyConfiguration(new PostMap());
		modelBuilder.ApplyConfiguration(new UserMap());
		/* ===========================================================================
		 * modelBuilder.ApplyConfiguration(...): Este método é utilizado para aplicar 
		 * configurações de mapeamento específicas para as entidades. 
		 * =========================================================================== */
	}
}