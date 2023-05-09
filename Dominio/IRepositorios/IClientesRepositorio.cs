using Dominio.Entidades;

namespace Dominio.IRepositorios;

public interface IClientesRepositorio
{
    Task<IEnumerable<Lancamento>> GetLancamentosAsync(int clientId);
    Task<IEnumerable<Lancamento>> GetLancamentosComFiltroAsync(DateTime dataIncio, DateTime dataFim);
    Task cadastraLancamentoAsync(Lancamento lancamento);
    Task<Cliente> GetClienteAsync(int clientId);
    Task CadastraClienteAsync(Usuario usuario);
    Task<Cliente> GetClientByUser(int userId);
}