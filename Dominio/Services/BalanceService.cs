using AutoMapper;
using Dominio.Dto;
using Dominio.Dto.Response;
using Dominio.Entidades;
using Dominio.IRepositorios;
using Dominio.Services.Interfaces;

namespace Dominio.Services;

public class BalanceService : IBalanceService
{
    private readonly IBalanceRepository _balanceRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    
    public BalanceService(
        IBalanceRepository balanceRepository,
        IUserRepository userRepository,
        IMapper mapper)
    {
        _balanceRepository = balanceRepository ?? throw new ArgumentNullException(nameof(balanceRepository));
        _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }
    
    public async Task<IEnumerable<FlowResponse>> GetFlows(string id)
    {
        var returnList = await _balanceRepository.GetFlowsAsync(id);
        if (returnList.Any())
            return _mapper.Map<IEnumerable<Flow>, IEnumerable<FlowResponse>>(returnList);
        return new List<FlowResponse>();
    }
    
    public async Task AddFlow(FlowRegisterModel flowRequest)
    {
        var flow = _mapper.Map<FlowRegisterModel, Flow>(flowRequest);
        await _balanceRepository.AddFlowAsync(flow);
        await _userRepository.UpdateUserAsync(flowRequest.flowType, flowRequest.UserId, flowRequest.Value);
    }
    
    public async Task<IEnumerable<FlowCsvModel>> GetPreviewFlow(
        DateTime initialDate, 
        DateTime finalDate, 
        string userId)
    {
        var returnList = await _balanceRepository
            .GetFlowsPreviewAsync(initialDate, finalDate, userId);
        return _mapper.Map<IEnumerable<Flow>, IEnumerable<FlowCsvModel>>(returnList);
    }

    public async Task DeleteFlow(string id)
    {
        await _balanceRepository.DeleteFlowAsync(id);
    }
}