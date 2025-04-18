using BGTest.Core.Entities;

namespace BGTest.Application.DTOs;

public class UserByEmailDto
{
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string Email { get; set; }
    public static UserByEmailDto UserToDto(User user) => new()
        { Email = user.Email, FirstName = user.FirstName, LastName = user.LastName, Id = user.Id };
}