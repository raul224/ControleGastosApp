using AutoMapper;
using Dominio.Dto;
using Dominio.Dto.Response;
using Dominio.Entidades;

namespace ControleGastosApp.MappingProfiles;

public class FlowProfile : Profile
{
    public FlowProfile()
    {
        CreateMap<FlowRegisterModel, Flow>();

        CreateMap<Flow, FlowResponse>()
            .ForMember(lr => lr.Id,
                opt
                    => opt.MapFrom(l => l.Id.ToString()));

        CreateMap<Flow, FlowCsvModel>();
    }
}