using Microsoft.AspNetCore.Mvc;
using WebBlog.Attributes;

namespace WebBlog.Controllers;

[ApiController]
[Route("/")]
public class HomeController : ControllerBase
{
    [HttpGet("")]
    [ApiKey]
    public IActionResult Get()
    {
        return Ok(); //health-check
    }
}