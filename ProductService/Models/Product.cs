namespace ProductService.Models;

public class Product(int id, string name, decimal price, int quantity, string category)
{

    public int Id { get; set; } = id;
    public string Name { get; set; } = name;
    public decimal Price { get; set; } = price;
    public int Quantity { get; set; } = quantity;
    public string Category { get; set; } = category;
}