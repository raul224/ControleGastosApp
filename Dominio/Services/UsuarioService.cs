using Dominio.Dto;
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
    
    public async Task<Cliente> EfetuaLogin(string userName, string password)
    {
        var user = await _usuarioRepositorio.GetUsuario(userName, password);
        return user.Cliente;
    }

    public async Task<Usuario> RegisterUser(string email, string name, string password)
    {
        var user = await _usuarioRepositorio.CadastraUsuario(email, password, name);
        await _clienteRepositorio.CadastraCliente(user);
        return await _usuarioRepositorio.GetUsuario(email, password);
    }
}