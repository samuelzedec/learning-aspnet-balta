namespace Upcasting_Downcasting;

internal static class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Hello World!");
        var pessoa = new Person();
        
        //Upcasting é quando passamos de uma classe derivada para uma classe Herdada
        pessoa = new Personal();
        pessoa = new Corporate();
        
        //Downcasting é quando passamos de uma classe herdar para uma classe derivada
        var pessoaFisica = new Personal();
        pessoaFisica = (Personal) new Person();
    }
}

public class Person
{
    public string Name { get; set; }
}

public class Personal : Person
{
    public string Cpf { get; set; }
}

public class Corporate : Person
{
    public string Cnpj { get; set; }
}

