namespace HomeOwners.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class LoginModel : PageModel
{
    [BindProperty]
    public string Username { get; set; }

    [BindProperty]
    public string Password { get; set; }

    public void OnGet()
    {
    }

    // Handle login submission
    public IActionResult OnPostLogin()
    {
        if (Username == "admin" && Password == "password")
        {
            return RedirectToPage("/Index");
        }
        return Page();
    }

    // Handle register button submission (navigate to the register page)
    public IActionResult OnPostRegister()
    {
        // Redirect to the register page
        return RedirectToPage("/Views/Home/Register.cshtml"); // Adjust to the actual register page route
    }
}
