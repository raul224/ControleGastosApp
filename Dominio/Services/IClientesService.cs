using Dominio.Entidades;

namespace Dominio.Services;

public interface IClientesService
{
    Task<IEnumerable<Lancamento>> GetLancamentos(int id);
    Task<IEnumerable<Lancamento>> GetLancamentosComFiltro(DateTime dataInicio, DateTime dataFim);
    Task CadastraLancamento(Lancamento lancamento);
    Task<Cliente> GetCliente(int clientId);
}