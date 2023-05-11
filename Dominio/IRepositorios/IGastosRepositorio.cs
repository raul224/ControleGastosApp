using Dominio.Entidades;

namespace Dominio.IRepositorios;

public interface IGastosRepositorio
{
    Task<IEnumerable<Lancamento>> GetLancamentosAsync(string clientId);

    Task<IEnumerable<Lancamento>> GetLancamentosComFiltroAsync(DateTime dataIncio, DateTime dataFim);
    Task cadastraLancamentoAsync(Lancamento lancamento);
}