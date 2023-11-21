using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Life_Liberator.Models;
using Life_Liberator.Data;

namespace Life_Liberator.Controllers;

public class HomeController : Controller
{
    private readonly AppDbContext _appDbContext;
    public HomeController(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }


    public IActionResult Index()
    {
        return View();
    }

    public IActionResult SignUp()
    {
        return View(); // Assuming you have a corresponding SignUp.cshtml view
    }

    public IActionResult SignIn()
    {
        return View(); // Assuming you have a corresponding SignUp.cshtml view
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

