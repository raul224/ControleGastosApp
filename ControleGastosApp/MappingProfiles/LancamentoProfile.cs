using AutoMapper;
using Dominio.Dto;
using Dominio.Dto.Response;
using Dominio.Entidades;

namespace ControleGastosApp.MappingProfiles;

public class LancamentoProfile : Profile
{
    public LancamentoProfile()
    {
        CreateMap<LancamentoCadastroModel, Lancamento>();

        CreateMap<Lancamento, LancamentoResponse>()
            .ForMember(lr => lr.Id,
                opt
                    => opt.MapFrom(l => l.Id.ToString()));
    }
}