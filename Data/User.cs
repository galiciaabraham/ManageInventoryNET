public class User
{
    public int Id { get; set; }
    public string? Username { get; set; }
    public string? PasswordHash { get; set; }
    public string? Role { get; set; } // e.g., "Admin", "User"
}
// This class represents a user in the application.
// It contains properties for the user's ID, username, password hash, and role.
// The PasswordHash is used for secure password storage.