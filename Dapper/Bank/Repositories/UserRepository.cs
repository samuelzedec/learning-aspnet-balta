using System.Data;
using Bank.Models;
using Bank.Shared;
using Dapper;
namespace Bank.Repositories;

public class UserRepository : Repository<User>
{
	public int? ProcInsertUser(User parameters) 
	{
		var procedure = "[spInsertUser]";
		var userId = AppSettings.Connection?.ExecuteScalar<int>(
			procedure,
			parameters,
			commandType: CommandType.StoredProcedure
		);
		return userId;
	}
}
