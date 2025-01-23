using System.Data.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SecureIdentity.Password;
using WebBlog.Data;
using WebBlog.Extensions;
using WebBlog.Models;
using WebBlog.Services;
using WebBlog.ViewModels;

namespace WebBlog.Controllers;

// [Authorize] // Exige autenticação para acessar os endpoints dessa classe (pode ser sobrescrito por [AllowAnonymous] em endpoints específicos).
[ApiController]
public class AccountController : ControllerBase
{
    
    // [AllowAnonymous] // Este endpoint é acessível sem autenticação, mesmo que o [Authorize] esteja aplicado na classe.
    [HttpPost("v1/accounts/")]
    public async Task<IActionResult> Post(
        [FromBody] RegisterViewModel model,
        [FromServices] BlogDataContext context)
    {
        if (!ModelState.IsValid)
            return BadRequest(new ResultViewModel<string>(ModelState.GetErrors()));

        var user = new User
        {
            Name = model.Name,
            Email = model.Email,
            Slug = model.Email.Replace("@", "-").Replace(".", "-"),
            Bio = "null",
            Image = "null"
        };

        var password = PasswordGenerator.Generate(25, true, false);
        user.PasswordHash = PasswordHasher.Hash(password);

        try
        {
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();

            return Ok(new ResultViewModel<dynamic>(new
            {
                user = user.Email,
                password
            }));
        }
        catch (DbUpdateException)
        {
            return StatusCode(400, new ResultViewModel<string>("05X99 - Este E-mail já está cadastrado"));
        }
        catch (Exception)
        {
            return StatusCode(500, new ResultViewModel<string>("Falha interna no servidor"));
        }
    }
    
    [HttpPost("v1/accounts/login")]
    public async Task<IActionResult> Login(
        [FromBody] LoginViewModel model,
        [FromServices] BlogDataContext context,
        [FromServices] TokenService tokenService)
    {
        if (!ModelState.IsValid)
            return BadRequest(new ResultViewModel<string>(ModelState.GetErrors()));

        var user = await context
            .Users
            .AsNoTracking()
            .Include(x => x.Roles)
            .FirstOrDefaultAsync(x => x.Email == model.Email);
        
        if(user is null)
            return StatusCode(401, new ResultViewModel<string>("E-mail inválido"));

        if(!PasswordHasher.Verify(user.PasswordHash, model.Password)) // Método usado para verificar se a senha batem 
            return StatusCode(401, new ResultViewModel<string>("Senha inválida inválido"));

        try
        {
            var token = tokenService.GenerateToken(user);
            return Ok(new ResultViewModel<string>(token, null));
        }
        catch
        {
            return StatusCode(500, new ResultViewModel<string>("Falha interna no servidor"));
        }
    }
    
    
    
//     [Authorize( Roles = "user")] // Quer dizer que para acessar esse endpoint o Role tem quer ter o user
//     [HttpGet("v1/user")]
//     public IActionResult GetUser() => Ok(User.Identity?.Name);
//
//     [Authorize( Roles = "author")]
//     [HttpGet("v1/author")]
//     public IActionResult GetAuthor() => Ok(User.Identity?.Name);
//     
//     [Authorize( Roles = "admin")]
//     [HttpGet("v1/admin")]
//     public IActionResult GetAdminr() => Ok(User.Identity?.Name);
}