using BGTest.Application.DTOs;
using BGTest.Application.Services.Products;
using Microsoft.AspNetCore.Mvc;

namespace BGtest.API.Controllers;

[ApiController]
[Route("api/products")]
//[Authorize]
public class ProductController: ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetAllPosts()
    {
        var products = await _productService.GetAllProducts();
        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductDto>> GetPostById(int id)
    {
        var product = await _productService.GetProductById(id);
        if (product == null)
        {
            return NotFound();
        }
        return Ok(product);
    }

    [HttpPost]
    public async Task<ActionResult<ProductDto>> CreatePost([FromBody] CreateProductRequestDto model)
    {
        var createdProduct = await _productService.CreateProduct(model);
        if (!createdProduct.Succeeded)
        {
            return BadRequest("Failed to create product");
        }
        return CreatedAtAction(nameof(GetPostById), new { id = createdProduct.Value.Id }, createdProduct);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePost(int id, [FromBody] UpdateProductRequestDto model)
    {
        var result = await _productService.UpdateProduct(id, model);
        if (!result.Succeeded)
        {
            return BadRequest("Failed to updating product");
        }
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePost(int id)
    {
        var result = await _productService.DeleteProduct(id);
        if (!result.Succeeded)
        {
            return BadRequest("Failed to deleting product");
        }
        return NoContent();
    }
    
}