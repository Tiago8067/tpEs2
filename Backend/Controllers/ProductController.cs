using Backend.Services.ProductService;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProducts()
    {
        var result = await _productService.GetProductsAsync();
        return Ok(result);
    }
    
    [HttpGet("{productId}")]
    public ActionResult<ServiceResponse<Product>> GetProduct(int productId)
    //public async Task<ActionResult<ServiceResponse<Product>>> GetProduct(int productId)
    {
        //var result = await _productService.GetProductAsync(productId);
        var result = _productService.GetProductAsync(productId);
        return Ok(result);
    }

}