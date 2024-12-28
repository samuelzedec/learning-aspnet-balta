using Blog.Data;
using Blog.Models;

using var context = new BlogDataContext();
// context.Users?.Add(new User() 
// {
// 	Bio = "Testing Fluent Mapping",
// 	Email = "testing@email.com",
// 	Image = "https://testing.io",
// 	Name = "Testing 3",
// 	PasswordHash = "1234",
// 	Slug = "testing-fluent-api"
// });

// var user = context.Users
// 	?.FirstOrDefault(u => u.Id == 1004);

// var category = context.Categories
// 	?.FirstOrDefault(c => c.Id == 2);

// var post = new Post
// {
// 	Author = user,
// 	Body = "Meu artigo testing",
// 	Category = category,
// 	CreateDate = DateTime.Now,
// 	Slug = "meu-artigo",
// 	Summary = "Neste artigo vamos conferir...",
// 	Title = "Meu Artigo"
// };
var listTags = new List<Tag>
{
	new Tag() { Name = "C#", Slug = "csharp"},
	new Tag() { Name = ".Net", Slug = "dotnet"}
};
var post = context.Posts?.FirstOrDefault(p => p.Id == 1);
post.Tags = new List<Tag>(listTags);

context.Update(post);
context.SaveChanges();
Console.WriteLine("End...");