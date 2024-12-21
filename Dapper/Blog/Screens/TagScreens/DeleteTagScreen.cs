using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.TagScreens;
public class DeleteTagScreen
{
		public static void Load() 
	{
		Console.Clear();
		Console.WriteLine("Atulizando uma Tag");
		Console.WriteLine("-----------------");
		
		Console.Write("ID: ");
        int.TryParse(Console.ReadLine(), out int id);

		Delete(id);
		Console.ReadKey();
		MenuTagScreen.Load();
	}
	
	public static void Delete(int id) 
	{
		try 
		{
			var repository = new Repository<Tag>();
			repository.Delete(id);
			Console.Clear();
			Console.WriteLine("\u001b[32mTag excluída com sucesso!!!\u001b[0m");
		} 
		catch (Exception ex)
		{
			Console.WriteLine("Não foi possível excluir a tag!");
			Console.WriteLine($"Error: {ex.Message}");
			Console.WriteLine($"Help Link: {ex.HelpLink}");
		}
	}
}