using System.ComponentModel.DataAnnotations.Schema;

namespace BGTest.Core.Entities;

[Table("products")]
public class Product
{
    [Column("id")]
    public int Id { get; set; }
    [Column("name")]
    public string Name { get; set; }
    [Column("description")]
    public string? Description { get; set; }
}