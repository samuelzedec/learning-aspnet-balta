using Library.Data;
using Library.Models;
using Library.Repository;

Console.WriteLine("Hello, World!");
var context = new LibraryDataContext();


var client = new Client
{
	Name = "José Gabriel",
	BirthDate = new DateTime(2006, 10, 26),
	Email = "jose@email.com",
	Phone = "(68) 98686-9191",
};

var address = new Address
{
	Road = "Esquina Longe",
	Number = 75,
	Neighborhood = "Logo Ali Perto Testing",
	City = "Manacapuru",
	State = "Amazonas",
	ZipCode = "61093-056",
};

var repository = new ClientRepository 
{
	Context = context,
	Client = client,
	Address = address
};

var result = await repository.Create();
Console.WriteLine($"Tudo certo! {result}");