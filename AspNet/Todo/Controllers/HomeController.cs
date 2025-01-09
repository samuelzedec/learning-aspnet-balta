using Microsoft.AspNetCore.Mvc;
using Todo.Data;
using Todo.Models;

namespace Todo.Controllers;

[ApiController]
[Route("/home")]
public class HomeController : ControllerBase
{
	/* ======================================================================
	 * IActionResult é um tipo específico do Asp.Net para retornos de código
	 * de status code ou dados, tornando o código mais fléxivel e alinhado
	 * com API RESTful.
	 * Os métodos tipo o Ok ou NotFound e etc... Saõ métodos do ControllerBase
	 * e são possíveis ser acessados porque estamos herdando da classe ^
	 * ====================================================================== */
	[HttpGet]
	[Route("")]
	public IActionResult Get([FromServices] AppDataContext context)
		=> Ok(context.Todos.ToList()); 
		// Retorna 200 e os dados da lista

	[HttpGet("{id:int}")]
	public IActionResult GetById(
		[FromServices] AppDataContext context,
		[FromRoute] int id
	)
	{
		var todo = context.Todos.FirstOrDefault(x => x.Id == id);
		if (todo is null)
			return NotFound("Todo não encontrado !"); 
			// Retornar 404 e a mensagem

		return Ok(todo);
	}

	[HttpPost("")]
	public IActionResult Post(
		[FromBody] TodoModel todo,
		[FromServices] AppDataContext context
	)
	{
		context.Todos.Add(todo);
		context.SaveChanges();
		return Created($"{todo.Id}", todo); 
		// Ao ser criado irá retornar 201 e nós guiará para uma rota, que nesse caso so irá por o Id
	}

	[HttpPut("{id:int}")]
	public IActionResult Put(
		[FromRoute] int id,
		[FromBody] TodoModel todo,
		[FromServices] AppDataContext context
	)
	{
		var item = context.Todos.FirstOrDefault(t => t.Id == id);
		if (item is null)
			return NotFound("Todo não encontrado !");

		item.Title = todo.Title;
		item.Done = todo.Done;

		context.Update(item);
		context.SaveChanges();
		return Ok("Todo excluído com sucesso !");
	}

	[HttpDelete("{id:int}")]
	public IActionResult Delete(
		[FromRoute] int id,
		[FromServices] AppDataContext context
	)
	{
		var item = context.Todos.FirstOrDefault(t => t.Id == id);
		if (item is null)
			return NotFound("Todo não encontrado !");


		context.Todos.Remove(item);
		context.SaveChanges();
		return Ok(item);
	}
}
