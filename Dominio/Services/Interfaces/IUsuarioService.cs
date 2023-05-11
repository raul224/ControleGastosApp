using Dominio.Entidades;

namespace Dominio.Services.Interfaces;

public interface IUsuarioService
{
    Task<Usuario> EfetuaLogin(string email, string password);
    Task<Usuario> RegisterUser(string email, string name, string password);
}