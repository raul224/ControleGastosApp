using Dominio.Entidades;

namespace Dominio.Services;

public interface IUsuarioService
{
    Task<Cliente> EfetuaLogin(string email, string password);
    Task<Cliente> RegisterUser(string email, string name, string password);
}