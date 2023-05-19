using Dominio.Entidades;

namespace Dominio.Services.Interfaces;

public interface IGastosService
{
    Task<IEnumerable<Lancamento>> GetLancamentos(string id);
    Task CadastraLancamento(Lancamento lancamento);
    Task<IEnumerable<Lancamento>> GetLancamentosComFiltro(DateTime dataInicio, DateTime dataFim, string usuarioId);
}