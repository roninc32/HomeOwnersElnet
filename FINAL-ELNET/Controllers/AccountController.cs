using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using FINAL_ELNET.Models;

namespace FINAL_ELNET.Controllers
{
    public class AccountController : Controller
    {
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                // In a real application, you would:
                // 1. Check if the username/email already exists
                // 2. Hash the password
                // 3. Save the user to the database
                // 4. Potentially send a confirmation email
                
                // For demonstration purposes, we'll just redirect to login with a success message
                TempData["SuccessMessage"] = "Registration successful! You can now log in.";
                return RedirectToAction("Login", "Home");
            }

            // If validation fails, return to the registration form with errors
            return View("~/Views/Home/Register.cshtml", model);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            try
            {
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                
                // Clear any existing cookies
                foreach (var cookie in Request.Cookies.Keys)
                {
                    Response.Cookies.Delete(cookie);
                }
                
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                // Ensure cookies are still cleared even if sign out fails
                foreach (var cookie in Request.Cookies.Keys)
                {
                    Response.Cookies.Delete(cookie);
                }

                // Add error message for the user
                TempData["Error"] = "An error occurred during logout. You have been redirected to the home page.";
                
                // You should log the actual exception here using your logging framework
                // Example: _logger.LogError(ex, "Error during logout");
                
                return RedirectToAction("Index", "Home");
            }
        }
    }
}