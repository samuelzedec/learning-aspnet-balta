using Bank.Models;
using Bank.Shared;
using Dapper;
namespace Bank.Repositories;

public class AccountRepository : Repository<Account>
{
	public void CreatingTheAccounts(params Account[] accounts) 
	{
		var sql = 
		@"INSERT INTO
			[Account]([Id], [UserId], [Balance], [Opening], [AccountType])
		VALUES(
			@Id,
			@UserId,
			@Balance,
			@Opening,
			@AccountType
		)";
		AppSettings.Connection?.Execute(sql, accounts);
	}
}
