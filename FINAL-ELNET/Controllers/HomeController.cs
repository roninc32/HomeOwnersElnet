using FINAL_ELNET.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FINAL_ELNET.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        // Add this method to handle Login page requests
        public IActionResult Login()
        {
            return View();
        }

        // Add this method to handle Login form submissions
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult LoginSubmit(string username, string password)
        {
            // For testing purposes
            if (username == "admin" && password == "123")
            {
                return RedirectToAction("HomePage");
            }
            
            return View("Login");
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult HomePage()
        {
            return View();  // This will return the HomePage.cshtml view
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
