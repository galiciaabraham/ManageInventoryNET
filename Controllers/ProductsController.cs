using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ManageInventoryNET.Data;

namespace Products.Controllers;

[Route("products")]
[ApiController]
public class ProductsController : Controller
{
    private readonly ProductContext _db;

    public ProductsController(ProductContext db)
    {
        _db = db;
    }
    [HttpGet]
    public async Task<ActionResult<List<ManageInventoryNET.Model.Product>>> GetProducts()
    {
        return (await _db.Products.ToListAsync()).ToList();
    }

    [HttpGet("paged")]
    public async Task<ActionResult<PagedResult<ManageInventoryNET.Model.Product>>> GetProductsPaged([FromQuery] int startIndex = 0, [FromQuery] int count = 10)
    {
        var totalCount = await _db.Products.CountAsync();
        var items = await _db.Products.Include(p=>p.Category).OrderBy(i => i.Id).Skip(startIndex).Take(count).ToListAsync();

       
        return new PagedResult<ManageInventoryNET.Model.Product>
        {
            Items = items,
            TotalCount = totalCount
        };
    }
}

public class PagedResult<T>
{
    public List<T> Items { get; set; } = new();
    public int TotalCount { get; set; }
}