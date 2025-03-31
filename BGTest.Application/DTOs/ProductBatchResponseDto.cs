using BGTest.Core.Views;

namespace BGTest.Application.DTOs;

public class ProductBatchResponseDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string BatchNumber { get; set; }
    public double Price { get; set; }
    public DateTime Registered { get; set; }
    
    public static ProductBatchResponseDto ProductBatchToDto(ProductBatchView product) => new()
        { Id = product.ProductId, Description = product.ProductDescription, Name = product.ProductName, Price = product.Price, BatchNumber = product.BatchNumber, Registered = product.Registered};
}