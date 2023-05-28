using AutoMapper;
using Dominio.Dto;
using Dominio.Dto.Response;
using Dominio.Entidades;
using Dominio.IRepositorios;
using Dominio.Services.Interfaces;

namespace Dominio.Services;

public class BalanceService : IBalanceService
{
    private readonly IBalanceRepositorio _balanceRepositorio;
    private readonly IMapper _mapper;
    
    public BalanceService(IBalanceRepositorio balanceRepositorio, IMapper mapper)
    {
        _balanceRepositorio = balanceRepositorio ?? throw new ArgumentNullException(nameof(balanceRepositorio));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }
    
    public async Task<IEnumerable<FlowResponse>> GetFlows(string id)
    {
        var returnList = await _balanceRepositorio.GetFlowsAsync(id);
        return _mapper.Map<IEnumerable<Flow>, IEnumerable<FlowResponse>>(returnList);
    }
    
    public async Task AddFlow(FlowRegisterModel flowRequest)
    {
        var flow = _mapper.Map<FlowRegisterModel, Flow>(flowRequest);
        await _balanceRepositorio.AddFlowAsync(flow);
    }
    
    public async Task<IEnumerable<FlowResponse>> GetPreviewFlow(
        DateTime initialDate, 
        DateTime finalDate, 
        string userId)
    {
        var returnList = await _balanceRepositorio
            .GetFlowsPreviewAsync(initialDate, finalDate, userId);
        return _mapper.Map<IEnumerable<Flow>, IEnumerable<FlowResponse>>(returnList);
    }
}