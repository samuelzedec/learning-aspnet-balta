using Bank.Models;
namespace Bank.Screens.AccessScreen;
public static class MenuAccessScreen
{
	public static string FilterFirstName(string? fullName) 
	{
		var delimiter = ' ';
		return new string(fullName?.TakeWhile(c => c != delimiter).ToArray());
		/* -----------------------------------------------------------------
		 * Ao usar o new string() ele recebe um array de char e transformar 
		 * em uma string!
		 * ----------------------------------------------------------------- */
	}

	public static void Load(User user) 
	{
		Console.Clear();
		var firstName = FilterFirstName(user.FullName);
		Console.WriteLine($"Bem vindo {firstName}!");
		Console.WriteLine("Digite o número da opção desejada: ");
		Console.WriteLine("[1] - Ver minhas informações");
		Console.WriteLine("[2] - Acessar conta corrente");
		Console.WriteLine("[3] - Acessar conta poupança");
		Console.WriteLine("[4] - Acessar conta corrente");
		Console.WriteLine("[5] - Sair da conta\n");
		Console.Write("\u001b[32m> \u001b[0m");
		Console.ReadKey();
	}
}
