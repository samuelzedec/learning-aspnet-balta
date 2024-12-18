using Blog.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
namespace Blog.Repositories;

/* ---------------------------------------------------------------------------- 
* Ao usar o Dapper.Contrib, ele irá buscar a tabela que tiver o mesmo nome da Model,
* com as propriedades que tem na Model, ambos os nomes tem que está Idênticos
* ---------------------------------------------------------------------------- */
public class UserRepository
{
	private readonly SqlConnection _connection;
	public UserRepository(SqlConnection connection) 
		=> _connection = connection;
	
	public IEnumerable<User> Get()
		=> _connection.GetAll<User>();
		
	public User Get(int id)
		=> _connection.Get<User>(id);

	public long Create(User user)
		=> _connection.Insert<User>(user);
}
