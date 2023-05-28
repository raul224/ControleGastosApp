using Dominio.Dto;
using Dominio.Dto.Response;
using Dominio.Entidades;

namespace Dominio.Services.Interfaces;

public interface IBalanceService
{
    Task<IEnumerable<FlowResponse>> GetFlows(string id);
    Task AddFlow(FlowRegisterModel flow);
    Task<IEnumerable<FlowResponse>> GetPreviewFlow(DateTime dataInicio, DateTime dataFim, string usuarioId);
}