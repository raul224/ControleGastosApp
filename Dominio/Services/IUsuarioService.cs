using Dominio.Dto;

namespace Dominio.Services;

public interface IUsuarioService
{
    Task<UsuarioClienteDto> EfetuaLogin(string email, string password);
    Task<UsuarioClienteDto> RegisterUser(string email, string name, string password);
}