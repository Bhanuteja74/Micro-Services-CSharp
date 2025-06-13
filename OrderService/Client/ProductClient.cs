public record Product(int Id, string Name, double Price);
public class ProductClient
{
    private readonly HttpClient _client;

    public ProductClient(HttpClient client)
    {
        _client = client;
    }
    
    public async Task<Product?> GetProductById(int id)
    {
        var response = await _client.GetAsync($"http://localhost:5000/Product/{id}");

        Console.WriteLine(response);
        if (!response.IsSuccessStatusCode)
            return null;

        var product = await response.Content.ReadFromJsonAsync<Product>();
        return new Product(product.Id, product.Name, product.Price);
    }
}