using EFCore.Models;
using Microsoft.EntityFrameworkCore;
namespace EFCore.Data;

/* ----------------------------------------------------------
 * DbContext é a classe que cria a representação das tabelas 
 * na memória e gerencia a conexão com o banco de dados.
 * Ela também gerencia as operações de consulta, inserção, 
 * atualização e exclusão de dados.
 * ---------------------------------------------------------- */
public class BlogDataContext : DbContext 
{
	/* ----------------------------------------------------------
	 * DbSet<T> mapeia a tabela no banco de dados para uma coleção 
	 * de objetos da classe T, permitindo manipular os dados 
	 * da tabela de forma orientada a objetos. 
	 * ---------------------------------------------------------- */
	public DbSet<Category>? Categories { get; set; }
	public DbSet<Post>? Posts { get; set; }
	// public DbSet<PostTag>? PostTags { get; set; }
	public DbSet<Role>? Roles { get; set; }
	public DbSet<Tag>? Tags { get; set; }
	public DbSet<User>? Users { get; set; }
	// public DbSet<UserRole>? UserRoles { get; set; }
	
	/* ----------------------------------------------------------
	 * Ao criar a propriedade com DbSet<T> para uma tebela
	 * automaticamente ela pode ser manipulada para fazer 
	 * operações de consulta, inserção, atualização e exclusão de dados.
	 * ---------------------------------------------------------- */
	 
	 
	/* ----------------------------------------------------------
	 * O método OnConfiguring() é um método da Classe DbContext
	 * que serve para fazermos a conexão com o banco de dados.
	 * Não é preciso ser chamado manualmente porque ao criar uma instância 
	 * da classe DbContext ele automaticamente chama esse método.
	 * ---------------------------------------------------------- */
	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		=> optionsBuilder.UseSqlServer (
			"Server=localhost,9090;Database=Blog;User ID=sa;Password=1q2w3e4r@#$;TrustServerCertificate=True");
			
		/* ----------------------------------------------------------
		 * Aqui, o optionsBuilder está sendo usado para configurar a 
		 * conexão com o SQL Server por meio do método UseSqlServer. 
		 * Esse método recebe a string de conexão e configura o DbContext 
		 * para usar o SQL Server como o provedor de banco de dados. 
		 * ---------------------------------------------------------- */
	 
}