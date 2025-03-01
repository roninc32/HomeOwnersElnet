namespace HomeOwners.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class RegisterModel : PageModel
{
    [BindProperty]
    public string Username { get; set; }

    [BindProperty]
    public string Password { get; set; }

    [BindProperty]
    public string ConfirmPassword { get; set; }

    public string Message { get; set; }

    public void OnGet()
    {
    }

    public IActionResult OnPost()
    {
        if (Password != ConfirmPassword)
        {
            Message = "Passwords do not match!";
            return Page();
        }

        // TODO: Implement actual registration logic (e.g., save the user to the database)
        Message = "Registration successful!";

        // Redirect to login page after successful registration
        return RedirectToPage("/User/Login");
    }
}
