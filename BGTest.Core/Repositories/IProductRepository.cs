using BGTest.Core.Entities;

namespace BGTest.Core.Repositories;

public interface IProductRepository
{
    Task<List<Product>> GetAllAsync();
    // Search by batch number or product name
    Task<Product?> GetByIdAsync(int id);
    Task<Product> CreateAsync(Product product);
    Task<Product> UpdateAsync(Product product);
    Task<bool> DeleteAsync(int id);
}