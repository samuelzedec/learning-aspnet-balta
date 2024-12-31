namespace Library.Models;
public class Client
{
	public int Id { get; set; }
	public string Name { get; set; } = string.Empty;
	public DateTime BirthDate { get; set; }
	public string Email { get; set; } = string.Empty;
	public string Phone { get; set; } = string.Empty;
	public Address Address { get; set; } = null!;
	public List<Book> Books { get; set; } = new List<Book>();
}