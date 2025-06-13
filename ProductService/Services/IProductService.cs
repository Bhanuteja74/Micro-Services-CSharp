namespace ProductService.Services;
using Models;

public interface IProductService
{
    List<Product> GetAll();
    Product? GetById(int id);
    void Add(Product product);
    bool Delete(int id);
}
