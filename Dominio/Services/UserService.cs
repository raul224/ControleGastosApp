using AutoMapper;
using Dominio.Dto;
using Dominio.Dto.Response;
using Dominio.Entidades;
using Dominio.IRepositorios;
using Dominio.Services.Interfaces;

namespace Dominio.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    
    public UserService(
        IUserRepository userRepository,
        IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }
    
    public async Task<UserResponse> Login(string email, string password)
    {
        var user = await _userRepository.GetUserAsync(email, password);
        return _mapper.Map<Users, UserResponse>(user);;
    }

    public async Task<UserResponse> RegisterUser(RegisterModel registerModel)
    {
        var user = _mapper.Map<RegisterModel, Users>(registerModel);
        await _userRepository.AddUserAsync(user);
        var userDb = await _userRepository.GetUserAsync(user.Email, user.Password);
        return _mapper.Map<Users, UserResponse>(userDb);
    }
}