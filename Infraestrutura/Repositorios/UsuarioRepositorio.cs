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
    
    public async Task<Usuario> GetUsuario(string email, string password)
    {
        return await _dbContext.Usuarios
            .Where(x => 
                x.email.Equals(email.ToLower()) && 
                x.password.Equals(password.ToLower())).FirstAsync();
    }

    public async Task<Usuario> CadastraUsuario(string email, string password, string name)
    {
        var usuario = new Usuario
        {
            email = email,
            password = password,
            name = name
        };
        await _dbContext.Usuarios.AddAsync(usuario);
        await _dbContext.SaveChangesAsync();
        return await GetUsuario(email, password);
    }
}