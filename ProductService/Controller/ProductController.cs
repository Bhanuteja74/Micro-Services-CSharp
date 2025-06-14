using Microsoft.AspNetCore.Mvc;
using ProductService.Models;
using ProductService.Services;

namespace ProductService.Controller;
/// <summary>
/// This controller handles product-related operations such as retrieving all products,
/// </summary>

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    /// <summary>
    /// GetAll method retrieves all products.
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public IActionResult GetAll() => Ok(_productService.GetAll());

    [HttpPost]
    public IActionResult Add(Product product)
    {
        _productService.Add(product);
        return Ok();
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var product = _productService.GetById(id);
        return product is null ? NotFound() : Ok(product);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        return _productService.Delete(id) ? Ok() : NotFound();
    }
}
