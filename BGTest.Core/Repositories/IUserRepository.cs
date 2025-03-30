using BGTest.Core.Entities;

namespace BGTest.Core.Repositories;

public interface IUserRepository
{
    Task<User?> RegisterUserAsync(User model);
    Task<User?> GetUserByEmailAsync(string email);
}