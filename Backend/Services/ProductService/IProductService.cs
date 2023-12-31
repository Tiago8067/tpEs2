namespace Backend.Services.ProductService;

public interface IProductService
{
    Task<ServiceResponse<List<Product>>> GetProductsAsync();
    //Task<ServiceResponse<Product>> GetProductAsync(int productId);
    ServiceResponse<Product> GetProductAsync(int productId);
}