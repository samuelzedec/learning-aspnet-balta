using Bank.Models;
using Bank.Repositories;
using Bank.Services;
using Bank.Shared;
using Bank.Shared.Enums;
namespace Bank.Screens.RegisterScreen;

public static class MenuRegisterScreen
{
	public static void Load() 
	{
		Console.Clear();
		Console.WriteLine("\u001b[33m!! Informe os dados necessários para que sua conta seja criada...\u001b[0m");
		Console.ReadKey();

		UserData();
	}
	
	private static void UserData() 
	{
		var validator = new ValidatedValues();
		var repository = new UserRepository();
		
		var fullName = validator.StringValidation("\u001b[32mNome completo: \u001b[0m");
		
		var cpf = validator.StringValidation("\u001b[32mCPF (somente números): \u001b[0m");
		cpf = $"{cpf.Substring(0, 3)}.{cpf.Substring(3, 3)}.{cpf.Substring(6, 3)}-{cpf.Substring(9, 2)}";
		
		var dateOfBirth = validator.DateTimeValidation("\u001b[32mData de Nascimento (dd/mm/yyyy): \u001b[0m");

		var phone = validator.StringValidation("Número de telefone (somente número com +DDD): ");
		phone = $"({phone.Substring(0, 3)}) {phone.Substring(3, 5)}-{phone.Substring(8, 4)}";
		/*
		 * .Substring(1º, 2º):
		 * 1º) Quer dizer que iremos a partir dali pegar os elementos
		 * 2º) Quer dizer a quantidade de elementos que teremos que pegar a partir do índice inicial
		 */

		var email = validator.StringValidation("\u001b[32mEmail para contato: \u001b[0m");
		var password = validator.StringValidation("\u001b[32mInforme uma senha: \u001b[0m");
		
		try 
		{
			var id = repository.ProcInsertUser(fullName, cpf, dateOfBirth, phone, email, password);
			AddressData(id);
		} 
		catch (Exception ex) 
		{
			Console.Clear();
			Console.WriteLine($"\u001b[31mOcorreu um erro inesperado: {ex.Message}\u001b[0m");
			Console.ReadKey();
			Program.Load();
		}
	}
	
	public static void AddressData(int? id) 
	{
		var address = new Address();
		var addressRepository = new Repository<Address>();
		var validator = new ValidatedValues();
		var userActions = new UserActions();

		address.UserId = id;
		address.Road = validator.StringValidation("\u001b[32mNome da rua: \u001b[0m");
		address.Number = validator.ShortValidation("\u001b[32mNúmero da casa: \u001b[0m");
		address.Neighborhood = validator.StringValidation("\u001b[32mBairro: \u001b[0m");
		address.City = validator.StringValidation("\u001b[32mCidade: \u001b[0m");
		address.State = validator.StringValidation("\u001b[32mEstado: \u001b[0m");
		address.ZipCode = validator.StringValidation("\u001b[32mCEP (Somente Números): \u001b[0m");
		
		Console.Clear();		
		try 
		{
			addressRepository.Create(address);
			userActions.OpeningAccount(id);
			Console.WriteLine("\u001b[32mConta criada com sucesso!!\u001b[0m");
			Console.WriteLine("!! Pressione enter para continuar !!");
			Console.ReadKey();
			Program.Load();
		} catch(Exception ex) 
		{
			Console.WriteLine($"\u001b[31mOcorreu um erro inesperado: {ex.Message}\u001b[0m");
			Console.WriteLine("Digite novamente as informações de endereço!");
			Console.WriteLine("!! Pressione enter para continuar !!");
			Console.ReadKey();
			AddressData(id);
		}
	}
	

}
