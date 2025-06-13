using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class OrderService : ControllerBase
{
    private readonly ProductClient _client;

    public OrderService(ProductClient client)
    {
        _client = client;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProduct(int id)
    {
        var product = await _client.GetProductById(id);
        
        if(product == null) return NotFound("Product not found");
        
        return Ok(new {Message = "Order Placed...", Product = product});
    }
}