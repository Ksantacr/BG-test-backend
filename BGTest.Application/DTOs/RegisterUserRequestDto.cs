using System.ComponentModel.DataAnnotations;
using BGTest.Core.Entities;

namespace BGTest.Application.DTOs;

public class RegisterUserRequestDto
{
    [Required]
    public string FirstName { get; set; }
    public string? LastName { get; set; }
    [Required]
    public string Password { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    public User DtoToUser(string passwordHash) => new()
        { Email = Email, FirstName = FirstName, LastName = LastName, PasswordHash = passwordHash };
}