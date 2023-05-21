using Dominio.Dto;
using Dominio.Dto.Response;
using Dominio.Entidades;

namespace Dominio.Services.Interfaces;

public interface IGastosService
{
    Task<IEnumerable<LancamentoResponse>> GetLancamentos(string id);
    Task CadastraLancamento(LancamentoCadastroModel lancamento);
    Task<IEnumerable<LancamentoResponse>> GetLancamentosComFiltro(DateTime dataInicio, DateTime dataFim, string usuarioId);
}