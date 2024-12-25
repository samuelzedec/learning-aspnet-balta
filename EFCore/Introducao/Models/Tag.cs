using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.Models;

//Diferente do Dapper, caso use o nome na notação da Table com [], irá ser lançado uma exceção
[Table("Tag")]
public class Tag
{
	[Key]
	public int Id { get; set; }
	public string? Name { get; set; }
	public string? Slug { get; set; }
}
