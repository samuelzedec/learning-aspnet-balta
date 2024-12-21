using Dapper;
using Microsoft.Data.SqlClient;
using Bank.Shared;

internal class Program
{
	private static void Main(string[] args)
	{
		using (var connection = new SqlConnection(AppSettings.ConnectionString))
		{
			
		}
	}
}