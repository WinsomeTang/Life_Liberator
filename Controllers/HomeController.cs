using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Life_Liberator.Models;
using Life_Liberator.Data;
using Microsoft.EntityFrameworkCore;


namespace Life_Liberator.Controllers;

public class HomeController : Controller
{
    private readonly AppDbContext _appDbContext;
    private readonly IConfiguration _configuration;

    public HomeController(AppDbContext appDbContext, IConfiguration configuration)
    {
        _appDbContext = appDbContext;
        _configuration = configuration;
    }


    public IActionResult Index()
    {
        return View();
    }

    public IActionResult SignUp()
    {
        return View();
    }



    public IActionResult OfferProjects()
    {
        return View();
    }

    [HttpPost]
    public IActionResult SignUp(User user, string[] startTime, string[] endTime)
    {
        try
        {
            // Save user details to the database
            if (ModelState.IsValid)
            {
                // Convert time entries to a single string and assign to the Schedule property
                user.Schedule = CombineTimeBlocks(startTime, endTime).ToString();

                // Add user to the database
                _appDbContext.Users.Add(user);
                _appDbContext.SaveChanges();


                // Store UserId and FirstName in session
                HttpContext.Session.SetInt32("UserId", user.UserId);
                HttpContext.Session.SetString("FirstName", user.FirstName);

                // Redirect to OfferProjects.cshtml
                return RedirectToAction("OfferProjects", new { userId = user.UserId });
            }

            // If ModelState is not valid, return to the SignUp page
            return View("SignUp", user);
        }
        catch (Exception ex)
        {
            // Log the exception
            Console.WriteLine($"Exception: {ex.Message}");
            return View("Error"); // Handle the exception gracefully in your application
        }
    }

    [HttpGet]
    public IActionResult OfferProjects(int userId)
    {
        // Retrieve the user from the database using userId
        var user = _appDbContext.Users.Find(userId);

        if (!ModelState.IsValid)
        {
            // Log ModelState errors
            foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
            {
                Console.WriteLine($"ModelState error: {error.ErrorMessage}");
            }

            // If ModelState is not valid, return to the SignUp page
            return View("SignUp", user);
        }

        // Check if the user is found
        if (user == null)
        {
            // Handle the case when the user is not found
            return RedirectToAction("SignUp");
        }

        // Pass the user to the view
        return View(user);
    }


    private string CombineTimeBlocks(string[] startTimes, string[] endTimes)
    {
        List<string> timeBlocks = new List<string>();

        for (int i = 0; i < startTimes.Length; i++)
        {
            timeBlocks.Add($"{startTimes[i]}-{endTimes[i]}");
        }

        return string.Join("|", timeBlocks);
    }

    public IActionResult SignIn(string email, string password)
    {
        if (ModelState.IsValid)
        {
            // Check if there's a user with the provided email and password
            var authenticatedUser = _appDbContext.Users.FirstOrDefault(u => u.Email == email && u.Password == password);

            if (authenticatedUser != null)
            {
                Console.WriteLine($"Found user: {authenticatedUser.UserId}, {authenticatedUser.Email}");

                // Store UserId and FirstName in session
                HttpContext.Session.SetInt32("UserId", authenticatedUser.UserId);
                HttpContext.Session.SetString("FirstName", authenticatedUser.FirstName);



                return RedirectToAction("Dashboard");

            }

            // If not authenticated, display an error message
            ViewBag.ErrorMessage = "Invalid email or password.";
        }
        return View();
    }

    public IActionResult Dashboard()
    {
        var userId = HttpContext.Session.GetInt32("UserId") ?? 0;
        var firstName = HttpContext.Session.GetString("FirstName") ?? "User";

        // Fetch user details from the database
        var user = _appDbContext.Users.FirstOrDefault(u => u.UserId == userId);

        if (user != null)
        {
            ViewBag.UserId = user.UserId;
            ViewBag.FirstName = user.FirstName;
            // Add other properties as needed
        }
        else
        {
            // Handle the case where the user is not found
            ViewBag.UserId = 0;
            ViewBag.FirstName = "User";
        }

        return View();
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

