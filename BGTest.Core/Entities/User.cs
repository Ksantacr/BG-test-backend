using System.ComponentModel.DataAnnotations.Schema;

namespace BGTest.Core.Entities;

[Table("users")]
public class User
{
    [Column("id")]
    public int Id { get; set; }
    [Column("firstname")]
    public string FirstName { get; set; }
    [Column("lastname")]
    public string? LastName { get; set; }
    [Column("email")]
    public string Email { get; set; }
    [Column("password_hash")]
    public string PasswordHash { get; set; }
}