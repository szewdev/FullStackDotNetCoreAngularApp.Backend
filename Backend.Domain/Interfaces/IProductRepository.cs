using Backend.Domain.Entities;

namespace Backend.Domain.Interfaces;

public interface IProductRepository
{
    Task<Product?> GetProductByIdAsync(int? id);
    Task<IEnumerable<Product>> GetAllProducts();
    Task AddProductAsync(Product product);
    void UpdateProduct(Product product);
    Task SaveChangesAsync();
}
