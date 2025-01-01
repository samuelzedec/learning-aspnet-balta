using Library.Data;
using Library.Models;
using Microsoft.EntityFrameworkCore;
namespace Library.Repository;

public class AuthorRepository : IRepository<Author>
{
	private readonly LibraryDataContext Context;
	public AuthorRepository(LibraryDataContext context)
		=> Context = context;
	
	public Author Author { get; set; } = new Author();
	public async Task<bool> Create()
	{
		await Context.Authors.AddAsync(Author);
		return await Context.SaveChangesAsync() > 0;
	}
	
	public async Task<bool> Update(int id, Author model)
	{
		var author = await Context.Authors
			.FirstOrDefaultAsync(a => a.Id == id)
			?? throw new ArgumentNullException("Author não encontrado!");

		author.Name = model.Name;
		author.Age = model.Age;
		author.BirthDate = model.BirthDate;
		author.Nationality = model.Nationality;
		author.Biography = model.Biography;

		return await Context.SaveChangesAsync() > 0;
	}

	public async Task<bool> Delete(int id)
	{
		var author = await Context.Authors
			.FirstOrDefaultAsync(a => a.Id == id)
			?? throw new ArgumentNullException("Author não encontrado!");
		
		Context.Authors.Remove(author);
		return await Context.SaveChangesAsync() > 0;
	}

	public async Task<Author?> Get(int id)
		=> await Context.Authors
			.FirstOrDefaultAsync(a => a.Id == id)
			?? throw new ArgumentNullException("Author não encontrado!");

	public async Task<IEnumerable<Author>> GetAll(int skip, int take)
		=> await Context.Authors
			.Include(a => a.Books)
			.ToListAsync();
	
	public async Task<bool> BarrowBook(int id, params Book[] books) 
	{
		var author = await Context.Authors
			.FirstOrDefaultAsync(a => a.Id == id)
			?? throw new ArgumentNullException("Author não encontrado!");

		author.Books.AddRange(books);
		return await Context.SaveChangesAsync() > 0;
	}
}