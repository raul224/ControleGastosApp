using Dominio.Entidades;

namespace Dominio.IRepositorios;

public interface IUsuarioRepositorio
{
    Task<Usuario> GetUsuario(string userName, string password);
}