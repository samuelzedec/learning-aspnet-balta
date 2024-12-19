using Blog.Models;
using Blog.Repositories;
namespace Blog.Screens.TagScreens;

public static class CreateTagScreen
{
	public static void Load() 
	{
		Console.Clear();
		Console.WriteLine("Criando uma Tag");
		Console.WriteLine("-----------------");
		
		Console.Write("Name: ");
		var name = Console.ReadLine();
		Console.Write("Slug: ");
		var slug = Console.ReadLine();
		
		Create(new() { 
			Name = name, 
			Slug = slug 
		});
		Console.ReadKey();
		MenuTagScreen.Load();
	}
	
	public static void Create(Tag tag) 
	{
		
		try 
		{
			var repository = new Repository<Tag>();
			repository.Create(tag);
			Console.Clear();
			Console.WriteLine("\u001b[32mTag criada com sucesso!!!\u001b[0m");
		} 
		catch (Exception ex)
		{
			Console.WriteLine("Não foi possível salvar a tag!");
			Console.WriteLine($"Error: {ex.Message}");
			Console.WriteLine($"Help Link: {ex.HelpLink}");
		}
	}
}