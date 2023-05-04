using Dominio.Entidades;

namespace Dominio.Services;

public interface IClientesService
{
    List<Lancamento> GetLancamentos(int id);
    List<Lancamento> GetLancamentosComFiltro(DateTime dataInicio, DateTime dataFim);
    Task CadastraLancamento(Lancamento lancamento);
    Task<Cliente> GetCliente(int clientId);
}