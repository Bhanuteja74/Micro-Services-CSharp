using System.Text.Json;

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

        
        
        if (!response.IsSuccessStatusCode)
            return null;
        // one way to deserialize the response using System.Text.Json
        // another way is to use Newtonsoft.Json
        
        var content = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<Product>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });



        // var product = await response.Content.ReadFromJsonAsync<Product>();
        // return product;
    }
}