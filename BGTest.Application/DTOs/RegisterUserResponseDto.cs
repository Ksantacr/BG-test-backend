using BGTest.Core.Entities;

namespace BGTest.Application.DTOs;

public class RegisterUserResponseDto
{
    // [NotMapped]
    // public int Id { get; set; }
    public string? FirstName { get; set; }
    public string Email { get; set; }
    
    public static RegisterUserResponseDto UserToDto(User user) => new()
        { Email = user.Email, FirstName = user.FirstName };
}