using System.Globalization;
using Dominio.Entidades;
using Dominio.IRepositorios;
using Dominio.Services.Interfaces;

namespace Dominio.Services;

public class GastosService : IGastosService
{
    private readonly IGastosRepositorio _gastosRepositorio;
    
    public GastosService(IGastosRepositorio gastosRepositorio)
    {
        _gastosRepositorio = gastosRepositorio;
    }
    
    public async Task<IEnumerable<Lancamento>> GetLancamentos(string id)
    {
        return await _gastosRepositorio.GetLancamentosAsync(id);
    }
    
    public async Task CadastraLancamento(Lancamento lancamento)
    {
        await _gastosRepositorio.cadastraLancamentoAsync(lancamento);
    }
    
    public Task<IEnumerable<Lancamento>> GetLancamentosComFiltro(DateTime dataInicio, DateTime dataFim, string usuarioId)
    {
        return _gastosRepositorio.GetLancamentosComFiltroAsync(dataInicio, dataFim, usuarioId);
    }
}