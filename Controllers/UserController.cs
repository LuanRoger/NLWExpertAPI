using NLWExpertAPI.Endpoints.RequestResponseModels;
using NLWExpertAPI.Exceptions;
using NLWExpertAPI.Mappers.Interfaces;
using NLWExpertAPI.Models;
using NLWExpertAPI.Models.Dto;
using NLWExpertAPI.Repositories;
using NLWExpertAPI.Services.Jwt;
using NLWExpertAPI.Services.Jwt.Models;

namespace NLWExpertAPI.Controllers;

public class UserController(
    IUserRepository userRepository,
    IJwtService jwtService, 
    IUserMapper userMapper,
    IRegisterNewUserMapper registerNewUserMapper
) : IUserController
{
    public async Task<UserDto> RegisterNewUser(RegisterNewUserRequest request)
    {
        User newUser = registerNewUserMapper.MapToConcreteUser(request);
        
        newUser = await userRepository.CreateNewUser(newUser);
        await userRepository.FlushChanges();
        
        UserDto newUserDto = userMapper.ToDto(newUser);
        return newUserDto;
    }
    
    public async Task<string> LoginUser(LoginUserRequest request)
    {
        string userEmail = request.email;
        User? user = await userRepository.GetUserByEmail(userEmail);
        if(user is null)
            throw new EntityNotFoundException(nameof(userEmail), userEmail);
        if(user.senha != request.senha)
            throw new WrongUserPasswordException(userEmail);

        JwtPayload payload = new(user.id);
        string userToken = jwtService.GenerateJwt(payload);

        return userToken;
    }
}