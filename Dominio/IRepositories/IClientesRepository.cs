using Dominio.Entidades;

namespace Dominio.IRepositorios;

public interface IClientesRepository
{
    Task<IEnumerable<Flow>> GetLancamentosAsync(string clientId);
    Task<IEnumerable<Flow>> GetLancamentosComFiltroAsync(DateTime dataIncio, DateTime dataFim);
    Task cadastraLancamentoAsync(Flow flow);
    Task<Users> GetClienteAsync(string clientId);
    Task AddUserAsync(Users cliente);
    Task<Users> GetUserByUser(string userId);
}