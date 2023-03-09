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
        public ActionResult GetSaldo([FromQuery] int clientId)
        {
            
            return Ok();
        }

        [HttpGet]
        public ActionResult GetLancamentos([FromQuery]int cli)
        {

            return Ok();
        }
    }
}