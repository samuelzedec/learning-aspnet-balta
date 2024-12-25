using Bank.Models;
using Bank.Screens.AccessScreen;
using Bank.Services;

namespace Bank.Screens.ActionsScreen;
public static class UserScreen
{
	public static void Read(User? info) 
	{
		var user = UserActions.ReadingUserInformation(info?.Id);
		Console.Clear();
		Console.WriteLine("\u001b[32mSuas informações cadastradas: \u001b[0m");
		Console.WriteLine($"Nome completo: {user?.FullName}");
		Console.WriteLine($"CPF: {user?.Cpf}");
		Console.WriteLine($"Data de Nascimento: {user?.DateOfBirth.ToShortDateString()}");
		Console.WriteLine($"Telefone: {user?.Phone}");
		Console.WriteLine($"Email: {user?.Email}");
		Console.WriteLine($"Senha: {user?.Password}");
		Console.WriteLine("Endereço:");
		Console.WriteLine($"\t- \u001b[33mRua:\u001b[0m {user?.Address.Road}");
		Console.WriteLine($"\t- \u001b[33mNúmero:\u001b[0m {user?.Address.Number}");
		Console.WriteLine($"\t- \u001b[33mBairro:\u001b[0m {user?.Address.Neighborhood}");
		Console.WriteLine($"\t- \u001b[33mCidade:\u001b[0m {user?.Address.City}");
		Console.WriteLine($"\t- \u001b[33mState:\u001b[0m {user?.Address.State}");
		Console.WriteLine($"\t- \u001b[33mCEP:\u001b[0m {user?.Address.ZipCode}");
		Console.ReadKey();

		MenuAccessScreen.Load();
	}
}
