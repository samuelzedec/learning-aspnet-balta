using Bank.Shared.Interfaces;
using Dapper.Contrib.Extensions;
namespace Bank.Models;

[Table("[Account]")]
public class Account : IRequiredField
{
	public Account()
		=> Transactions = new List<Transaction>();
		
	[ExplicitKey]
	public int Id { get; set; }
	[ExplicitKey]
	public int? UserId { get; set; }
	public decimal Balance { get; set; }
	public DateTime Opening { get; set; }
	public string? AccountType { get; set; }
	
	[Write(false)]
	public List<Transaction> Transactions { get; set; }
}