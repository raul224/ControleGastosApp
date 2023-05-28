using AutoMapper;
using Dominio.Dto;
using Dominio.Dto.Response;
using Dominio.Entidades;

namespace ControleGastosApp.MappingProfiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<Users, UserResponse>()
            .ForMember(ur => ur.Id,
                opt =>opt
                    .MapFrom(u => u.Id.ToString()));

        CreateMap<RegisterModel, Users>();
    }
}