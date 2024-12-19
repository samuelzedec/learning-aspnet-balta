using Blog.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
namespace Blog.Repositories;

public class RoleRepository
{
	private readonly SqlConnection _connection;
	public RoleRepository(SqlConnection connection) 
		=> _connection = connection;
	
	public IEnumerable<Role> Get()
		=> _connection.GetAll<Role>();
		
	public Role Get(int id)
		=> _connection.Get<Role>(id);

	public long Create(Role role) 
	{
		role.Id = 0;
		return _connection.Insert<Role>(role);
	}
		
	public bool Update(Role role)
	{
		if(role.Id != 0)
			return _connection.Update<Role>(role);

		return false;
	}
	
	public bool Delete(Role role)
	{
		if (role.Id != 0)
			return _connection.Delete<Role>(role);

		return false;
	}
	
	public bool Delete(int id) 
	{
		if (id == 0) return false;

		var role = Get(id);
		return _connection.Delete<Role>(role);
	}
}
