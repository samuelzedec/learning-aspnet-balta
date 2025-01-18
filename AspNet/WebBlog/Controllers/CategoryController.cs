using Microsoft.AspNetCore.Mvc;

namespace WebBlog.Controllers;

public class CategoryController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}