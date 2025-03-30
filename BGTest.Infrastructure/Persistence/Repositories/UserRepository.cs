using BGTest.Core.Entities;
using BGTest.Core.Repositories;
using BGTest.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BGTest.Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _dbContext;

    public UserRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<User?> RegisterUserAsync(User model)
    {
        _dbContext.Users.Add(model);
        var result = await _dbContext.SaveChangesAsync();
        return result > 0 ? model : null;
    }

    public async Task<User?> GetUserByEmailAsync(string email)
    {
        return await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
    }
}