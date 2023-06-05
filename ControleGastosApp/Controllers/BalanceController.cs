using System.Globalization;
using System.Text;
using CsvHelper;
using Dominio.Dto;
using Dominio.Dto.Response;
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
        public async Task<IActionResult> GetFlow([FromQuery]string userId)
        {
            try
            {
                var flows = await _balanceService.GetFlows(userId);
                return Ok(flows);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        [HttpPost]
        [Route("Flows")]
        public async Task<IActionResult> AddFlow([FromBody] FlowRegisterModel flow)
        {
            try
            {
                await _balanceService.AddFlow(flow);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        [HttpPost]
        [Route("Flows/Preview")]
        public async Task<IActionResult> GetPreviewFlows90Days([FromBody]DataRangeModel dataRange)
        {
            try
            {
                var flows = await _balanceService.GetPreviewFlow(
                    dataRange.InitialDate,
                    dataRange.FinalDate,
                    dataRange.UserId);

                var builder = new StringBuilder();
                using (var writer = new StringWriter(builder))
                using (var csv = new CsvWriter(writer, CultureInfo.CurrentCulture))
                {
                    csv.WriteHeader<FlowCsvModel>();
                    csv.NextRecord();

                    foreach (var flow in flows)
                    {
                        csv.WriteRecord(flow);
                    }
                }
                
                var bytes = Encoding.UTF8.GetBytes(builder.ToString());
            
                return File(bytes, "text/csv", "lancamentos.csv");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}

