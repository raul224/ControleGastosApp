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

    public async Task<Cliente> RegisterUser(string email, string name, string password)
    {
        var usuario = new Usuario
        {
            Id = new Guid().ToString(),
            Email = email,
            Password = password,
            Name = name
        };
        var cliente = new Cliente
        {
            Id = new Guid().ToString(),
            Saldo = 0,
            UsuarioId= usuario.Id
        };
        usuario.ClienteId = cliente.Id;
        cliente.UsuarioId = usuario.Id;
        
        await _usuarioRepositorio.CadastraUsuarioAsync(usuario);
        await _clienteRepositorio.CadastraClienteAsync(cliente);
        return cliente;
    }
}