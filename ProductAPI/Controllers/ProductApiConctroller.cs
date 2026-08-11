using Microsoft.AspNetCore.Mvc;
using ProductAPI.Models;

namespace ProductAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductApiController : ControllerBase
{
    private static List<Product> _products = new()
    {
        new()
        {
            Id = 1,
            Name = "Laptop",
            Price = 85000
        },
        new()
        {
            Id = 2,
            Name = "Mouse",
            Price = 1500
        },
        new()
        {
            Id = 1,
            Name = "Keyboard",
            Price = 3000
        },
    };

    [HttpGet]
    public IActionResult GetProducts()
    {
        return Ok(_products);
    }

    [HttpGet("{id}")]
    public IActionResult GetProduct(int id)
    {
        var product = _products.FirstOrDefault(x => x.Id == id);
        if (product is null)
            return NotFound("Product Not found");
        return Ok(product);
    }
}