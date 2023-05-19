using Dominio.Dto;
using Dominio.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ControleGastosApp.Controllers;

[ApiController]
[Route("[Controller]")]
public class AutenticationController : ControllerBase
{
    public readonly IUsuarioService _usuarioService;

    public AutenticationController(IUsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }
    
    [HttpPost]
    public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
    {
        var usuarioAutorizado = await _usuarioService.EfetuaLogin(
            loginModel.email, 
            loginModel.password);
        return Ok(usuarioAutorizado);    
    }

    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> Register([FromBody] RegisterModel registerModel)
    {
        var newUserClient = await _usuarioService.RegisterUser(
            registerModel.email, 
            registerModel.name, 
            registerModel.password);
        return Ok(newUserClient);
            
    }
}