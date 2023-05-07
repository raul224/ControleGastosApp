﻿using Dominio.Dto;
using Dominio.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ControleGastosApp.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class AutenticationController : ControllerBase
    {
        private readonly ILogger<ClientesController> _logger;
        public readonly IUsuarioService _usuarioService;

        public AutenticationController(ILogger<ClientesController> logger, IUsuarioService usuarioService)
        {
            _logger = logger;
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
            var newUser = await _usuarioService.RegisterUser(
                registerModel.email, 
                registerModel.name, 
                registerModel.password);
            return Ok(newUser);
            
        }
    }
}

