namespace FrontEnd.Services.AuthService;

public class AuthService : IAuthService
{
    private readonly HttpClient _httpClient;

    public AuthService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public async Task<ServiceResponse<Guid>> Registo(Userregisto request)
    {
        var result = await _httpClient.PostAsJsonAsync("api/Auth/registo", request);
        return await result.Content.ReadFromJsonAsync<ServiceResponse<Guid>>();
    }
    
    public async Task<ServiceResponse<string>> Login(Userlogin request)
    {
        var result = await _httpClient.PostAsJsonAsync("api/Auth/login", request);
        return await result.Content.ReadFromJsonAsync<ServiceResponse<string>>();
    }
    
    public async Task<ServiceResponse<bool>> ChangePassword(Userchangepassword request)
    {
        var result = await _httpClient.PostAsJsonAsync("api/Auth/change-password", request.Pass);
        return await result.Content.ReadFromJsonAsync<ServiceResponse<bool>>();
    }
}