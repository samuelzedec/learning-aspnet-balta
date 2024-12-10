using Dapper;
using Microsoft.Data.SqlClient;
using UsandoDapper.Models;

namespace UsandoDapper;

public static class Program
{
    public static void Main(string[] args)
    {
        const string connectionString = 
            "Server=localhost,9090;Database=balta;User ID=sa;Password=1q2w3e4r@#$;TrustServerCertificate=True";
        
        using (var connection = new SqlConnection(connectionString))
        {
            ListCategories(connection);
            // CreateCategory(connection);
            // CreateManyCategory(connection);
        }

    }
    
    public static void GetCategory(SqlConnection connection)
    {
        var queryCategory = @"SELECT TOP 1 [Id], [Title] FROM [Category] WHERE [Id]=@id";
        /* -----------------------------------------------------------
         * Ao usar o método .QueryFirstOrDefault<T>() ele terá um
         * retorno diferente de .Query(), nesse caso mesmo que o
         * resultado só vinhesse uma única categoria, ele viria como um
         * IEnumerable, ja com esse outro método ele retorna uma instância
         * da model que for definida
         * ----------------------------------------------------------- */
        var category = connection.QueryFirstOrDefault<Category>(queryCategory, new
        {
            id = "af3407aa-11ae-4621-a2ef-2028b85507c4"
        });
        Console.WriteLine($"{category?.Id} - {category?.Title}");
    }
    public static void ListCategories(SqlConnection connection)
    {
        /* -------------------------------------------------------------------------------------------
         * O método .Query<T>() é um método do Dapper que executa uma consulta SQL
         * e mapeia os resultados diretamente para objetos do tipo especificado (neste caso, Category).
         * Retorna um IEnumerable<T>
         * ------------------------------------------------------------------------------------------- */
        var categories = connection.Query<Category>("SELECT [Id], [Title] FROM [Category]");

        Console.WriteLine("Dados da database:");
        foreach (var item in categories) 
        {
            Console.WriteLine($"\nId: {item.Id}");
            Console.WriteLine($"Title: {item.Title}");
        }
        /* -------------------------------------------------------------------------------------------
         * Ao utilizar o .Query<T>() passando uma classe, o nome das propriedades da classe tem
         * que está de acordo com a propriedades da tabela, caso na classe esteja difrente podemos
         * usar os ALIAS para poder colocar com o mesmo nome da propriedadde da classe, exemplo:
         * todo: var categories = connection.Query<Category>("SELECT [Id] AS [Code], [Title] AS [Titulo] FROM [Category]");
         * ------------------------------------------------------------------------------------------- */
    }
    public static void CreateCategory(SqlConnection connection)
    {
        var category = new Category()
        {
            Id = Guid.NewGuid(),
            Title = "Amazon AWS",
            Url = "amazon",
            Description = "Categoria destinada a serviços do AWS",
            Order = 8,
            Summary = "AWS Cloud",
            Featured = false
        };
        
        //Para criar um parâmetro, usamos o @ na frente da key que desejamos usar
        var insertSql =
            @"INSERT INTO 
                [Category]([Id], [Title], [Url], [Summary], [Order], [Description], [Featured]) 
            VALUES(
                @Id,
                @Title,
                @Url,
                @Summary,
                @Order,
                @Description,
                @Featured
            )";
        
        /* -------------------------------------------------------------
         * Para evitar o SQL Injection, o Dapper no fornece o método
         * .Execute() onde passamos parâmetros para valores que queremos,
         * Ele um int, que significa retornar a quantidade de linhas que foram afetas
         * ------------------------------------------------------------- */
        var rows = connection.Execute(insertSql, new
        {
            category.Id,
            category.Title,
            category.Url,
            category.Summary,
            category.Order,
            category.Description,
            category.Featured
        });
        Console.WriteLine($"{rows} linhas inseridas ");
    }
    public static void UpdateCategory(SqlConnection connection)
    {
        var updateQuery =
            @"UPDATE 
                [Category] 
            SET 
                [Title] = @title
            WHERE 
                [Id] = @id";

        var rows = connection.Execute(updateQuery, new
        {
            id = new Guid("AF3407AA-11AE-4621-A2EF-2028B85507C4"),
            title = "FRONTEND - UPDATE"
        });
        Console.WriteLine($"Linhas alteradas: {rows}");
    }
    public static void CreateManyCategory(SqlConnection connection)
    {
        var category = new Category()
        {
            Id = Guid.NewGuid(),
            Title = "Amazon AWS",
            Url = "amazon",
            Description = "Categoria destinada a serviços do AWS",
            Order = 8,
            Summary = "AWS Cloud",
            Featured = false
        };
        
        var categoryTwo = new Category()
        {
            Id = Guid.NewGuid(),
            Title = "Nova Categoria",
            Url = "categoria-nova",
            Description = "Categoria Nova 2050",
            Order = 9,
            Summary = "Categoria",
            Featured = true
        };
        
        var insertSql =
            @"INSERT INTO 
                [Category]([Id], [Title], [Url], [Summary], [Order], [Description], [Featured]) 
            VALUES(
                @Id,
                @Title,
                @Url,
                @Summary,
                @Order,
                @Description,
                @Featured
            )";

        var rows = connection.Execute(insertSql, new[]
        {
            new {
                category.Id,
                category.Title,
                category.Url,
                category.Summary,
                category.Order,
                category.Description,
                category.Featured
            },
            new {
                categoryTwo.Id,
                categoryTwo.Title,
                categoryTwo.Url,
                categoryTwo.Summary,
                categoryTwo.Order,
                categoryTwo.Description,
                categoryTwo.Featured
            },
        } );
        Console.WriteLine($"{rows} linhas inseridas ");
    }
    
}