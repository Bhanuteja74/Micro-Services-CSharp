using ProductService.Models;

namespace ProductService.Services;

public class ProductService : IProductService
{
    public List<Product> Products { get; set; } =
    [
        new Product(1, "Laptop", 999.99m, 10, "Electronics"),
        new Product(2, "Monitor", 99.99m, 10, "Electronics"),
        new Product(3, "Apple", 0.99m, 100, "Groceries")
    ];


    public List<Product> GetAll()
    {
        return Products.ToList();
    }

    public Product? GetById(int id)
    {
        return Products.FirstOrDefault(product => product.Id == id);
    }

    public void Add(Product product)
    {
        if (product == null)
        {
            throw new ArgumentNullException(nameof(product), "Product cannot be null");
        }

        if (Products.Any(p => p.Id == product.Id))
        {
            throw new InvalidOperationException($"Product with ID {product.Id} already exists.");
        }

        Products.Add(product);
    }

    public bool Delete(int id)
    {
        var product = GetById(id);
        if (product == null)
        {
            return false; 
        }

        Products.Remove(product);
        return true; 
    }
}