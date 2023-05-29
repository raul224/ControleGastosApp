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
    public class BalanceController : ControllerBase
    {
        private readonly IBalanceService _balanceService;

        public BalanceController(IBalanceService balanceService)
        {
            _balanceService = balanceService;
        }

        [HttpGet]
        [Route("Flows")]
        public IActionResult GetFlow([FromQuery]string userId)
        {
            var flows = _balanceService.GetFlows(userId);
            return Ok(flows);
        }
        
        [HttpPost]
        [Route("Flows")]
        public async Task<IActionResult> AddFlow([FromBody] FlowRegisterModel flow)
        {
            await _balanceService.AddFlow(flow);
            return Ok();
        }
        
        [HttpPost]
        [Route("Flows/Preview")]
        public IActionResult GetPreviewFlows90Days([FromBody]DataRangeModel dataRange)
        {
            var flows = _balanceService.GetPreviewFlow(
                dataRange.InitialDate,
                dataRange.FinalDate,
                dataRange.UserId);
            using (var writer = new StreamWriter("lancamentos.csv"))
            using (var csv = new CsvWriter(writer, CultureInfo.CurrentCulture))
            {
                csv.WriteRecord(flows);
            }
            
            var bytes = Encoding.UTF8.GetBytes("lancamentos.csv");
            
            return File(bytes, "text/csv", "lancamentos.csv");
        }
    }
}

