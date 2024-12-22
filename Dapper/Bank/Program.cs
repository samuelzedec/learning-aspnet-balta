using Microsoft.Data.SqlClient;
using Bank.Shared;
using Bank.Screens.RegisterScreen;
using Bank.Screens.AccessScreen;
namespace Bank;

internal class Program
{
	public static readonly string ConnectionString = 
		@"Server=localhost,9090;Database=Bank;User ID=sa;Password=1q2w3e4r@#$;TrustServerCertificate=True";
	private static void Main(string[] args)
	{
		using (AppSettings.Connection = new SqlConnection(ConnectionString))
		{
			AppSettings.Connection.Open();
			Load();

		}
	}

	public static void Load()
	{
		Console.Clear();
		Console.WriteLine("\u001b[32mBem-vindo ao Banco Luck\u001b[0m");
		Console.WriteLine("Digite o dígito da opção desejada:");
		Console.WriteLine("[1] - Acessar Conta");
		Console.WriteLine("[2] - Criar Conta");
		Console.WriteLine("[3] - Encerrar programa\n");
		Console.Write("\u001b[32m> \u001b[0m");

		if (!byte.TryParse(Console.ReadLine(), out byte value))
			InvalidValue();

		Directing(value);
	}
	
	private static void Directing(byte value) 
	{
		switch(value) 
		{
			case 1:
				LockScreen.Load();
				break;
			case 2:
				MenuRegisterScreen.Load();
				break;
			case 3:
				Closing();
				break;
			default:
				InvalidValue(); 
				break;
		}
	}
	
	private static void Closing() 
	{
		Console.Clear();
		Console.WriteLine("\u001b[32mPrograma Encerrado!\u001b[0m");
	}
	
	private static void InvalidValue() 
	{
		Console.Clear();
		Console.WriteLine("\u001b[33mOpção Inválida...Informe um dos dígitos diponiveis!\u001b[0m");
		Console.ReadKey();
		Load();
	}
}