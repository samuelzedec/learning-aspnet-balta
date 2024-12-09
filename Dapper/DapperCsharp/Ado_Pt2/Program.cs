using System.Data;
using Microsoft.Data.SqlClient;
namespace Ado_Pt2;

internal class Program
{
    public static void Main(string[] args)
    {
        const string connectionString = "Server=localhost,9090;Database=balta;User ID=sa;Password=1q2w3e4r@#$;TrustServerCertificate=True";
        
        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open(); // Abre explicitamente a conexão antes de usá-la

            using (var command = new SqlCommand())
            {
                command.Connection = connection; // Associa o comando à conexão
                command.CommandType = CommandType.Text; // Define o tipo de comando SQL
                command.CommandText = "SELECT [Id], [Title] FROM [Category]"; // Define o comando SQL

                using var reader = command.ExecuteReader(); // Executa o comando e obtém um leitor
            
                while (reader.Read()) // Enquanto houver resultados, o 'while' será executado
                {
                    Console.WriteLine($"{reader.GetGuid(0)} - {reader.GetString(1)}");
                    /* ------------------------------------------------------------
                     * reader.GetGuid(0) -> Obtém o valor da coluna [Id] como GUID
                     * reader.GetString(1) -> Obtém o valor da coluna [Title] como string
                     * 0: Índice da coluna [Id] (primeira coluna)
                     * 1: Índice da coluna [Title] (segunda coluna)
                     * ------------------------------------------------------------ */
                }
            }
        }

        /* -------------------------------------------------------------
         * Utilizamos blocos 'using' para garantir que recursos como
         * conexões e leitores sejam liberados adequadamente após o uso,
         * evitando problemas como vazamento de memória.
         * ------------------------------------------------------------- */
    }
}
