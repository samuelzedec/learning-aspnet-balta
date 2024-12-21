using Bank.Shared.Interfaces;
using Dapper.Contrib.Extensions;
namespace Bank.Models;

[Table("[Transaction]")]
public class Transaction : IRequiredField
{
	[Key]
	public int Id { get; set; }
	public int AccountId { get; set; }
	public int AccountUserId { get; set; }
	public byte Type { get; set; }
	public decimal Value { get; set; }
	public DateTime Date { get; set; }
	public string? Message { get; set; }
}
