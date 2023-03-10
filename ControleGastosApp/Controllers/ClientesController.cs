using Dominio.Services;
using Microsoft.AspNetCore.Mvc;

namespace ControleGastosApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly ILogger<ClientesController> _logger;
        private readonly IClientesService _clientesService;

        public ClientesController(ILogger<ClientesController> logger, IClientesService clientesService)
        {
            _logger = logger;
            _clientesService = clientesService;
        }

        [HttpGet]
        public IActionResult GetSaldo([FromQuery] int clientId)
        {
            
            return Ok();
        }

        [HttpGet]
        public IActionResult GetLancamentos([FromQuery]int clientId)
        {
            
            return Ok();
        }
    }
}