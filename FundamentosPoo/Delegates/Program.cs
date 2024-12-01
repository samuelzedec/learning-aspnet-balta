namespace Delegates;

internal static class Program
{
    public static void RealizarPagamento(double valor)
    {
        Console.WriteLine($"Pago o valor de: {valor}");
    }

    public static void RealizarSalario(double valor)
    {
        Console.WriteLine($"Salario o valor de: {valor}");
    }
    
    
    
    public static void Main(string[] args)
    {
        Console.WriteLine("Delegates\n");
        
        // var pagamento = new Pagamento.Pagar(RealizarPagamento);
        // pagamento(45);

        var pag = new Pagando(RealizarPagamento);
        pag += RealizarSalario;
        pag.Invoke(90);

    }
}

public delegate void Pagando(double valor);

public class Pagamento
{
    public delegate void Pagar(double valor);
}