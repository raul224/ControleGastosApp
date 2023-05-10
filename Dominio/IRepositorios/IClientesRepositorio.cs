using Dominio.Entidades;

namespace Dominio.IRepositorios;

public interface IClientesRepositorio
{
    Task<IEnumerable<Lancamento>> GetLancamentosAsync(string clientId);
    Task<IEnumerable<Lancamento>> GetLancamentosComFiltroAsync(DateTime dataIncio, DateTime dataFim);
    Task cadastraLancamentoAsync(Lancamento lancamento);
    Task<Cliente> GetClienteAsync(string clientId);
    Task CadastraClienteAsync(Cliente cliente);
    Task<Cliente> GetClientByUser(string userId);
}