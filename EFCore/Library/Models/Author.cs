namespace Library.Models;
public class Author
{
	public required int Id { get; set; }
	public required string Name { get; set; }
	public required int Age { get; set; }
	public required DateTime BirthDate { get; set; }
	public required string Nationality { get; set; }
	public required string Biography { get; set; }
	
	public List<Book> Books { get; set; } = new List<Book>();
}
