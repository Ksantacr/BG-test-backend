using BGTest.Core.Entities;
using BGTest.Core.Repositories;
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