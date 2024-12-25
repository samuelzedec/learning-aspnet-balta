using EFCore.Data;
using EFCore.Models;
using Microsoft.EntityFrameworkCore;

using (var context = new BlogDataContext())
{
	
	//Create 
	var tagCreate = new Tag() { Name = "ASP.NET", Slug = "aspnet" };
	context.Tags?.Add(tagCreate);


	//Update
	var tagUpdate = context.Tags?.FirstOrDefault(x => x.Id == 3);
	if(tagUpdate is not null) 
	{
		tagUpdate.Name = "Razor Pages";
		tagUpdate.Slug = "razor-pages";
		context.Update(tagUpdate); // Serve para salvar as alterações que foram feito na tag
	}

	//Delete
	var tagDelete = context.Tags?.FirstOrDefault(x => x.Id == 3);
	if (tagDelete is not null) context.Remove(tagDelete); //Serve para fazer delete

	//Read
	/* ----------------------------------------------------------
	* Podemos usar o AsNoTracking para evitar trazer metadados para 
	* operações que não precisam como o Read.
	* Porém o Update, Delete e Entidades que possuem relacionamento
	* não é bom usar porque irá ocorrer perdas de referência
	* ---------------------------------------------------------- */
	var tags = context.Tags
		?.AsNoTracking() 
		.ToList(); 
	/* ----------------------------------------------------------
	* Para fazer uma query usamos um ToList, pq seu comportamento é tipo uma IEnumerable<T>
	* Uma boa prática é sempre usar o ToList por último caso precise fazer um filtro
	* Porque ele iria fazer o filtro na memória e so dps iria realmente fazer a query.
	* Assim irá ficar com uma melhor perfomance;
	* ---------------------------------------------------------- */
	if(tags is not null) 
	{
		foreach(var t in tags) 
		{
			Console.WriteLine(t.Name);
		}
	}


	context.SaveChanges();
	/* ----------------------------------------------------------
	* Ao usar o método .SaveChanges, ele irá fazer com que as
	* alterações feitas em memória, sejam realizadas no banco
	* e não fiquem somente na memória.
	* 
	* As propriedades que representam as tabelas são parecidas com
	* listas, então podemos usar LINQ e alguns métodos para manipular.
	* ---------------------------------------------------------- */
	
	var tag = context.Tags
		?.AsNoTracking()
		.FirstOrDefault(t => t.Id == 2);
		
	Console.WriteLine(tag?.Name);
}
