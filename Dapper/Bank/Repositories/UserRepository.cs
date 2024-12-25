using System.Data;
using Bank.Models;
using Bank.Shared;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Bank.Repositories;

public class UserRepository : Repository<User>
{
	public int? ProcInsertUser(
		string fullName, 
		string cpf, 
		DateTime dateOfBirth,
		string phone,
		string email,
		string password) 
	{
		var procedure = "[spInsertUser]";
		return AppSettings.Connection?.ExecuteScalar<int>(
			procedure,
			new { 
				FullName = fullName,
				Cpf = cpf,
				DateOfBirth = dateOfBirth,
				Phone = phone,
				Email = email,
				Password = password 
			},
			commandType: CommandType.StoredProcedure
		);
		
	}
	
	public User? LookingForUser(string mail) 
	{
		var sql = 
		@"SELECT 
			* 
		FROM 
			[User]
		WHERE
			[Email] = @email";

		return AppSettings.Connection?.QueryFirstOrDefault<User>(
			sql,
			new { email = mail }
		);
	}
	
	public User? ReturningUserInformation(int? id) 
	{
		var sql = @"
		SELECT TOP 1
			[User].*,
			[Address].*
		FROM
			[User]
		INNER JOIN [Address] ON [User].[Id] = [Address].[UserId]
		WHERE
			[User].[id] = @Id
		";
		
		var info = AppSettings.Connection?.Query<User, Address, User>(
			sql,
			(user, address) =>
			{
				user.Address = new Address();
				user.Address = address;
				return user;
			},
			new { Id = id },
			splitOn: "UserId"
		).FirstOrDefault();

		return info;
	}
}
