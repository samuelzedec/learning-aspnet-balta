namespace Using_Dispose;

internal static class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Interface IDispose\n");
        
        /*
         * Ao usar o using, o método .Dispose() da classe dentro do bloco será chamado automaticamente
         * para liberar recursos ou destruir a referência ao objeto.
         */

        using (var pagamento = new Pagamento())
        {
            Console.WriteLine("Procesando pagamento");
        }

    }
}

public class Pagamento : IDisposable
{
    public Pagamento()
    {
        Console.WriteLine("Iniciando pagamento");
    }
    
    /*
     * Ao implementar a interface IDisposable, podemos criar nosso método .Dispose().
     * Isso serve para que possamos liberar recursos, incluindo chamar o .Dispose() de outros objetos
     * que queremos destruir e liberar suas referências.
     */
    public void Dispose()
    {
        Console.WriteLine("Finalizando pagamento");
    }
}