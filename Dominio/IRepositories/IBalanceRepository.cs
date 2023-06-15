using Dominio.Entidades;

namespace Dominio.IRepositorios;

public interface IBalanceRepository
{
    Task<IEnumerable<Flow>> GetFlowsAsync(string clientId);

    Task<IEnumerable<Flow>> GetFlowsPreviewAsync(DateTime initialDate, DateTime finalDate, string userId);
    Task AddFlowAsync(Flow flow);

    Task DeleteFlowAsync(string id);
}