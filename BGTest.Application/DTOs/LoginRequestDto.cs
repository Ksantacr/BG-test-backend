using System.ComponentModel.DataAnnotations;

namespace BGTest.Application.DTOs;

public class LoginRequestDto
{
    [Required]
    [EmailAddress]
    public required string Email { get; set; }
    [Required]
    public required string Password { get; set; }
}