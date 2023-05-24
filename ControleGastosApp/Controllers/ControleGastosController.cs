using System.Globalization;
using System.Text;
using CsvHelper;
using Dominio.Dto;
using Dominio.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ControleGastosApp.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ControleGastosController : ControllerBase
    {
        private readonly IGastosService _gastosService;

        public ControleGastosController(IGastosService gastosService)
        {
            _gastosService = gastosService;
        }

        [HttpGet]
        [Route("Lancamentos")]
        public IActionResult GetLancamentos([FromQuery]string usuarioId)
        {
            var lancamentos = _gastosService.GetLancamentos(usuarioId);
            return Ok(lancamentos);
        }
        
        [HttpPost]
        [Route("Lancamentos")]
        public async Task<IActionResult> CadastraLancamento([FromBody] LancamentoCadastroModel lancamento)
        {
            await _gastosService.CadastraLancamento(lancamento);
            return Ok();
        }
        
        [HttpPost]
        [Route("Lancamentos/Anterior")]
        public IActionResult GetLancamentosAnteriores90Dias([FromBody]DataRangeModel dataRange)
        {
            var lancamentos = _gastosService.GetLancamentosComFiltro(
                dataRange.DataInicial,
                dataRange.DataFinal,
                dataRange.UsuarioId);
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

