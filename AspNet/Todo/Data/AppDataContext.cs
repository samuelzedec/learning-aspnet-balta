using Microsoft.EntityFrameworkCore;
using Todo.Models;

namespace Todo.Data;
public class AppDataContext : DbContext
{
	public DbSet<TodoModel> Todos { get; set; } = null!;

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseSqlite("DataSource=app.db;Cache=Shared");
	}
}
