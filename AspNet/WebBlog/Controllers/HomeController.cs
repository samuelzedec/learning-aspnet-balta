using Microsoft.AspNetCore.Mvc;
namespace WebBlog.Controllers;

[ApiController]
[Route("/")]
public class HomeController : ControllerBase
{
    [HttpGet("")]
    public IActionResult Get()
        => Ok(); //health-check
}