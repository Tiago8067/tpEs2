using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }
    
    [HttpPost("registo")]
    public async Task<ActionResult<ServiceResponse<int>>> Registo(Userregisto request)
    {
        var response = await _authService.Registo(
            new Usermodel
            {
                Email = request.Email
            },
            request.Pass);

        if (!response.Success)
        {
            return BadRequest(response);
        }

        return Ok(response);
    }
    
    [HttpPost("login")]
    public async Task<ActionResult<ServiceResponse<string>>> Login(Userlogin request)
    {
        var response = await _authService.Login(request.Email, request.Pass);
        if (!response.Success)
        {
            return BadRequest(response);
        }

        return Ok(response);
    }
}