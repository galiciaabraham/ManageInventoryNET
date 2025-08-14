namespace ManageInventoryNET.Data;

using ManageInventoryNET.Model;

public static class SeedData
{
    public static void Initialize(ProductContext db)
    {
        var paintCategory = new Category { Name = "Paint" };

        if (!db.Categories.Any())
        {
            db.Categories.Add(paintCategory);
            db.SaveChanges();
        }

        var products = new Product[]
        {
            new Product()
            {
                Name = "Soft Touch Brush",
                Category = paintCategory,
                Quantity = "520",
                Price = "18.00"
            },
            new Product()
            {
                Name = "Velvet Shader",
                Category = paintCategory,
                Quantity = "300",
                Price = "15.50"
            },
            new Product()
            {
                Name = "Pro Line Brush",
                Category = paintCategory,
                Quantity = "450",
                Price = "22.00"
            },
            new Product()
            {
                Name = "UltraSmooth Brush",
                Category = paintCategory,
                Quantity = "275",
                Price = "19.75"
            },
            new Product()
            {
                Name = "Detail Pro Brush",
                Category = paintCategory,
                Quantity = "600",
                Price = "17.20"
            },
            new Product()
            {
                Name = "Finisher Brush XL",
                Category = paintCategory,
                Quantity = "340",
                Price = "21.00"
            },
            new Product()
            {
                Name = "Blender Pro Brush",
                Category = paintCategory,
                Quantity = "500",
                Price = "20.00"
            },
            new Product()
            {
                Name = "ContourEdge Brush",
                Category = paintCategory,
                Quantity = "410",
                Price = "16.80"
            },
            new Product()
            {
                Name = "FlatTop Kabuki",
                Category = paintCategory,
                Quantity = "390",
                Price = "23.50"
            },
            new Product()
            {
                Name = "Angled Buffer Brush",
                Category = paintCategory,
                Quantity = "310",
                Price = "19.00"
            },
        };
        db.Products.AddRange(products);
        db.SaveChanges();
    }
}