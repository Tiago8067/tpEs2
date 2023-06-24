using Microsoft.EntityFrameworkCore;

namespace Backend.Services.ProductService;

public class ProductService : IProductService
{
    private readonly TarefasDbContext _contexta;

    public ProductService(TarefasDbContext dbContexta)
    {
        _contexta = dbContexta; // ?? throw new ArgumentNullException(nameof(dbContexta));
    }
    
    public async Task<ServiceResponse<List<Product>>> GetProductsAsync()
    {
        var response = new ServiceResponse<List<Product>>
        {
            Data = await _contexta.Products.ToListAsync()
        };
        return response;
    }

    //public async Task<ServiceResponse<Product>> GetProductAsync(int productId)
    public ServiceResponse<Product> GetProductAsync(int productId)
    {
        var response = new ServiceResponse<Product>();
        //var product = await _contexta.Products.FindAsync(productId);
        var product = _contexta.Products.FirstOrDefault(p => p.Id == productId);

        if (product == null)
        {
            response.Success = false;
            response.Message = "Sorry, but this product does not exist.";
        }
        else
        {
            response.Data = product;
        }

        return response;
    }
}