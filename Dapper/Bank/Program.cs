using Microsoft.Data.SqlClient;
using Bank.Shared;
namespace Bank;

internal class Program
{
	public static readonly string ConnectionString = 
		@"Server=localhost,9090;Database=Blog;User ID=sa;Password=1q2w3e4r@#$;TrustServerCertificate=True";
	private static void Main(string[] args)
	{
		using (AppSettings.Connection = new SqlConnection(ConnectionString))
		{
			AppSettings.Connection.Open();
		}
	}
}