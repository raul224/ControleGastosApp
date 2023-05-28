using AutoMapper;
using Dominio.Dto;
using Dominio.Dto.Response;
using Dominio.Entidades;
using Dominio.IRepositorios;
using Dominio.Services.Interfaces;

namespace Dominio.Services;

public class UserService : IUserService
{
    private readonly IUserRepositorio _userRepositorio;
    private readonly IMapper _mapper;
    
    public UserService(
        IUserRepositorio userRepositorio,
        IMapper mapper)
    {
        _userRepositorio = userRepositorio;
        _mapper = mapper;
    }
    
    public async Task<UserResponse> Login(string email, string password)
    {
        var user = await _userRepositorio.GetUserAsync(email, password);
        return _mapper.Map<Users, UserResponse>(user);;
    }

    public async Task<UserResponse> RegisterUser(RegisterModel registerModel)
    {
        var user = _mapper.Map<RegisterModel, Users>(registerModel);
        await _userRepositorio.AddUserAsync(user);
        var userDb = await _userRepositorio.GetUserAsync(user.Email, user.Password);
        return _mapper.Map<Users, UserResponse>(user);
    }
}