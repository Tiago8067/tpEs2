namespace FrontEnd.Services.AuthService;

public interface IAuthService
{
    Task<ServiceResponse<Guid>> Registo(Userregisto request);
    Task<ServiceResponse<string>> Login(Userlogin request);
}