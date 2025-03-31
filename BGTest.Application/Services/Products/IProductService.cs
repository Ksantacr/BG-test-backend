using BGTest.Application.DTOs;
using BGTest.Application.OperationResult;
using BGTest.Core.Entities;

namespace BGTest.Application.Services.Products;

public interface IProductService
{
    Task<Result<IEnumerable<ProductDto>>> GetAllProducts();
    Task<Result<IEnumerable<ProductBatchResponseDto>>> SearchProductsByTerm(string? term, int pageNumber, int pageSize);
    Task<Result<ProductDto?>> GetProductById(int id);
    Task<Result<ProductDto?>> CreateProduct(CreateProductRequestDto model);
    Task<Result<ProductDto>> UpdateProduct(int id, UpdateProductRequestDto model);
    Task<Result<ProductDto>> DeleteProduct(int id);
}