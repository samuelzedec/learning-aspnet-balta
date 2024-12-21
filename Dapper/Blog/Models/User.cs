using Dapper.Contrib.Extensions;
namespace Blog.Models;

/* --------------------------------------------------------------
 * Notações (ou Atributos) em C# são uma forma de adicionar metadados ao código, fornecendo 
 * informações adicionais que podem ser usadas por frameworks, bibliotecas ou até mesmo 
 * pelo próprio compilador, sem alterar a lógica do código.
 * -------------------------------------------------------------- */

[Table("[User]")]
public class User
{
	public User() 
		=> Roles = new List<Role>();
	
	public int Id { get; set; }
	public string? Name { get; set; }
	public string? Email { get; set; }
	public string? PasswordHash { get; set; }
	public string? Bio { get; set; }
	public string? Image { get; set; }
	public string? Slug { get; set; }
	
	[Write(false)] //Usamos isso para o Dapper.Contrib não escrever isso no insert, fazendo-o ignorar essa propriedades
	public List<Role> Roles { get; set; }
}
/* --------------------------------------------------------------
 * Por padrão, o Dapper.Contrib assume que o nome da tabela no banco de dados
 * é o nome da model no plural. Para evitar esse comportamento
 * ou especificar um nome de tabela diferente, usamos o atributo [Table("nome_da_tabela")]
 * para indicar o nome exato da tabela que será consultada.
 * -------------------------------------------------------------- */
