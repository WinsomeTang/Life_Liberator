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


    public IActionResult ScheduleForm()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult SignUp(User user)
    {
        if (ModelState.IsValid)
        {
            // Save user to the database
            _appDbContext.Users.Add(user);
            Console.WriteLine($"User {user.FirstName} {user.LastName} signed up successfully.");


            _appDbContext.SaveChanges();
            Console.WriteLine($"User {user.FirstName} {user.LastName} signed up successfully.");
            Console.WriteLine($"User has id: {user.UserId}");
            var schedule = new Schedule { UserId = user.UserId };
            Console.WriteLine($"User has id: {user.UserId}");
            // Redirect to the schduleform page or another appropriate page
            return RedirectToAction("ScheduleForm", schedule);
        }

        // If ModelState is not valid, return to the signup page with validation errors
        return View(user);
    }

    [HttpPost]
    public IActionResult ScheduleForm(int userId, Schedule schedule, List<string> additionalStartTimes, List<string> additionalEndTimes)
    {
        if (ModelState.IsValid)
        {
            // Clear existing schedules for the user (optional, based on your logic)
            var existingSchedules = _appDbContext.CustomSchedule.Where(s => s.UserId == userId).ToList();
            _appDbContext.CustomSchedule.RemoveRange(existingSchedules);

            // Loop through the provided start and end times to create timeslots
            for (int i = 0; i < additionalStartTimes.Count; i++)
            {
                string startTime = additionalStartTimes[i];
                string endTime = additionalEndTimes[i];

                // Create a new schedule for each timeslot
                var newSchedule = new Schedule
                {
                    UserId = userId,
                    dayOfWeek = schedule.dayOfWeek,
                    StartTime = startTime,
                    EndTime = endTime,
                    // Auto-increment TimeBlockId based on the number of timeslots
                    TimeBlockId = i + 1 // +1 because indexing starts from 0
                };

                // Save schedule to the database
                _appDbContext.CustomSchedule.Add(newSchedule);
            }

            _appDbContext.SaveChanges();

            // Redirect to another page or take further action
            return RedirectToAction("Index");
        }

        // If ModelState is not valid, return to the schedule form page with validation errors
        ViewBag.UserId = userId; // Pass the user's ID to the view
        return View(schedule);
    }


    public IActionResult SignIn()
    {
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

