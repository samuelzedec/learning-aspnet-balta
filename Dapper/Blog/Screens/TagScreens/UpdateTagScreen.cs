using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.TagScreens;
public static class UpdateTagScreen
{
	public static void Load() 
	{
		Console.Clear();
		Console.WriteLine("Atulizando uma Tag");
		Console.WriteLine("-----------------");
		
		Console.Write("ID: ");
        int.TryParse(Console.ReadLine(), out int id);
		Console.Write("Name: ");
		var name = Console.ReadLine();
		Console.Write("Slug: ");
		var slug = Console.ReadLine();
		
		Update(new() { 
			Id = id,
			Name = name, 
			Slug = slug 
		});
		Console.ReadKey();
		MenuTagScreen.Load();
	}
	
	public static void Update(Tag tag) 
	{
		
		try 
		{
			var repository = new Repository<Tag>();
			repository.Update(tag);
			Console.Clear();
			Console.WriteLine("\u001b[32mTag atualizada com sucesso!!!\u001b[0m");
		} 
		catch (Exception ex)
		{
			Console.WriteLine("Não foi possível atualizar a tag!");
			Console.WriteLine($"Error: {ex.Message}");
			Console.WriteLine($"Help Link: {ex.HelpLink}");
		}
	}
}