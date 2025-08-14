namespace ManageInventoryNET.Data
{
    public static class DbInitializer
    {
        public static void Seed(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            context.Database.EnsureCreated();

            if (!context.Users.Any())
            {
                var user = new User
                {
                    Username = "admin",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("password"),
                    Role = "Admin",
                };

                context.Users.Add(user);
                context.SaveChanges();
            }
        }
    }
}
// This class is responsible for initializing the database with default data.
// It checks if the database is empty and seeds it with an admin user if necessary.