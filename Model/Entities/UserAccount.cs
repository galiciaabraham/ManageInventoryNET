using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManageInventoryNET.Models.Entities;

public class UserAccount
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int? Id { get; set; }

    [Required]
    [StringLength(100)]
    public string? Username { get; set; }

    [Required]
    [StringLength(100)]
    public string? PasswordHash { get; set; }


}
// This class represents a user account in the application.
// It contains properties for the account's ID, username, and password hash.
// The PasswordHash is used for secure password storage.