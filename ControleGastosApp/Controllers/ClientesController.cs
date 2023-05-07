using System.Globalization;
using System.Text;
using CsvHelper;
using Dominio.Dto;
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
        [Route("Saldo")]
        public IActionResult GetSaldo([FromQuery] int clientId)
        {
            var cliente = _clientesService.GetCliente(clientId);
            return Ok(cliente);
        }

        [HttpGet]
        [Route("Lancamentos")]
        public IActionResult GetLancamentos([FromQuery]int clientId)
        {
            var lancamentos = _clientesService.GetLancamentos(clientId);
            return Ok(lancamentos);
        }

        [HttpPost]
        [Route("Lancamentos")]
        public async Task<IActionResult> CadastraLancamento([FromBody] Lancamento lancamento)
        {
            await _clientesService.CadastraLancamento(lancamento);
            return Ok();
        }

        [HttpPost]
        [Route("Lancamentos/Anterior")]
        public IActionResult GetLancamentosAnteriores90Dias([FromBody]DataRangeModel dataRange)
        {
            var lancamentos = _clientesService.GetLancamentosComFiltro(
                dataRange.dataInicial,
                dataRange.dataFinal);
            using (var writer = new StreamWriter("lancamentos.csv"))
            using (var csv = new CsvWriter(writer, CultureInfo.CurrentCulture))
            {
                csv.WriteRecord(lancamentos);
            }
            
            var bytes = Encoding.UTF8.GetBytes("lancamentos.csv");
            
            return File(bytes, "text/csv", "lancamentos.csv");
        }
    }
}