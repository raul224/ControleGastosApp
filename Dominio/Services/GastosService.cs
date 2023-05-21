using AutoMapper;
using Dominio.Dto;
using Dominio.Entidades;
using Dominio.IRepositorios;
using Dominio.Services.Interfaces;

namespace Dominio.Services;

public class GastosService : IGastosService
{
    private readonly IGastosRepositorio _gastosRepositorio;
    private readonly IMapper _mapper;
    
    public GastosService(IGastosRepositorio gastosRepositorio, IMapper mapper)
    {
        _gastosRepositorio = gastosRepositorio ?? throw new ArgumentNullException(nameof(gastosRepositorio));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }
    
    public async Task<IEnumerable<Lancamento>> GetLancamentos(string id)
    {
        return await _gastosRepositorio.GetLancamentosAsync(id);
    }
    
    public async Task CadastraLancamento(LancamentoCadastroModel lancamentoRequest)
    {
        var lancamento = _mapper.Map<LancamentoCadastroModel, Lancamento>(lancamentoRequest);
        await _gastosRepositorio.cadastraLancamentoAsync(lancamento);
    }
    
    public Task<IEnumerable<Lancamento>> GetLancamentosComFiltro(DateTime dataInicio, DateTime dataFim, string usuarioId)
    {
        return _gastosRepositorio.GetLancamentosComFiltroAsync(dataInicio, dataFim, usuarioId);
    }
}