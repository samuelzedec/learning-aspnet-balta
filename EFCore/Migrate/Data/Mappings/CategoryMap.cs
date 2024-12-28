using Blog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FluentMapping.Data.Mappings;

/* =============================================================================
 * Usamos a Interface IEntityTypeConfiguration<T> para acessar o método
 * Configure, sendo assim, podemos configurar a model em relação ao banco de dados
 * ============================================================================= */
public class CategoryMap : IEntityTypeConfiguration<Category>
{
	/* =============================================================================
	 * A classe EntityTypeBuilder<T> é usada para configurar 
	 * entidades durante a configuração do modelo de dados. 
	 * ============================================================================= */
	public void Configure(EntityTypeBuilder<Category> builder)
	{
		// Especificando o nome da tabela que a model Category representa.
		builder.ToTable("Category");
		
		// Especificando a chave primária da tabela.
		builder.HasKey(m => m.Id);

		// Configurando a propriedade Id como uma chave primária que é gerada pelo banco de dados.
		builder.Property(m => m.Id)
			.ValueGeneratedOnAdd() // Indica que o valor será gerado no banco de dados.
			.UseIdentityColumn(); // Define a coluna como IDENTITY(1, 1) no SQL Server.

		// Mapeando proprieades 
		builder.Property(m => m.Name)
			.IsRequired() // Referente ao NOT NULL em SQL Server
			.HasColumnName("Name") // Definindo o nome da coluna 
			.HasColumnType("NVARCHAR") // Definindo o tipo da coluna em SQL Server
			.HasMaxLength(80); // Definindo o máximo de caracteres a coluna suporta
		
		builder.Property(m => m.Slug)
			.IsRequired() 
			.HasColumnName("Slug") 
			.HasColumnType("VARCHAR") 
			.HasMaxLength(80);

		// Criando INDEX
		builder.HasIndex(x => x.Slug, "IX_Category_Slug") // Serve para criar um INDEX para um propriedade
			.IsUnique(); // Garante que os valores nessa coluna sejam únicos (Só pode ser usado após o HasIndex())
	}
}
/* =============================================================================
 * Podemos achar mais informações sobre os métodos da classe EntityTypeBuilder<T> 
 * na documentação do EF Core, pesquisando por FluentMappping.
 * ============================================================================= */ 
