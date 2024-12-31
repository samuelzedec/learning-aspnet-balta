namespace Library.Models;
public class Book
{
	public int Id { get; set; }
	public string Title { get; set; } = string.Empty;
	public int PublicationYear { get; set; }
	public Author Author { get; set; } = new Author();
	public List<Client> Clients { get; set; } = new List<Client>(); 
	public List<Gender> Genders { get; set; } = new List<Gender>();
}