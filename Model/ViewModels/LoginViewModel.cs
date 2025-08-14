using System.ComponentModel.DataAnnotations;

namespace ManageInventoryNET.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Username is required.")]
        public string? Username { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required.")]
        public string? Password { get; set; }
    }
}
 // This class is used for user login.
 // It contains properties for the user's username and password.