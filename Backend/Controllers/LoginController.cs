using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BusinessLogic.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Backend.Controllers;

public class LoginController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly SignInManager<IdentityUser> _signInManager;

    public LoginController(IConfiguration configuration, SignInManager<IdentityUser> signInManager)
    {
        _configuration = configuration;
        _signInManager = signInManager;
    }
    
    [HttpPost]
    public async Task<IActionResult>Login([FromBody] Loginmodel login) {
        var result = await _signInManager.PasswordSignInAsync(login.Email, login.Password!, false, false);
        
        if (!result.Succeeded) return BadRequest(new Loginresult { Successful = false, Error = "Username and password are invalid."});
        
        var claims = new[] { new Claim(ClaimTypes.Name, login.Email) };
        
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSecurityKey"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256); //encriptacao de credenciais
        var expiry = DateTime.Now.AddDays(Convert.ToInt32(_configuration["JwtExpiryInDays"]));

        var token = new JwtSecurityToken( //geracao do token
            _configuration["JwtIssuer"],
            _configuration["JwtAudience"],
            claims,
            expires: expiry,
            signingCredentials: creds
        );

        return Ok(new Loginresult { Successful = true, Token = new JwtSecurityTokenHandler().WriteToken(token) });
    }
}