using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Blog.Models;

[Table("Category")]
public class Category
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	/* ----------------------------------------------------------------
	 * O DatabaseGenerated() serve para dizer ao EF Core que o Id será
	 * gerado no banco. Já o DatabaseGeneratedOption.Identity que dizer
	 * que o que irá gerar esse Id será a função IDENTITY do SqlServer
	 * ---------------------------------------------------------------- */
	public int Id { get; set; }
	
	[Required] //NOT NULl - SQL Server
	[MinLength(3)] // Mínimo de caracter suportado 
	[MaxLength(80)] //Máximo de caracter suportado
	[Column("Name", TypeName = "NVARCHAR")] //Especificando o tipo da coluna
	public string? Name { get; set; }
	
		
	[Required]
	[MinLength(3)] 
	[MaxLength(80)]
	[Column("Slug", TypeName = "VARCHAR")]
	public string? Slug { get; set; }
}
