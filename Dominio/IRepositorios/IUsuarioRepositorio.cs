using Dominio.Entidades;

namespace Dominio.IRepositorios;

public interface IUsuarioRepositorio
{
    Task<Usuario> GetUsuario(string userName, string password);
    Task<Usuario> CadastraUsuario(string email, string password, string name);
}