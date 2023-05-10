using Dominio.Entidades;

namespace Dominio.IRepositorios;

public interface IUsuarioRepositorio
{
    Task<Usuario> GetUsuarioAsync(string email, string password);
    Task CadastraUsuarioAsync(Usuario usuario);
}