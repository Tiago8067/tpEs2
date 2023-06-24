using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services.AuthService;

public class AuthService : IAuthService
{
    private readonly TarefasDbContext _dbContext;

    public AuthService(TarefasDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<ServiceResponse<Guid>> Registo(Usermodel user, string pass)
    {
        if (await UserExists(user.Email))
        {
            return new ServiceResponse<Guid>
            {
                Success = false,
                Message = "Este Utilizador já existe."
            };
        }
        
        CreatePassHash(pass, out byte[] passHash, out byte[] passSalt);

        user.Passhash = passHash;
        user.Passsalt = passSalt;

        _dbContext.Usermodels.Add(user);
        await _dbContext.SaveChangesAsync();

        return new ServiceResponse<Guid>
        {
            Data = user.Id,
            Message = "Registo realizado com Sucesso!" 
        };
    }

    public async Task<bool> UserExists(string email)
    {
        if (await _dbContext.Usermodels.AnyAsync(usermodel => usermodel.Email.ToLower().Equals(email.ToLower())))
        {
            return true;
        }

        return false;
    }

    private void CreatePassHash(string pass, out byte[] passHash, out byte[] passSalt)
    {
        using (var hmac = new HMACSHA512())
        {
            passSalt = hmac.Key;
            passHash = hmac
                .ComputeHash(System.Text.Encoding.UTF8.GetBytes(pass));
        }
    }
}