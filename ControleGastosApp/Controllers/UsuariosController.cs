using Microsoft.AspNetCore.Mvc;

namespace ControleGastosApp.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly ILogger<ClientesController> _logger;

        public UsuariosController(ILogger<ClientesController> logger)
        {
            _logger = logger;
        }
    }
}

