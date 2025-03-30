using BGTest.Application.DTOs;
using BGTest.Application.OperationResult;

namespace BGTest.Application.Services.User;

public interface IUserService
{
    Task<Result<RegisterUserResponseDto>> RegisterUserAsync(RegisterUserRequestDto model);
    Task<UserByEmailDto?> GetUserByEmailAsync(string email);
    Task<bool> IsValidPassword(string email, string password);
}