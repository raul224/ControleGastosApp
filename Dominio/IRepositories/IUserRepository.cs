using Dominio.Entidades;
using Dominio.Enums;

namespace Dominio.IRepositorios;

public interface IUserRepository
{
    Task<Users> GetUserAsync(string email, string password);
    Task AddUserAsync(Users users);
    Task UpdateUserAsync(FlowType flowType, string userId, double value);
    Task<Users> GetUserByIdAsync(string userId);
}