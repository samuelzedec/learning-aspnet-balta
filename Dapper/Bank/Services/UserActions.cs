using Bank.Models;
using Bank.Repositories;
using Bank.Shared.Enums;
namespace Bank.Services;

public class  UserActions
{
	public void OpeningAccount(int? userId) 
	{
		var repository = new AccountRepository();
		var currentAccount = new Account
		{
			Id = (int)AccountTypes.CurrentAccount,
			UserId = userId,
			Balance = 0m,
			Opening = DateTime.Now,
			AccountType = "Current"
		};

		var savingsAccount = new Account
		{
			Id = (int)AccountTypes.SavingsAccount,
			UserId = userId,
			Balance = 0m,
			Opening = DateTime.Now,
			AccountType = "Savings"
		};

		var investmentAccount = new Account
		{
			Id = (int)AccountTypes.InvestmentAccount,
			UserId = userId,
			Balance = 0m,
			Opening = DateTime.Now,
			AccountType = "Investment"
		};

		repository.CreatingTheAccounts(currentAccount, savingsAccount, investmentAccount);
	} 
	
	public static User? ReadingUserInformation(int? id) 
	{
		var repository = new UserRepository();
		var user = repository.ReturningUserInformation(id);
		
		return user;
	}
}
