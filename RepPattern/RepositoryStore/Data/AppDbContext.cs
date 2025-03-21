using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using RepositoryStore.Models;

namespace RepositoryStore.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Product> Products { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        => modelBuilder.ApplyConfigurationsFromAssembly(typeof(Program).Assembly);
    /* ===================================================================================================
     * escaneia o assembly especificado (neste caso, o assembly onde a classe Program está definida)
     * e aplica todas as configurações de entidade que implementam a interface IEntityTypeConfiguration<T>
     * 
     * Assembly.GetExecutingAssembly(): pega somente o assembly onde esse código está sendo executado (onde o DbContext está definido).
     * typeof(Program).Assembly: permite que você explicitamente aponte para o assembly principal da aplicação.
     * ==================================================================================================== */
}