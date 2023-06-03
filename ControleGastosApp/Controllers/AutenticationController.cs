using Dominio.Dto;
using Dominio.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ControleGastosApp.Controllers;

[ApiController]
[Route("[Controller]")]
public class AutenticationController : ControllerBase
{
    public readonly IUserService _userService;

    public AutenticationController(IUserService userService)
    {
        _userService = userService;
    }
    
    [HttpPost]
    public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
    {
        try
        {
            var userAuntenticated = await _userService.Login(
                loginModel.email, 
                loginModel.password);
            return Ok(userAuntenticated);
        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }    
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterModel registerModel)
    {
        try
        {
            var newUserClient = await _userService.RegisterUser(registerModel);
            return Ok(newUserClient);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}