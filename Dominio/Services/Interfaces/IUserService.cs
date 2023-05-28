using Dominio.Dto;
using Dominio.Dto.Response;
using Dominio.Entidades;

namespace Dominio.Services.Interfaces;

public interface IUserService
{
    Task<UserResponse> Login(string email, string password);
    Task<UserResponse> RegisterUser(RegisterModel registerModel);
}