using Dominio.Entidades;

namespace Dominio.IRepositorios;

public interface IClientesRepositorio
{
    IEnumerable<Lancamento> GetLancamentos(int clientId);
    IEnumerable<Lancamento> GetLancamentosComFiltro(DateTime dataInicio, DateTime dataFim);
    Task cadastraLancamento(Lancamento lancamento);
    Task<Cliente> GetCliente(int clientId);
    Task<Cliente> CadastraCliente();
}