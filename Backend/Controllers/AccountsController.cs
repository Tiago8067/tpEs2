/*using BusinessLogic.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountsController : ControllerBase
{
    private readonly UserManager<IdentityUser> _userManager;
    
    public AccountsController(UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateAccount([FromBody] Registermodel model){
        var newUser = new IdentityUser ( UserName = model.Email, Email = model.Email ) ;
        var result = await _userManager.CreateAsync (newuser, model.Password!);
    
        if (!result.Succeeded)
        {
            var errors = result.Errors.Select(x => x.Description);
            return Ok(new Registerresult{Successful = false, Errors = errors});
        }
        return Ok(new Registerresult {Successful = true });
    }
}*/