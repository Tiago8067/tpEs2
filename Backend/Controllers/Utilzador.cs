using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

public class Utilzador : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}