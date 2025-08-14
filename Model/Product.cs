using System.ComponentModel.DataAnnotations;

namespace ManageInventoryNET.Model;

public class Product
{
    public int Id { get; set; }

    [Required(ErrorMessage = "The name is required")]
    [StringLength(100, ErrorMessage ="Name product is too long")]

    public string? Name { get; set; }
    
    [Required(ErrorMessage = "Category is requiredasassaas.")]
    public int CategoryId { get; set; }

  
    public Category? Category { get; set; }

    [Required(ErrorMessage = "Quantity is required")]
    [RegularExpression(@"^\d+$", ErrorMessage = "Should be a positive integer")]    
    public string? Quantity { get; set; }

    [Required(ErrorMessage = "Price is required")]
    [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "Should be a number | Should be positive | accept 2 decimals")]
    public string? Price { get; set; }
}