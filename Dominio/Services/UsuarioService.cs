using AutoMapper;
using Dominio.Dto;
using Dominio.Dto.Response;
using Dominio.Entidades;
using Dominio.IRepositorios;
using Dominio.Services.Interfaces;

namespace Dominio.Services;

public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioRepositorio _usuarioRepositorio;
    private readonly IMapper _mapper;
    
    public UsuarioService(
        IUsuarioRepositorio usuarioRepositorio,
        IMapper mapper)
    {
        _usuarioRepositorio = usuarioRepositorio;
        _mapper = mapper;
    }
    
    public async Task<UsuarioResponse> EfetuaLogin(string email, string password)
    {
        var usuario = await _usuarioRepositorio.GetUsuarioAsync(email, password);
        return _mapper.Map<Usuario, UsuarioResponse>(usuario);;
    }

    public async Task<UsuarioResponse> RegisterUser(RegisterModel registerModel)
    {
        var usuario = _mapper.Map<RegisterModel, Usuario>(registerModel);
        await _usuarioRepositorio.CadastraUsuarioAsync(usuario);
        var userDb = await _usuarioRepositorio.GetUsuarioAsync(usuario.Email, usuario.Password);
        return _mapper.Map<Usuario, UsuarioResponse>(usuario);
    }
}