using Dominio.Dto.Response;
using Dominio.Entidades;

namespace Dominio.Services.Interfaces;

public interface IUsuarioService
{
    Task<UsuarioResponse> EfetuaLogin(string email, string password);
    Task<UsuarioResponse> RegisterUser(string email, string name, string password);
}