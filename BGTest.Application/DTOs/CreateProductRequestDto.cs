using System.ComponentModel.DataAnnotations;
using BGTest.Core.Entities;

namespace BGTest.Application.DTOs;

public class CreateProductRequestDto
{
    [Required] public string Name { get; set; }
    public string? Description { get; set; }
    
    public static Product DtoToProduct(CreateProductRequestDto post) => new()
        { Name = post.Name, Description = post.Description };
}

public class UpdateProductRequestDto : CreateProductRequestDto
{
}