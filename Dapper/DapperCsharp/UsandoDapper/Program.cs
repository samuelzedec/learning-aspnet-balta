using System.Data;
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
            // OneToOne(connection);
            // ReadView(connection);
            // ExecuteScalar(connection);
            // ExecuteReadProcedure(connection);
            // ExecuteProcedure(connection);
            // GetCategory(connection);
            // ListCategories(connection);
            // CreateCategory(connection);
            // CreateManyCategories(connection);
            // OneToMany(connection);
            // QuerMultiple(connection);
            // SelectIn(connection);
            // Like(connection);
            Transactions(connection);
        }
    }
    public static void GetCategory(SqlConnection connection)
    {
        var queryCategory = 
            @"SELECT TOP 1 
                [Id], [Title]  
            FROM 
                [Category] 
            WHERE 
                [Id] = @id";
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
    
    public static void CreateManyCategories(SqlConnection connection)
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
    public static void ExecuteProcedure(SqlConnection connection)
    {
        /* ------------------------------------------------------
         * Não é mais preciso passar os parâmetros diretamente na procedure.
         * Somente o nome da procedure e os parâmetros devem ser passados na parte de params.
         * ------------------------------------------------------ */
        var procedure = "[DeleteStudent]";
        var pars = new { StudentId = new Guid("0CEECE3A-F44D-4851-BB9F-C2805CD9F523") };
        var affectedRows = connection.Execute(
            procedure, 
            pars, 
            commandType: CommandType.StoredProcedure);
        /* -------------------------------------------------
         * Ao executar stored procedures, é necessário definir o
         * CommandType como CommandType.StoredProcedure.
         * Caso contrário, o comando será tratado como uma query SQL comum,
         * e não como uma chamada de procedure.
         *
         * Importante: Ao usar CommandType.StoredProcedure,
         * não é necessário incluir "EXEC" no comando SQL.
         *
         * Caso a procedure tenha um SELECT ou qualquer consulta que retorne dados,
         * é mais adequado usar o .Query() ao invés de .Execute().
         * ------------------------------------------------- */
        Console.WriteLine($"Linhas afetadas: {affectedRows}");
        /*
         * Diferença entre .Execute() e .Query():
         * - .Execute(): Usado para operações sem retorno de dados (como INSERT, UPDATE, DELETE,
         *   e stored procedures que não retornam dados). Retorna o número de linhas afetadas.
         *
         * - .Query(): Usado para consultas que retornam dados (como SELECT).
         *   Retorna um conjunto de dados, normalmente um IEnumerable<T> ou uma lista de objetos.
         */
    }
    public static void ExecuteReadProcedure(SqlConnection connection) 
    {
        var procedure = "[spGetCoursesByCategory]";
        /* ------------------------------------------------------------------------
         * Na parte de parãmetros o nome das proprieades do objeto anônimo tem quer
         * ser o mesmo que está no nome do parâmetro da Stored Procedure
         * ------------------------------------------------------------------------ */
        var pars = new { CategoryId = "09CE0B7B-CFCA-497B-92C0-3290AD9D5142" };
        var courses = connection.Query(
            procedure,
            pars,
            commandType: CommandType.StoredProcedure
        );
        foreach (var item in courses)
        {
            //para não ocorrer um erro o nome da propriedade tem que ser igual o da coluna 
            Console.WriteLine(item.Title);
        }
    }

    public static void ExecuteScalar(SqlConnection connection)
    {
        var category = new Category()
        {
            Title = "Amazon AWS",
            Url = "amazon",
            Description = "Categoria destinada a serviços do AWS",
            Order = 8,
            Summary = "AWS Cloud",
            Featured = false
        };
        
         /*
          * Ao usar o comando OUTPUT com inserted, podemos retornar valores das colunas
          * que foram inseridas na tabela durante o comando INSERT.
          *
          * OUTPUT: Define os dados que queremos retornar após a inserção.
          * INSERTED: É uma tabela lógica temporária que contém os valores das colunas
          * recém-inseridas no momento da execução.
          */
         var insertSql =
             @"INSERT INTO
                 [Category]([Id], [Title], [Url], [Summary], [Order], [Description], [Featured])
             OUTPUT inserted.[Id]
             VALUES(
                 NEWID(),
                 @Title,
                 @Url,
                 @Summary,
                 @Order,
                 @Description,
                 @Featured
             )";
         /*
          * SELECT SCOPE_IDENTITY();
          * Retorna o último valor de identidade gerado automaticamente
          * no escopo atual (como em uma coluna IDENTITY após um INSERT).
          * É usado para obter o ID do registro recém-criado no mesmo
          * escopo de execução.
          * todo: Importante! Somente usado para tipos inteiros
          */
        
        var id = connection.ExecuteScalar<Guid>(insertSql, new
        {
            category.Title,
            category.Url,
            category.Summary,
            category.Order,
            category.Description,
            category.Featured
        });
        /* -----------------------------------------------------------------------------------------------
         * O método .ExecuteScalar<T>() em Dapper (e também em ADO.NET) é usado para executar um comando SQL
         * e retornar um único valor. Esse valor é o primeiro resultado da primeira coluna da primeira linha
         * no conjunto de resultados retornado pela consulta.
         * ----------------------------------------------------------------------------------------------- */
        Console.WriteLine($"A categoria inserida foi: {id}");
    }

    public static void ReadView(SqlConnection connection)
    {
        var sql = @"SELECT [Title] FROM [vwCourses]";
        var courses = connection.Query(sql);
        foreach (var course in courses)
        {
            Console.WriteLine(course.Title);
        } 
    }

    public static void OneToOne(SqlConnection connection)
    { 
        var sql = 
            @"SELECT 
                * 
            FROM 
                [CareerItem] 
            INNER JOIN 
                [Course]
            ON [CareerItem].[CourseId] = [Course].[Id]";
        
        /*
         * Explicando o código abaixo:
         *
         * .Query<CareerItem, Course, CareerItem>
         *      - O primeiro e o segundo parâmetros são tipos adicionais que vêm da consulta.
         *      - O último parâmetro (neste caso, o 'CareerItem') é sempre o modelo final que será retornado.
         *
         * (careerItem, course)
         *      - O primeiro parâmetro da função lambda é o modelo final (CareerItem) que será retornado.
         *      - Os parâmetros subsequentes são os tipos adicionais (neste caso, 'Course') que vêm da consulta.
         *      - Se algum dos tipos adicionais for do mesmo tipo que o modelo final, o Dapper automaticamente associa esses valores ao modelo final sem precisar de atribuição manual.
         *      - Caso contrário, a atribuição deve ser feita manualmente dentro da função lambda.
         */
        var itens = connection.Query<CareerItem, Course, CareerItem>(
            sql,
            (careerItem, course) =>
            {
                careerItem.Course = course;
                return careerItem;
            }, splitOn: "Id");
        /*
         * splitOn: "Id" (Passar sem os colchetes)
         * Nesse caso em específico, estamos dizendo ao Dapper que, ao encontrar a coluna [Id] desde que esse [Id] não se repita,
         * ele deve entender que os dados que vieram antes dessa coluna pertencem ao tipo `CareerItem`,
         * e, a partir de [Id], os dados a seguir pertencem ao tipo `Course`.
         */

        Console.WriteLine("Career Item:");
        foreach (var item in itens)
        {
            Console.WriteLine($"\n{item.Id} - {item.Title}");
            Console.WriteLine($"\t{item.Course.Id} - {item.Course.Title}");
        }
    }

    public static void OneToMany(SqlConnection connection)
    {
        var sql = @"
            SELECT
                [Career].[Id],
                [Career].[Title],
                [CareerItem].[CareerId],
                [CareerItem].[Title]
            FROM
                [Career]
            INNER JOIN
                [CareerItem] ON [CareerItem].[CareerId] = [Career].[Id]
            ORDER BY
                [Career].[Title]";

        var careers = new List<Career>();
        var items = connection.Query<Career, CareerItem, Career>(
            sql,
            (career, item) =>
            {
                var car = careers.Where(x => x.Id == career.Id).FirstOrDefault();
                if (car is null)
                {
                    car = career;
                    car.Items.Add(item);
                    careers.Add(car);
                }
                else
                {
                    car.Items.Add(item);
                }
                
                return career;
            }, splitOn: "CareerId");
        
        foreach (var item in careers)
        {
            Console.WriteLine($"\n{item.Title}");
            foreach (var careerItem in item.Items)
            {
                Console.WriteLine($"\t- {careerItem.Title}");
            }
        }
    }

    public static void QuerMultiple(SqlConnection connection)
    {
        /*
         * Ao usar o método .QueryMultiple() podemos fazer diversas requisições
         * E usar o.Read para armazenar seus valores me variáveis
         */
        var query = @"SELECT * FROM [Category]; SELECT * FROM [Course]";
        using (var multi = connection.QueryMultiple(query))
        {
            var categories = multi.Read<Category>();
            var courses = multi.Read<Course>();
            /*
             * Lê cada conjunto de resultados de forma separada e o transforma em uma coleção
             * de objetos do tipo especificado (neste caso, Category ou Course).
             */

            foreach (var category in categories)
            {
                Console.WriteLine(category.Title);
            }
            foreach (var course in courses)       
            {
                Console.WriteLine(course.Title);
            }
        }
    }

    public static void SelectIn(SqlConnection connection)
    {
        var sql = 
            @"select top 10 * from career where [id] in @Id";
        
        var item = connection.Query<Career>(
            sql,
            new
            {
                Id = new[]
                {
                    "01AE8A85-B4E8-4194-A0F1-1C6190AF54CB",
                    "E6730D1C-6870-4DF3-AE68-438624E04C72"
                }
            });

        foreach (var ir in item)
        {
            Console.WriteLine(ir.Title);
        }
        
    }

    public static void Like(SqlConnection connection)
    {
        var sql = 
            @"select * from [course] where [title] like @exp";
        
        var item = connection.Query<Course>(
            sql,
            new
            {
                exp = "%backend%"
            });

        foreach (var ir in item)
        {
            Console.WriteLine(ir.Title);
        }
    }

    public static void Transactions(SqlConnection connection)
    {
        var category = new Category();
        category.Id = Guid.NewGuid();
        category.Title = "Minha categoria que não";
        category.Url = "amazon";
        category.Description = "Categoria destinada a serviços do AWS";
        category.Order = 8;
        category.Summary = "AWS Cloud";
        category.Featured = false;

        var insertSql = @"INSERT INTO 
                    [Category] 
                VALUES(
                    @Id, 
                    @Title, 
                    @Url, 
                    @Summary, 
                    @Order, 
                    @Description, 
                    @Featured)";

        // Ao usar o método .BeginTransaction() é preciso abrir a conexão porque ele é um método do ADO .NET
        connection.Open();
        /*
         * Aqui criamos uma transação, porém para executar ainda precisamos do connection
         */
        using (var transaction = connection.BeginTransaction())
        {
            var rows = connection.Execute(insertSql, new
            {
                category.Id,      
                category.Title,          
                category.Url,          
                category.Summary,       
                category.Order,         
                category.Description,   
                category.Featured       
            }, transaction);
            /*
             * Como estamos ainda usando o connection que é a nossa conexão, usamos
             * a variavel transaction para dizer que isso é uma transição
             */
            
            transaction.Commit(); //Aqui iremos confirmar se iremos querer fazer nossas alterações
            // transaction.Rollback(); --Iremos cancelar as alterações que iriamos fazer

            Console.WriteLine($"{rows} linhas inseridas");
        }
    }
}