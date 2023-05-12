using AutoMapper;
using Dominio.Dto.Response;
using Dominio.Entidades;

namespace ControleGastosApp.MappingProfiles;

public class UsuarioProfile : Profile
{
    public UsuarioProfile()
    {
        CreateMap<Usuario, UsuarioResponse>()
            .ForMember(ur => ur.Id,
                opt =>opt
                    .MapFrom(u => u.Id.ToString()));
    }
}