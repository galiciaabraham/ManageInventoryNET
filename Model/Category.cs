using System .ComponentModel.DataAnnotations;
namespace ManageInventoryNET.Model;
using System.Text.Json.Serialization;


public class Category
{
    public int Id { get; set; }

    [Required(ErrorMessage = "The name us required")]
    [StringLength(100, ErrorMessage ="Name category is too long")]
    public string? Name { get; set; }

    // relationship. One category can have many products
    [JsonIgnore]
    public List<Product>? Products { get; set; }
}
