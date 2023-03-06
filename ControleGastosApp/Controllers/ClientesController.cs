using Microsoft.AspNetCore.Mvc;

namespace ControleGastosApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly ILogger<ClientesController> _logger;

        public ClientesController(ILogger<ClientesController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult GetSaldo([FromQuery] int id)
        {

            return Ok();
        }

        [HttpGet]
        public ActionResult GetLancamentos(int id)
        {

            return Ok();
        }
    }
}