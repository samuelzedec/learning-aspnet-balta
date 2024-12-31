using Library.Data;
using Library.Models;
using Microsoft.EntityFrameworkCore;
namespace Library.Repository;

public class AddressRepository
{
	public required Address Address { get; set; }
	public required LibraryDataContext Context { get; set; }

	public async Task<bool> Update(int clientId, Address model)
	{
		var address = await Context.Addresses
			.FirstOrDefaultAsync(a => a.Client.Id == clientId) 
			?? throw new ArgumentNullException("Endereço não encontrado!");
		
		address.Road = model.Road;
		address.Number = model.Number;
		address.Neighborhood = model.Neighborhood;
		address.City = model.City;
		address.State = model.State;
		address.ZipCode = model.ZipCode;

		Context.Update(address);
		return await Context.SaveChangesAsync() > 0;
		
	}
	
	public async Task<Address> Get(int clientId)
	{
		var address = await Context.Addresses
			.AsNoTracking()
			.FirstOrDefaultAsync(a => a.Client.Id == clientId)
			?? throw new ArgumentNullException("Endereço não encontrado!");

		return address;
	}
}