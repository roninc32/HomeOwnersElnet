using FINAL_ELNET.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FINAL_ELNET.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        // POST: Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                // In a real application, this is where you would:
                // 1. Check if the username/email already exists
                // 2. Hash the password
                // 3. Save the user to the database
                // 4. Potentially send a confirmation email
                
                // For demonstration purposes, we'll just redirect to success
                TempData["SuccessMessage"] = "Registration successful! You can now log in.";
                return RedirectToAction("Login", "Home");
            }

            // If validation fails, return the form with validation errors
            return View(model);
        }
    }
}
