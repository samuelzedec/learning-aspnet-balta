namespace Library.Models;
public class Address
{
	public int Id { get; set; }
	public  string Road { get; set; } = string.Empty;
	public  short Number { get; set; } 
	public  string Neighborhood { get; set; } = string.Empty;
	public  string City { get; set; } = string.Empty;
	public  string State { get; set; } = string.Empty;
	public  string ZipCode { get; set; } = string.Empty;
	public Client Client { get; set; } = null!;
}