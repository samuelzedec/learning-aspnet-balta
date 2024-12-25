using Bank.Shared.Interfaces;
using Dapper.Contrib.Extensions;
namespace Bank.Models;

[Table("[User]")]
public class User : IRequiredField
{
	public User()
	{
		Accounts = new List<Account>();
		DateOfBirth = new DateTime();
		Address = new Address();
	}	
	
	public int Id { get; set; }
	public string? FullName { get; set; }
	public string? Cpf { get; set; }
	public DateTime DateOfBirth { get; set; }
	public string? Phone { get; set; }
	public string? Email { get; set; }
	public string? Password { get; set; }

	[Write(false)]
	public List<Account>? Accounts { get; set; }
	
	[Write(false)]
	public Address Address { get; set; }
}