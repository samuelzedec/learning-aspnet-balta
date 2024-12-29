namespace Library.Models;
public class Gender
{
	public required int Id { get; set; }
	public required string Name { get; set; }
	public List<Book> Books { get; set; } = new List<Book>();
}