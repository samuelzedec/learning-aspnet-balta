using Blog.Data;
using Blog.Models;

using var context = new BlogDataContext();
var user = new User
{
	Name = "José Gabriel",
	Slug = "josegabriel",
	Email = "josegabriel@emai.com",
	Bio = "MVP",
	Image = "https://josegabriel.io",
	PasswordHash = "123456789"
};

var category = new Category
{
	Name = "Front-end",
	Slug = "frontend"
};

var post = new Post
{
	Author = user,
	Category = category,
	Body = "<p>Hello, World!</p>",
	Slug = "comecadno-com-ts",
	Summary = "Neste artigo vamos aprender TypeScript",
	Title = "Começando com TypeScript",
	CreateDate = DateTime.Now,
	LastUpdateDate = DateTime.Now
};

context.Posts?.Add(post);
/* ----------------------------------------------------------------
 * Ao adicionar apenas o objeto post, o próprio EF Core, faz a inserção
 * dos objetos user e category em duas devidas tabelas, porque o post 
 * depende delas. Tudo isso ele irá fazer em memória e somente irá 
 * adicionar quando chamarmos o o método SaveChanges();
 * ---------------------------------------------------------------- */
context.SaveChanges();