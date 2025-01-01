using Library.Data;
using Library.Models;
using Library.Repository;

Console.WriteLine("Hello, World!");
var context = new LibraryDataContext();


var book1 = new Book
{
	Title = "Livro Testing 1",
	PublicationYear = 2022
};

var book2 = new Book
{
	Title = "Livro Testing 2",
	PublicationYear = 2021
};
var list = new List<Book>
{
	book1, book2
};

var author = new Author
{
	Name = "Author Testing",
	Age = 49,
	BirthDate = new DateTime(1984, 10, 20),
	Nationality = "Brasileiro",
	Biography = "Author testadno a bio aqui!",
	Books = list
};
var repository = new AuthorRepository(context) 
{
	Author = author	
};
var result = await repository.Create();
Console.WriteLine($"Tudo certo! {result}");