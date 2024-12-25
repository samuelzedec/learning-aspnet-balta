using Bank.Models;
using Bank.Screens.AccountScreen;
using Bank.Screens.ActionsScreen;
namespace Bank.Screens.AccessScreen;
public static class MenuAccessScreen
{
	public static User? User { get; set; }
	private static string FilterFirstName(string? fullName) 
	{
		var delimiter = ' ';
		return new string(fullName?.TakeWhile(c => c != delimiter).ToArray());
		/* -----------------------------------------------------------------
		 * Ao usar o new string() ele recebe um array de char e transformar 
		 * em uma string!
		 * ----------------------------------------------------------------- */
	}

	public static void Load() 
	{
		Console.Clear();
		var firstName = FilterFirstName(User?.FullName);
		Console.WriteLine($"Bem vindo {firstName}!");
		Console.WriteLine("Digite o número da opção desejada: ");
		Console.WriteLine("[1] - Ver minhas informações");
		Console.WriteLine("[2] - Acessar conta corrente");
		Console.WriteLine("[3] - Acessar conta poupança");
		Console.WriteLine("[4] - Acessar conta corrente");
		Console.WriteLine("[5] - Sair da conta\n");
		Console.Write("\u001b[32m> \u001b[0m");
		
		if(!byte.TryParse(Console.ReadLine(), out byte choice)) 
		{
			Console.Clear();
			Console.WriteLine("\u001b[31mInforme um valor correto!\u001b[0m");
			Console.ReadKey();
			Load();
		}

		Targeting(choice);

	}
	
	private static void Targeting(byte choice) 
	{
		switch(choice) 
		{
			case 1:
				UserScreen.Read(User);
				break;
			case 2:
				CurrentAccountScreen.Load(User);
				break;
			case 3:
				break;
			case 4:
				break;
			case 5:
				Console.Clear();
				Console.WriteLine("Saindo da conta! \nPressione enter para continuar");
				Console.ReadKey();
				Program.Load();
				break;
			default:
				Console.Clear();
				Console.WriteLine("\u001b[31mInforme um valor correto!\u001b[0m");
				Console.ReadKey();
				Load();
				break;
		}
	}
}
