namespace Library.Models;
public class Author
{
	public int Id { get; set; }
	public string Name { get; set; } = string.Empty;
	public int Age { get; set; }
	public DateTime BirthDate { get; set; }
	public string Nationality { get; set; } = string.Empty;
	public string Biography { get; set; } = string.Empty;
	public List<Book> Books { get; set; } = new List<Book>();
}
