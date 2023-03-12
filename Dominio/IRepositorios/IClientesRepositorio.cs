using Dominio.Entidades;

namespace Dominio.IRepositorios;

public interface IClientesRepositorio
{
    IEnumerable<Lancamento> GetLancamentos(int clientId);
    IEnumerable<Lancamento> GetLancamentosComFiltro(DateTime dataInicio, DateTime dataFim);
    Task cadastraLancamento(Lancamento lancamento);

    Cliente GetCliente(int clientId);
}