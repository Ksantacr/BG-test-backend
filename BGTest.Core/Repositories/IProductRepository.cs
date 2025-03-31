using BGTest.Core.Entities;
using BGTest.Core.Views;

namespace BGTest.Core.Repositories;

public interface IProductRepository
{
    Task<List<Product>> GetAllAsync();
    // Search by batch number or product name
    Task<List<ProductBatchView>> SearchByParamAsync(string? searchTerm, int pageNumber = 1, int pageSize = 10);
    Task<Product?> GetByIdAsync(int id);
    Task<Product> CreateAsync(Product product);
    Task<Product> UpdateAsync(Product product);
    Task<bool> DeleteAsync(int id);
}