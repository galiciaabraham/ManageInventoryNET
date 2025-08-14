using System.ComponentModel.DataAnnotations;

namespace ManageInventoryNET.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        public string? Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        public string? ConfirmPassword { get; set; }

        [Required]
        public string? Role { get; set; }
    }
}
// This class is used for user registration.
// It contains properties for the user's username, password, confirm password, and role.