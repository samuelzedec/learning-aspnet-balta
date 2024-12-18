using Microsoft.Data.SqlClient;
using Dapper.Contrib.Extensions;
using Blog.Models;
using Blog.Repositories;

internal class Program
{
	private static readonly string CONNECTION_STRING = 
		@"Server=localhost,9090;Database=Blog;User ID=sa;Password=1q2w3e4r@#$;TrustServerCertificate=True";
	private static void Main(string[] args)
	{
		using (var connection = new SqlConnection(CONNECTION_STRING))
		{
			connection.Open();
			ReadUsers(connection);
			ReadRoles(connection);
		}
	}
	
	public static void ReadUsers(SqlConnection connection)
	{
		var repository = new UserRepository(connection);
		var users = repository.Get();
		
		foreach(var user in users)
			Console.WriteLine($"Nome do usuário: {user.Name}");
	}
	
	public static void ReadRoles(SqlConnection connection)
	{
		var repository = new RoleRepository(connection);
		var roles = repository.Get();
		
		foreach(var role in roles)
			Console.WriteLine($"Papel: {role.Name}");
	}
}
