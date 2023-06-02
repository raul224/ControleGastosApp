using Dominio.Entidades;

namespace Dominio.IRepositorios;

public interface IUserRepository
{
    Task<Users> GetUserAsync(string email, string password);
    Task AddUserAsync(Users users);
}