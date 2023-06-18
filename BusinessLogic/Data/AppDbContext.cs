using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
}