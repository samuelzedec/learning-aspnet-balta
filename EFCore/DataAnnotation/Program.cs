using Blog.Data;
using Blog.Models;
using Microsoft.EntityFrameworkCore;

using var context = new BlogDataContext();
var user = new User
{
	Name = "José Gabriel",
	Slug = "josegabriel",
	Email = "josegabriel@emai.com",
	Bio = "MVP",
	Image = "https://josegabriel.io",
	PasswordHash = "123456789"
};

var category = new Category
{
	Name = "Front-end",
	Slug = "frontend"
};

var post = new Post
{
	Author = user,
	Category = category,
	Body = "<p>Hello, World!</p>",
	Slug = "comecadno-com-ts",
	Summary = "Neste artigo vamos aprender TypeScript",
	Title = "Começando com TypeScript",
	CreateDate = DateTime.Now,
	LastUpdateDate = DateTime.Now
};

context.Posts?.Add(post);
/* ----------------------------------------------------------------
 * Ao adicionar apenas o objeto post, o próprio EF Core, faz a inserção
 * dos objetos user e category em duas devidas tabelas, porque o post 
 * depende delas. Tudo isso ele irá fazer em memória e somente irá 
 * adicionar quando chamarmos o o método SaveChanges();
 * Isso é chamdo de Subconjuntos
 * ---------------------------------------------------------------- */
context.SaveChanges();

var posts = context
	.Posts
	?.AsNoTracking()
	.Include(x => x.Author)
	.OrderByDescending(x => x.LastUpdateDate)
	.ToList();
/* -----------------------------------------------------------------------
 * Por padrão o EF Core não faz o preenchimento das classes de navegacação,
 * porém caso for preciso que uma classe de navegação seja preenchida, podemos
 * usar o método do .Includes() do EF que recebe como parâmetro uma empressão
 * lambda para referenciar qual classe de navegação deve ser preenchida!
 * Ela funciona como se fosse um INNER JOIN em SQL Server.
 * Podemos usar quantos Categories quisermos.
 *
 * Caso uma classe de navegação tenha uma subclasse de navegação podemos usar
 * abaixo do seu .Include() o .ThenInclude() que será acessar as propriedades
 * da classe qeu foi passar no .Include()
 * EX: .Include(x => x.Author).ThenInclude(a => a.Books)
 * Esse a do ThenInclude refere-se as props do Author (Seu uso deve ser evitado
 * porque ele faz SUBSELECT)
 * ----------------------------------------------------------------------- */

var postTest = context
   .Posts
   ?.Include(x => x.Author)
   .Include(x => x.Category)
   .OrderBy(x => x.LastUpdateDate)
   .FirstOrDefault();

if (postTest?.Author is null) return;

postTest.Author.Name = "Testing";
context.Posts?.Update(postTest);
context.SaveChanges();
/* -----------------------------------------------------------
 * O próprio EF Core irá fazer um Update de forma otimizada
 * na tabela do Author (User) na coluna Name, isso porque 
 * trouxemos os Tracking, sendo assim o EF Core saberá que
 * que so mexemos no subconjunto, fazendo um UDPATE otimizado 
 * em SQL.
 * ----------------------------------------------------------- */