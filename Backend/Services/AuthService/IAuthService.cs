namespace Backend.Services.AuthService;

public interface IAuthService
{
    Task<ServiceResponse<Guid>> Registo(Usermodel user, string password);
    Task<bool> UserExists(string email);
    Task<ServiceResponse<string>> Login(string email, string pass);
}