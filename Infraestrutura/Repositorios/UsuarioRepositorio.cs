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
                x.Email.Equals(email.ToLower()) && 
                x.Password.Equals(password.ToLower())).FirstAsync();
    }

    public async Task<Usuario> CadastraUsuario(string email, string password, string name)
    {
        var usuario = new Usuario
        {
            Email = email,
            Password = password,
            Name = name
        };
        await _dbContext.Usuarios.AddAsync(usuario);
        await _dbContext.SaveChangesAsync();
        return await GetUsuario(email, password);
    }
}