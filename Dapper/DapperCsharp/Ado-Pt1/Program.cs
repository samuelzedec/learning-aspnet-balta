using Microsoft.Data.SqlClient;
namespace Ado;

internal class Program
{
    public static void Main(string[] args)
    {
        const string connectionString = 
            "Server=localhost,9090;Database=balta;User ID=sa;Password=1q2w3e4r@#$;TrustServerCertificate=True";
        //Microsoft.Data.SqlClient pacote para acessar o banco de dados baixado via (NuGet)
        
        //Em vez de usar dessa formar, podemos usar o using para garantir que a conexão será encerrada
        /*
         * var connection = new SqlConnection(connectionString);
         * connection.Open(); Abre a conexão com o banco de dados
         * connection.Close(); Fecha a conexão com o banco de dados
         * connection.Dispose(); Irá destruir o objeto e fechar a conexão
        */

        using (var connection = new SqlConnection(connectionString))
        {
            Console.WriteLine("Conectando ao banco de dados...");
        }
        
        /* -----------------------------------------------------------
         * Ao abrir uma conexão é sempre bom você fechar após feito
         * o que deveria, se você deixar as conexões abertas
         * o SQL Server irá dar gargalos. 
         * ----------------------------------------------------------- */
        
        /* -----------------------------------------------------------
         * Ao abrir uma conexão faça tudo que precisa ser feito de uma
         * vez, pelo fato de ter um tempo minimo para a conexão abrir,
         * ao fazer isso você economizará tempo
         * ----------------------------------------------------------- */
    }
}

