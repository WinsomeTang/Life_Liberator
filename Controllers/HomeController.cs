using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Life_Liberator.Models;
using Life_Liberator.Data;
using Microsoft.EntityFrameworkCore;

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
        return View();
    }

    public IActionResult Dashboard()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult SignUp(User user)
    {
        if (ModelState.IsValid)
        {
            // Additional validation logic (e.g., check for unique username or email)

            // Save user to the database
            _appDbContext.Users.Add(user);
            _appDbContext.SaveChanges();

            // Redirect to the login page or another appropriate page
            return RedirectToAction("ScheduleForm", new { id = user.Id });
        }

        // If ModelState is not valid, return to the signup page with validation errors
        return View(user);
    }

    public IActionResult ScheduleForm(int id)
    {
        // Retrieve the user based on the provided userId
        User user = _appDbContext.Users.Include(u => u.CustomSchedules).FirstOrDefault(u => u.Id == id);

        if (user == null)
        {
            // Handle the case where the user is not found
            return View("UserNotFound"); // Create a UserNotFound view for a better user experience
        }

        return View(user.CustomSchedules);
    }

}
