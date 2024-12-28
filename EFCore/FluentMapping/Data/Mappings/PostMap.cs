using Blog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FluentMapping.Data.Mappings;
public class PostMap : IEntityTypeConfiguration<Post>
{
	public void Configure(EntityTypeBuilder<Post> builder)
	{
		builder.ToTable("Post");

		builder.HasKey(p => p.Id);

		builder
			.Property(p => p.Id)
			.ValueGeneratedOnAdd()
			.UseIdentityColumn();

		builder
			.Property(p => p.LastUpdateDate)
			.IsRequired()
			.HasColumnName("LastUpdateDate")
			.HasColumnType("SMALLDATETIME")
			// .HasDefaultValueSql("GETDATE()"); // Defini um valor padrão (O orgumento so aceita formato SQL em string)
			.HasDefaultValue(DateTime.Now.ToUniversalTime()); // Defini um valor padrão (O argumento aceita código C#)
			 

		builder.
			HasIndex(p => p.Slug, "IX_Post_Slug")
			.IsUnique();

		// Relacionamentos
		builder
			.HasOne(p => p.Author) // Define que um Post possui um Author (relacionamento 1:N)
			.WithMany(a => a.Posts)  // Define que um Author pode ter vários Posts
			.HasConstraintName("FK_Post_Author") // Nomeia a constraint de chave estrangeira no banco
			.OnDelete(DeleteBehavior.Cascade); // Configura a exclusão em cascata (ao excluir o Author, os Posts associados também serão excluídos)


		/* ===================================================================
		 * Para o relacionamento 1 para 1, poderiamos usar o método OwnsOne();
		 * =================================================================== */

		/* =====================================================================================================================
		 * Propriedade		|	* Comportamento																				   |
		 * =====================================================================================================================
		 * Cascade			|	* Exclui dependentes automaticamente quando o principal é excluído.							   |
		 * Restrict			|	* Impede a exclusão do principal enquanto houver dependentes.                                  |
		 * SetNull			|	* Define a chave estrangeira dos dependentes como null. 									   |
		 * ClientSetNull	|	* Define a chave estrangeira dos dependentes como null apenas no lado do cliente (EF Core).    |
		 * NoAction			|	* Nenhuma ação automática; tudo precisa ser tratado manualmente. 							   |
		 * ===================================================================================================================== */

		builder
			.HasMany(p => p.Tags) // Define que um Post pode ter várias Tags
			.WithMany(t => t.Posts) // Define que uma Tag pode ter vários posts
			// o UsingEntity serve para criar automaticamente uma tabela
			.UsingEntity<Dictionary<string, object>>( // Dictionary<string, object> é uma maneira de definir que a tabela intermediária será uma entidade sem uma classe específica em seu modelo.
			// A chave string representa o nome da tabela da tabela intermediária, e o valor object serão as colunas criadas.
				"PostTag",
				post => post.HasOne<Tag>() // Defini que um post pode ter várias tags
						.WithMany() // Defini que uma tag pode ter vários posts
						.HasForeignKey("PostId")  // Define o nome da coluna para a chave estrangeira de Post
						.HasConstraintName("FK_PostTag_PostId") // Defini o nome da Constraint que guarda essa relação  
						.OnDelete(DeleteBehavior.Cascade), // as tags não serão deletadas, apenas a associação entre tag e post será removida na tabela intermediaria.
						
				tag => tag.HasOne<Post>() // Defini que um post pode ter várias tags
						.WithMany() // Defini que uma tag pode ter vários post
						.HasForeignKey("TagId") // Define o nome da coluna para a chave estrangeira de Tag
						.HasConstraintName("FK_PostTag_TagId") // Defini o nome da Constraint que guarda essa relação  
						.OnDelete(DeleteBehavior.Cascade) // os posts não serão deletados, apenas a associação entre post e tag será removida na tabela intermediaria.
			);
	}
}