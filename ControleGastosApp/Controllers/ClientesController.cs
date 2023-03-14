using Dominio.Entidades;
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
            var cliente = _clientesService.GetCliente(clientId);
            return Ok(cliente);
        }

        [HttpGet]
        public IActionResult GetLancamentos([FromQuery]int clientId)
        {
            var lancamentos = _clientesService.GetLancamentos(clientId);
            return Ok(lancamentos);
        }

        [HttpPost]
        public async Task<IActionResult> CadastraLancamento([FromBody] Lancamento lancamento)
        {
            await _clientesService.CadastraLancamento(lancamento);
            return Ok();
        }

        [HttpPost]
        public IActionResult GetLancamentosAnteriores90Dias([FromBody]DateTime dataInicio,[FromBody] DateTime dataFim)
        {
            var lancamentos = _clientesService.GetLancamentosComFiltro(dataInicio, dataFim);
            return Ok(lancamentos);
        }
    }
}