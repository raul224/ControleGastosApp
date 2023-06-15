using Dominio.Dto;
using Dominio.Dto.Response;

namespace Dominio.Services.Interfaces;

public interface IBalanceService
{
    Task<IEnumerable<FlowResponse>> GetFlows(string id);
    Task AddFlow(FlowRegisterModel flow);
    Task<IEnumerable<FlowCsvModel>> GetPreviewFlow(DateTime dataInicio, DateTime dataFim, string usuarioId);
    Task DeleteFlow(string id);
}