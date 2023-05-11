using Dominio.Entidades;
using Dominio.IRepositorios;
using Dominio.Services.Interfaces;

namespace Dominio.Services;

public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioRepositorio _usuarioRepositorio;
    
    public UsuarioService(IUsuarioRepositorio usuarioRepositorio)
    {
        _usuarioRepositorio = usuarioRepositorio;
    }
    
    public async Task<Usuario> EfetuaLogin(string email, string password)
    {
        return await _usuarioRepositorio.GetUsuarioAsync(email, password);
    }

    public async Task<Usuario> RegisterUser(string email, string name, string password)
    {
        var usuario = new Usuario
        {
            Email = email,
            Password = password,
            Name = name,
            Saldo = 0
        };
        await _usuarioRepositorio.CadastraUsuarioAsync(usuario);
        return await _usuarioRepositorio.GetUsuarioAsync(email, password);
    }
}