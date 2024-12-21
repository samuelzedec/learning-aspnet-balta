using Blog.Screens.TagScreens;
using Microsoft.Data.SqlClient;
namespace Blog;

internal class Program
{
	private static readonly string CONNECTION_STRING =
		@"Server=localhost,9090;Database=Blog;User ID=sa;Password=1q2w3e4r@#$;TrustServerCertificate=True";
	private static void Main(string[] args)
	{
		using (Database.Connection = new SqlConnection(CONNECTION_STRING))
		{
			Database.Connection.Open();
			Load();
			Console.ReadKey();
		}
		Console.ReadKey();
	}
	
	private static void Load()
		{
			Console.Clear();
			Console.WriteLine("Meu Blog");
			Console.WriteLine("-----------------");
			Console.WriteLine("O que deseja fazer?");
			Console.WriteLine();
			Console.WriteLine("1 - Gestão de usuário");
			Console.WriteLine("2 - Gestão de perfil");
			Console.WriteLine("3 - Gestão de categoria");
			Console.WriteLine("4 - Gestão de tag");
			Console.WriteLine("5 - Vincular perfil/usuário");
			Console.WriteLine("6 - Vincular post/tag");
			Console.WriteLine("7 - Relatórios\n");
			Console.Write("\u001b[32m> \u001b[0m");
			var option = short.Parse(Console.ReadLine()!);

			switch (option)
			{
				case 4:
					MenuTagScreen.Load();
					break;
				default: Load(); break;
			}
		}
}
