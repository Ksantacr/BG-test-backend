using BGTest.Application.DTOs;
using BGTest.Application.Services.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BGtest.API.Controllers;

[ApiController]
[Route("api/products")]
[Authorize]
public class ProductController: ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetAllProducts()
    {
        var products = await _productService.GetAllProducts();
        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetProductById(int id)
    {
        var product = await _productService.GetProductById(id);
        if (product.Value == null)
        {
            return NotFound();
        }
        return Ok(product);
    }
    
    [HttpPost("batch-number")]
    public ActionResult RegisterProductWithBatchNumber([FromBody] RegisterProductWithBatchNumberDto registerProductWithBatchNumberDto)
    {
        return Ok();
    }

    
    [HttpPost("search")]
    public async Task<ActionResult> SearchBy(string? searchTerm, int page = 1, int pageSize = 10)
    {
        var result = await _productService.SearchProductsByTerm(searchTerm, page, pageSize);
        if (!result.Succeeded)
        {
            return BadRequest("Failed searching for products");
        }
        
        return Ok(result.Value);
    }

    [HttpPost]
    public async Task<ActionResult> CreateProduct([FromBody] CreateProductRequestDto model)
    {
        var createdProduct = await _productService.CreateProduct(model);
        if (!createdProduct.Succeeded)
        {
            return BadRequest("Failed to create product");
        }
        return CreatedAtAction(nameof(GetProductById), new { id = createdProduct.Value.Id }, createdProduct);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduct(int id, [FromBody] UpdateProductRequestDto model)
    {
        var result = await _productService.UpdateProduct(id, model);
        if (!result.Succeeded)
        {
            return BadRequest("Failed to updating product");
        }
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        var result = await _productService.DeleteProduct(id);
        if (!result.Succeeded)
        {
            return BadRequest("Failed to deleting product");
        }
        return NoContent();
    }
    
}