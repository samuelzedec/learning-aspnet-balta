namespace Library.Models;
public class Book
{
	public required int Id { get; set; }
	public required string Title { get; set; }
	public required int PublicationYear { get; set; }
	public Author? Author { get; set; }
	public List<Gender> Gender { get; set; } = new List<Gender>();
}