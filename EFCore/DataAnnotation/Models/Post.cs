using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Blog.Models;

[Table("Post")]
public class Post
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public int Id { get; set; }
	public string? Title { get; set; }
	public string? Summary { get; set; }
	public string? Body { get; set; }
	public string? Slug { get; set; }
	public DateTime CreateDate { get; set; }
	public DateTime LastUpdateDate { get; set; }
	
	[ForeignKey("CategoryId")]
	public int CategoryId { get; set; }
	public Category? Category { get; set; }
	/* ----------------------------------------------------------------
	 * Por padrão, o EF Core irá pegar o nome que especificamos e irá
	 * dividir em partes para se localizar. 
	 * Exemplo: (CategoryId) = classe 'Category' | propridade 'Id'.
	 *
	 * Category é a classe de navegação: Representa a relação com 
	 * outra entidade chamada Category. Essa é uma navigation property, 
	 * usada para acessar os dados da relação.
	 * Para isso ocorrer é necessário que a classe de navegção tenha o
	 * mesmo nome da ForeignKey, porém sem a parte da propriedade.
	 * ---------------------------------------------------------------- */
	
	[ForeignKey("AuthorId")]
	public int AuthorId { get; set; }
	public User? Author { get; set; }
}
