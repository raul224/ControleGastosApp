using Dominio.Entidades;
using Dominio.IRepositorios;

namespace Dominio.Services;

public class UsuarioService : IUsuarioService
{
    public IUsuarioRepositorio _usuarioRepositorio;
    public IClientesRepositorio _clienteRepositorio;
    
    public UsuarioService(IUsuarioRepositorio usuarioRepositorio, IClientesRepositorio clienteRepositorio)
    {
        _usuarioRepositorio = usuarioRepositorio;
        _clienteRepositorio = clienteRepositorio;
    }
    
    public async Task<Cliente> EfetuaLogin(string email, string password)
    {
        var user = await _usuarioRepositorio.GetUsuarioAsync(email, password);
        return await _clienteRepositorio.GetClientByUser(user.Id);
    }

    public async Task<Usuario> RegisterUser(string email, string name, string password)
    {
        var user = await _usuarioRepositorio.CadastraUsuarioAsync(email, password, name);
        await _clienteRepositorio.CadastraClienteAsync(user);
        return await _usuarioRepositorio.GetUsuarioAsync(email, password);
    }
}