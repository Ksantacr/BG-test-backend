using BGTest.Core.Entities;

namespace BGTest.Application.DTOs;

public class ProductDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    
    public static ProductDto ProductToDto(Product post) => new()
        { Id = post.Id, Description = post.Description, Name = post.Name };
}