using Bank.Repositories;
using Bank.Shared;

namespace Bank.Screens.AccessScreen;
public static class LockScreen
{
	public static void Load() 
	{
		var validator = new ValidatedValues();
		var repository = new UserRepository();
		
		Console.Clear();
		Console.WriteLine("\u001b[33m!! Login !!\u001b[0m");
		Console.ReadKey();

		var user = repository.LookingForUser(validator.StringValidation("Informe seu Email: "));
		if(user is null) 
		{
			Console.WriteLine("\u001b[31mEmail não cadastrado!\u001b[0m");
			Console.ReadKey();
			Program.Load();
		}

		var password = validator.StringValidation("Informe sua senha: ");
		
		if(user?.Password == password) {
			Console.WriteLine("\u001b[32mLogin feito com sucesso\u001b[0m");
			Console.ReadKey();
			
			MenuAccessScreen.User = user;
			MenuAccessScreen.Load();
		} 
		else 
		{
			Console.WriteLine("\u001b[31mSenha incorreta!\u001b[0m");
			Console.ReadKey();
		}
	} 
}