using BGTest.Application.DTOs;
using BGTest.Application.OperationResult;
using BGTest.Core.Entities;
using BGTest.Core.Repositories;

namespace BGTest.Application.Services.Products;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Result<IEnumerable<ProductDto>>> GetAllProducts()
    {
        var result = await _productRepository.GetAllAsync();
        return Result<IEnumerable<ProductDto>>.Success(result.Select(ProductDto.ProductToDto));
    }

    public async Task<Result<ProductDto?>> GetProductById(int id)
    {
        var result = await _productRepository.GetByIdAsync(id);
        if (result is null)
        {
            return Result<ProductDto?>.Failure();
        }

        return Result<ProductDto?>.Success(ProductDto.ProductToDto(result));
        
    }

    public async Task<Result<ProductDto?>> CreateProduct(CreateProductRequestDto model)
    {
        var product = CreateProductRequestDto.DtoToProduct(model);
        var result = await _productRepository.CreateAsync(product);
        if (result is null)
        {
            return Result<ProductDto?>.Failure();
        }

        return Result<ProductDto?>.Success(ProductDto.ProductToDto(result));
    }

    public async Task<Result<ProductDto>> UpdateProduct(int id, UpdateProductRequestDto model)
    {
        var product = CreateProductRequestDto.DtoToProduct(model);
        product.Id = id;
        var result = await _productRepository.UpdateAsync(product);
        if (result is null)
        {
            return Result<ProductDto>.Failure();
        }

        return Result<ProductDto>.Success(ProductDto.ProductToDto(product));
    }

    public async Task<Result<ProductDto>> DeleteProduct(int id)
    {
        var result = await _productRepository.DeleteAsync(id);
        if (!result)
        {
            return Result<ProductDto>.Failure();
        }

        return Result<ProductDto>.Success(new ProductDto() { Id = id });
    }
}