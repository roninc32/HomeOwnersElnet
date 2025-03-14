using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace FINAL_ELNET.Controllers
{
    public class AccountController : Controller
    {
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