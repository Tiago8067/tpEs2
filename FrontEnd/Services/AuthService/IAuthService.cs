namespace FrontEnd.Services.AuthService;

public interface IAuthService
{
    Task<ServiceResponse<Guid>> Registo(Userregisto request);
}