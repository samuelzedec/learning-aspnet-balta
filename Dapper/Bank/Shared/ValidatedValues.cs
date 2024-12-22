using System.Globalization;
namespace Bank.Shared;
public class ValidatedValues
{
	public string StringValidation(string message) 
	{
		Console.Clear();
		Console.Write(message);
		string value = Console.ReadLine() ?? "";

		if (string.IsNullOrWhiteSpace(value))
		{
			Console.Clear();
			Console.WriteLine("Formato Inválido... Digite Novamente!");
			Console.ReadKey();
			return StringValidation(message);
		}

		return value;
	}
	
	public short ShortValidation(string message) 
	{
		Console.Clear();
		Console.Write(message);
		if (!short.TryParse(Console.ReadLine(), out short value)) 
		{
			Console.Clear();
			Console.Write("Formato Inválido... Digite Novamente!");
			Console.ReadKey();
			return ShortValidation(message); 
		}

		return value;
	}
	
	public DateTime DateTimeValidation(string message) 
	{
		Console.Clear();
		Console.Write(message);
		string value = Console.ReadLine() ?? "";

		if (!DateTime.TryParse(value,
			new CultureInfo("pt-BR"),
			DateTimeStyles.None,
			out DateTime date
		))
		{
			Console.Clear();
			Console.Write("Formato Inválido... Digite Novamente!");
			Console.ReadKey();
			return DateTimeValidation(message);
		}
		
		return date;
	}
}
