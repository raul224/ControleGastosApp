using Dominio.Entidades;

namespace Dominio.IRepositorios;

public interface IBalanceRepositorio
{
    Task<IEnumerable<Flow>> GetFlowsAsync(string clientId);

    Task<IEnumerable<Flow>> GetFlowsPreviewAsync(DateTime initialDate, DateTime finalDate, string userId);
    Task AddFlowAsync(Flow flow);
}