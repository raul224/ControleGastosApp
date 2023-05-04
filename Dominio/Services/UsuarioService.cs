using Dominio.Dto;
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
    
    public async Task<UsuarioClienteDto> EfetuaLogin(string userName, string password)
    {
        var user = await _usuarioRepositorio.GetUsuario(userName, password);
        var cliente = await _clienteRepositorio.GetCliente(user.clientId);
        
        throw new NotImplementedException();
    }

    public Task<UsuarioClienteDto> RegisterUser(string email, string name, string password)
    {
        throw new NotImplementedException();
    }
}