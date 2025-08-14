using ManageInventoryNET.Data;
using ManageInventoryNET.Models.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ManageInventoryNET.Controllers
{
    [Route("api/[controller]")] // AuthController
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _dbContext; // Database context for user management

        public AuthController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //logout function 
        [HttpGet("/logout")]
        //logs out the current user and redirects to the login page
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/login");
        }

        //login function
        // logs in user and sets cookies 
        // if user not found or password incorrect, return unauthorized
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromForm] LoginViewModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Username) && string.IsNullOrWhiteSpace(model.Password))
            {
                return Redirect("/login?errorMessage=" + Uri.EscapeDataString("Username and password are required."));
            }
            if (!ModelState.IsValid)
            {
                var error = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .FirstOrDefault() ?? "Invalid input.";

                return Redirect("/login?errorMessage=" + Uri.EscapeDataString(error));
            }

            var user = _dbContext.Users.FirstOrDefault(u => u.Username == model.Username);

            if (user == null || !BCrypt.Net.BCrypt.Verify(model.Password, user.PasswordHash))
            {
                return Redirect("/login?errorMessage=" + Uri.EscapeDataString("Invalid username or password."));
            }

            var claims = new List<Claim>
    {
        new Claim(ClaimTypes.Name, user.Username ?? string.Empty),
        new Claim(ClaimTypes.Role, user.Role ?? "User")
    };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                principal,
                new AuthenticationProperties
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTime.UtcNow.AddMinutes(10)
                });

            return Redirect("/");
        }




        // Verifies the user's password
        // verifies the password against the stored hash
        private bool VerifyPassword(string password, string passwordHash)
        {
            return BCrypt.Net.BCrypt.Verify(password, passwordHash);
        }
    }
}
