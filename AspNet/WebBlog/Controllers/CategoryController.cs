using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebBlog.Data;
using WebBlog.Extensions;
using WebBlog.Models;
using WebBlog.ViewModels;

namespace WebBlog.Controllers;

[ApiController]
public class CategoryController : ControllerBase
{
    [HttpGet("v1/categories")]
    public async Task<IActionResult> GetAsync(
        [FromServices] BlogDataContext context)
    {
        try
        {
            var categories = await context
                .Categories
                .AsNoTracking()
                .ToListAsync();
        
            return Ok(new ResultViewModel<List<Category>>(categories));
        }        
        catch
        {
            return StatusCode(500, new ResultViewModel<List<Category>>("05X04 - Falha interna no servidor"));
        }
    }
    
    [HttpGet("v1/categories/{id:int}")]
    public async Task<IActionResult> GetByIdAsync(
        [FromRoute] int id,
        [FromServices] BlogDataContext context)
    {
        try
        {
            var category = await context
                .Categories
                .Include(x => x.Posts)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            return category is null
                ? NotFound(new ResultViewModel<Category>("Conteúdo não encontrado"))
                : Ok(new ResultViewModel<Category>(category));
        }
        catch (Exception)
        {
            return StatusCode(500, new ResultViewModel<Category>("05XE5 - Falha interna no servidor"));
        }
    }

    [HttpPost("v1/categories")]
    public async Task<IActionResult> InsertAsync(
        [FromBody] EditorCategoryViewModel model,
        [FromServices] BlogDataContext context)
    {
        if(!ModelState.IsValid) 
            return BadRequest(new ResultViewModel<Category>(ModelState.GetErrors()));
        try
        {
            var category = new Category
            {
                Id = 0,
                Name = model.Name,
                Slug = model.Slug.ToLower().Replace(' ', '-'),
                Posts = []
            };
            
            await context.Categories.AddAsync(category);
            await context.SaveChangesAsync();

            return Created($"v1/categories/{category.Id}", new ResultViewModel<Category>(category));
        }
        catch (DbUpdateException)
        {
            return StatusCode(500, new ResultViewModel<Category>("05XE9 - Não foi póssivel incluir a categoria"));
        }
        catch (Exception)
        {
            //O StatusCode retorna o tipo de erro a uma mensagem
            return StatusCode(500, new ResultViewModel<Category>("05XE10 - Falha interna no servidor"));
        }
    }
    
    [HttpPut("v1/categories/{id:int}")]
    public async Task<IActionResult> UpdateAsync(
        [FromRoute] int id,  
        [FromBody] EditorCategoryViewModel model,
        [FromServices] BlogDataContext context)
    {
        try
        {
            var category = await context
                .Categories
                .FirstOrDefaultAsync(x => x.Id == id);
            if (category is null) return NotFound();

            category.Name = model.Name;
            category.Slug = model.Slug;

            context.Categories.Update(category);
            await context.SaveChangesAsync();

            // Retornar 204 (A requisição foi processada com sucesso, porém não retorna nada).
            return NoContent();
        }
        catch (DbUpdateException)
        {
            return StatusCode(500, new ResultViewModel<Category>("05XE8 - Não foi possível alterar a categoria"));
        }
        catch (Exception)
        {
            return StatusCode(500, new ResultViewModel<Category>("05XE11 - Falha interna no servidor"));
        }
        
    }

    [HttpDelete("v1/categories/{id:int}")]
    public async Task<IActionResult> DeleteAsync(
        [FromRoute] int id,
        [FromServices] BlogDataContext context)
    {
        try
        {
            var category = await context
                .Categories
                .FirstOrDefaultAsync(x => x.Id == id);
            if (category is null) return NotFound();
        
            context.Categories.Remove(category);
            await context.SaveChangesAsync();
            return NoContent();
        }
        catch (DbUpdateException)
        {
            return StatusCode(500, new ResultViewModel<Category>("05XE7 - Não foi possível excluir a categoria"));
        }
        catch (Exception)
        {
            return StatusCode(500, new ResultViewModel<Category>("05XE12 - Falha interna no servidor"));
        }
    }
}