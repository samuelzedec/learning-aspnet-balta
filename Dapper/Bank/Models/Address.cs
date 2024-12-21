using Bank.Shared.Interfaces;
using Dapper.Contrib.Extensions;
namespace Bank.Models;

[Table("[Address]")]
public class Address : IUserIdRequired
{
	[ExplicitKey]
	public int UserId { get; set; }
	public string? Road { get; set; }
	public short Number { get; set; }
	public string? Neighborhood { get; set; }
	public string? City { get; set; }
	public string? State { get; set; }
	public string? ZipCode { get; set; }
}
