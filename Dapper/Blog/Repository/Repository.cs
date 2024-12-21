using Blog.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
namespace Blog.Repositories;

/* ------------------------------------------------
 * Uma boa prática é usar no Generic T
 * porque fica explícito que essa classe genérica
 * é somente para as models 
 * ------------------------------------------------ */
public class Repository<T> where T : class //Aqui estmoas dizendo que o tipo T só pode ser somente do tipo de classes
{
	public IEnumerable<T> Get()
		=> Database.Connection.GetAll<T>();
	
	public T Get(int id)
		=> Database.Connection.Get<T>(id);
		
	public long Create(T model) 
		=> Database.Connection.Insert<T>(model);
		
	public bool Update(T model)
		=>  Database.Connection.Update<T>(model);
	
	public bool Delete(T model)
		=> Database.Connection.Delete<T>(model);
	
	
	public bool Delete(int id) 
	{
		var model = Get(id);
		return Database.Connection.Delete<T>(model);
	}

}
