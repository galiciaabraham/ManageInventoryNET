using Microsoft.EntityFrameworkCore;
using ManageInventoryNET.Models.Entities;

namespace ManageInventoryNET.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

    }
}
// This class represents the application's database context.
// It inherits from DbContext and provides access to the database.
// The Users DbSet represents the collection of User entities in the database.
