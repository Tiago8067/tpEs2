using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Backend.Services.AuthService;

public class AuthService : IAuthService
{
    private readonly TarefasDbContext _dbContext;
    private readonly IConfiguration _configuration;

    public AuthService(TarefasDbContext dbContext, IConfiguration configuration)
    {
        _dbContext = dbContext;
        _configuration = configuration;
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

    public async Task<ServiceResponse<string>> Login(string email, string pass)
    {
        var response = new ServiceResponse<string>();
        var user = await _dbContext.Usermodels
            .FirstOrDefaultAsync(x => x.Email.ToLower().Equals(email.ToLower()));
        if (user == null)
        {
            response.Success = false;
                response.Message = "Utilizador não existe.";
        }
        else if (!VerifyPasswordHash(pass, user.Passhash, user.Passsalt))
        {
            response.Success = false;
            response.Message = "Password errada.";
        }
        else
        {
            response.Data = CreateToken(user);
        }

        return response;
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
    
    private bool VerifyPasswordHash(string pass, byte[] passwordHash, byte[] passwordSalt)
    {
        using (var hmac = new HMACSHA512(passwordSalt))
        {
            var computedHash =
                hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(pass));
            return computedHash.SequenceEqual(passwordHash);
        }
    }
    
    private string CreateToken(Usermodel user)
    {
        List<Claim> claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Email),
            new Claim(ClaimTypes.Role, user.Role)
        };

        var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8
            .GetBytes(_configuration.GetSection("AppSettings:Token").Value));

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: creds);

        var jwt = new JwtSecurityTokenHandler().WriteToken(token);

        return jwt;
    }
    
    public async Task<ServiceResponse<bool>> ChangePassword(Guid userId, string newPassword)
    {
        var user = await _dbContext.Usermodels.FindAsync(userId);
        
        if (user == null)
        {
            return new ServiceResponse<bool>
            {
                Success = false,
                Message = "Utilizador não encontrado."
            };
        }

        CreatePassHash(newPassword, out byte[] passwordHash, out byte[] passwordSalt);

        user.Passhash = passwordHash;
        user.Passsalt = passwordSalt;

        await _dbContext.SaveChangesAsync();

        return new ServiceResponse<bool> { Data = true, Message = "A pass foi alterada." };
    }
    
    
}