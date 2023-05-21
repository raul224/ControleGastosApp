using AutoMapper;
using Dominio.Dto;
using Dominio.Entidades;

namespace ControleGastosApp.MappingProfiles;

public class LancamentoProfile : Profile
{
    public LancamentoProfile()
    {
        CreateMap<LancamentoCadastroModel, Lancamento>();
    }
}