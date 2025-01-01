using Library.Data;
using Library.Models;
using Microsoft.EntityFrameworkCore;
namespace Library.Repository;

public class ClientRepository : IRepository<Client>
{
	private readonly LibraryDataContext Context;
	public ClientRepository(LibraryDataContext context)
		=> Context = context;
	
	public Client Client { get; set; } = new Client();
	public Address Address { get; set; } = new Address();
	
	public async Task<bool> Create()
	{
		Address.Client = Client;
		await Context.Addresses.AddAsync(Address);
		return await Context.SaveChangesAsync() > 0;
	}
	
	public async Task<bool> Update(int id, Client model)
	{
		var client = await Context.Clients
			.FirstOrDefaultAsync(c => c.Id == id)
			?? throw new ArgumentNullException("Cliente não encontrado!");
			
		client.Name = model.Name;
		client.BirthDate = model.BirthDate;
		client.Email = model.Email;
		client.Phone = model.Phone;

		return await Context.SaveChangesAsync() > 0;
	}

	public async Task<bool> Delete(int id)
	{
		var client = await Context.Clients
			.FirstOrDefaultAsync(c => c.Id == id)
			?? throw new ArgumentNullException("Cliente não encontrado!");

		Context.Clients.Remove(client);
		return await Context.SaveChangesAsync() > 0;
	}

	public async Task<Client?> Get(int id)
		=> await Context.Clients
			.AsNoTracking()
			.Include(c => c.Address)
			.Include(c => c.Books)
			.FirstOrDefaultAsync(c => c.Id == id);

	public async Task<IEnumerable<Client>> GetAll(int skip = 0, int take = 25)
		=> await Context.Clients
			.AsNoTracking()
			.Include(c => c.Address)
			.Skip(skip)
			.Take(take)
			.ToListAsync();
}