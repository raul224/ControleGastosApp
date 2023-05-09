using Dominio.Entidades;

namespace Dominio.IRepositorios;

public interface IUsuarioRepositorio
{
    Task<Usuario> GetUsuarioAsync(string email, string password);
    Task<Usuario> CadastraUsuarioAsync(string email, string password, string name);
}