namespace Library.Models;
public class Client
{
	public required int Id { get; set; }
	public required string Name { get; set; }
	public required DateTime BirthDate { get; set; }
	public required string Email { get; set; }
	public required string Phone { get; set; }
	public Book? Book { get; set; }
}