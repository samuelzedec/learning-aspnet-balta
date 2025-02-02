using Microsoft.AspNetCore.Mvc;
using WebBlog.Attributes;

namespace WebBlog.Controllers;

[ApiController]
[Route("/")]
public class HomeController : ControllerBase
{
    [HttpGet("")]
    public IActionResult Get(
        [FromServices] IConfiguration config)
    {
        var env = config.GetValue<string>("Env");
        return Ok(new
        {
            Enviroment = env
        }); //health-check
    }
}