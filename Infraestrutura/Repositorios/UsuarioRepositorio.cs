using Dominio.Entidades;
using Dominio.IRepositorios;
using Microsoft.EntityFrameworkCore;

namespace Infraestrutura.Repositorios;

public class UsuarioRepositorio : IUsuarioRepositorio
{
    private DatabaseContext _dbContext;
    
    public UsuarioRepositorio(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<Usuario> GetUsuario(string userName, string password)
    {
        return await _dbContext.Usuarios
            .Where(x => 
                x.userName.Equals(userName.ToLower()) && 
                x.password.Equals(password.ToLower())).FirstAsync();
    }

    public async Task CadastraUsuario(string userName, string password, int clientId)
    {
        var usuario = new Usuario
        {
            userName = userName,
            password = password,
            clientId = clientId
        };
        await _dbContext.Usuarios.AddAsync(usuario);
        await _dbContext.SaveChangesAsync();
    }
}