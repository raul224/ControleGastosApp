using Dominio.Dto;
using Dominio.Entidades;

namespace Dominio.Services.Interfaces;

public interface IGastosService
{
    Task<IEnumerable<Lancamento>> GetLancamentos(string id);
    Task CadastraLancamento(LancamentoCadastroModel lancamento);
    Task<IEnumerable<Lancamento>> GetLancamentosComFiltro(DateTime dataInicio, DateTime dataFim, string usuarioId);
}