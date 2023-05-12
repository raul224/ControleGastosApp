using AutoMapper;
using Dominio.Dto.Response;
using Dominio.Entidades;
using Dominio.IRepositorios;
using Dominio.Services.Interfaces;

namespace Dominio.Services;

public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioRepositorio _usuarioRepositorio;
    private readonly IMapper _mapper;
    
    public UsuarioService(IUsuarioRepositorio usuarioRepositorio)
    {
        _usuarioRepositorio = usuarioRepositorio;
    }
    
    public async Task<UsuarioResponse> EfetuaLogin(string email, string password)
    {
        var usuario = await _usuarioRepositorio.GetUsuarioAsync(email, password);
        return _mapper.Map<Usuario, UsuarioResponse>(usuario);
    }

    public async Task<UsuarioResponse> RegisterUser(string email, string name, string password)
    {
        var usuario = new Usuario
        {
            Email = email,
            Password = password,
            Name = name,
            Saldo = 0
        };
        await _usuarioRepositorio.CadastraUsuarioAsync(usuario);
        var userDb = await _usuarioRepositorio.GetUsuarioAsync(email, password);
        return _mapper.Map<Usuario, UsuarioResponse>(usuario);
    }
}