using BGTest.Core.Entities;
using BGTest.Core.Repositories;
using BGTest.Core.Views;
using BGTest.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BGTest.Infrastructure.Persistence.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _dbContext;

    public ProductRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<List<Product>> GetAllAsync()
    {
        return await _dbContext.Products.ToListAsync();
    }

    public async Task<List<ProductBatchView>> SearchByParamAsync(string? searchTerm, int pageNumber = 1, int pageSize = 10)
    {
        var query = _dbContext.ProductBatchesView.AsQueryable();

        if (!string.IsNullOrWhiteSpace(searchTerm))
        {
            if (int.TryParse(searchTerm, out int productId))
            {
                // If searchParam is a number, filter by ProductId
                query = query.Where(pb => pb.ProductId == productId);
            }
            else
            {
                // Otherwise, filter by BatchNumber
                query = query.Where(pb => pb.BatchNumber.Contains(searchTerm));
            }
        }

        return await query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task<Product?> GetByIdAsync(int id)
    {
        return await _dbContext.Products.FindAsync(id);
    }

    public async Task<Product> CreateAsync(Product product)
    {
        await _dbContext.Products.AddAsync(product);
        var result = await _dbContext.SaveChangesAsync();
        return result > 0 ? product : null;
    }

    public async Task<Product> UpdateAsync(Product product)
    {
        _dbContext.Products.Update(product);
        var result = await _dbContext.SaveChangesAsync();
        return result > 0 ? product : null;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var product = await _dbContext.Products.FindAsync(id);
        if(product == null) return false;
        _dbContext.Products.Remove(product);
        await _dbContext.SaveChangesAsync();
        return true;
    }
}