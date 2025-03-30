using BGTest.Application.DTOs;

namespace BGTest.Application.Services.TokenHandler;

public interface ITokenHandler
{
    string CreateJWTToken(UserByEmailDto user);
}