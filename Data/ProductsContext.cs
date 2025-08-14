using Microsoft.EntityFrameworkCore;
using ManageInventoryNET.Model;

namespace ManageInventoryNET.Data;

public class ProductContext : DbContext
{
    public ProductContext(DbContextOptions<ProductContext> options)
    : base(options)
    {
    }


    public DbSet<ManageInventoryNET.Model.Product> Products { get; set; }
    public DbSet<ManageInventoryNET.Model.Category> Categories { get; set; }
}