using AutoMapper;
using Dominio.Dto;
using Dominio.Dto.Response;
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
    
    public async Task<IEnumerable<LancamentoResponse>> GetLancamentos(string id)
    {
        var returnList = await _gastosRepositorio.GetLancamentosAsync(id);
        return _mapper.Map<IEnumerable<Lancamento>, IEnumerable<LancamentoResponse>>(returnList);
    }
    
    public async Task CadastraLancamento(LancamentoCadastroModel lancamentoRequest)
    {
        var lancamento = _mapper.Map<LancamentoCadastroModel, Lancamento>(lancamentoRequest);
        await _gastosRepositorio.cadastraLancamentoAsync(lancamento);
    }
    
    public async Task<IEnumerable<LancamentoResponse>> GetLancamentosComFiltro(
        DateTime dataInicio, 
        DateTime dataFim, 
        string usuarioId)
    {
        var returnList = await _gastosRepositorio
            .GetLancamentosComFiltroAsync(dataInicio, dataFim, usuarioId);
        return _mapper.Map<IEnumerable<Lancamento>, IEnumerable<LancamentoResponse>>(returnList);
    }
}