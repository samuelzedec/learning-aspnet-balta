using Bank.Shared.Interfaces;
using Dapper.Contrib.Extensions;
namespace Bank.Models;

[Table("[Address]")]
public class Address : IRequiredField
{
	[ExplicitKey]
	public int? UserId { get; set; }
	public string? Road { get; set; }
	public short Number { get; set; }
	public string? Neighborhood { get; set; }
	public string? City { get; set; }
	public string? State { get; set; }
	public string? ZipCode { get; set; }
	
	/*
	 * Cometi um erro em fazer com que minha classe Repository<T> dependesse da Interface IRequiredField
	 * Porque não é necessário nestá classe, pórem como é um sistema para praticar o Dapper, não irei
	 * Ajustar tudo para isso, mas sei que isso não é uma boa prática!
	 */
	[Write(false)]
	public int Id { get; set; }
}
