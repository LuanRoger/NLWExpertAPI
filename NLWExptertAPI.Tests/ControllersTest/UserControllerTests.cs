using Moq;
using NLWExpertAPI.Controllers;
using NLWExpertAPI.Endpoints.RequestResponseModels;
using NLWExpertAPI.Exceptions;
using NLWExpertAPI.Mappers;
using NLWExpertAPI.Mappers.Interfaces;
using NLWExpertAPI.Mappers.RequestModelsMappers;
using NLWExpertAPI.Models;
using NLWExpertAPI.Models.Dto;
using NLWExpertAPI.Repositories;
using NLWExpertAPI.Services.Jwt;
using NLWExpertAPI.Services.Jwt.Models;
using NLWExptertAPI.Tests.FakeData;

namespace NLWExptertAPI.Tests.ControllersTest;

public class UserControllerTests
{
    private readonly Mock<IUserRepository> _userRepository;
    private readonly Mock<IJwtService> _jwtService;
    private readonly UserController _userController;
    
    public UserControllerTests()
    {
        _userRepository = new();
        _jwtService = new();
        IUserMapper userMapper = new UserMapper();
        IRegisterNewUserMapper registerNewUserMapper = new RegisterNewUserMapper();
        _userController = new(_userRepository.Object, _jwtService.Object, 
            userMapper, registerNewUserMapper);
    }

    [Fact]
    public async void MustRegisterNewUser()
    {
        RegisterNewUserRequest request = ControllersFakeData.RegisterNewUserRequest;
        User newUser = ControllersFakeData.User;
        _userRepository.Setup(ex => 
                ex.CreateNewUser(It.Is<User>(user => user.email == request.email)))
            .ReturnsAsync(newUser);
        
        UserDto newUserDto = await _userController.RegisterNewUser(request);
        
        Assert.Equal(newUser.id, newUserDto.id);
        Assert.Equal(newUser.nome, newUserDto.nome);
        Assert.Equal(newUser.email, newUserDto.email);
    }
    
    [Fact]
    public async void MustLoginUser()
    {
        LoginUserRequest request = ControllersFakeData.LoginUserRequest;
        User user = ControllersFakeData.User;
        const string userToken = ControllersFakeData.JWT_USER_TOKEN;
        
        _userRepository.Setup(ex => 
                ex.GetUserByEmail(request.email))
            .ReturnsAsync(user);
        _jwtService.Setup(ex => 
                ex.GenerateJwt(
                    It.Is<JwtPayload>(payload => payload.userId == user.id)))
            .Returns(userToken);
        
        string loginUserToken = await _userController.LoginUser(request);
        
        Assert.NotNull(userToken);
        Assert.Equal(userToken, loginUserToken);
    }
    
    [Fact]
    public void MustThrowEntityNotFoundExceptionWhenUserNotFound()
    {
        LoginUserRequest request = ControllersFakeData.LoginUserRequest;
        _userRepository.Setup(ex => 
                ex.GetUserByEmail(request.email))
            .ReturnsAsync(() => null);
        
        Assert.ThrowsAsync<EntityNotFoundException>(() => 
            _userController.LoginUser(request));
    }
    
    [Fact]
    public void MustThrowWrongUserPasswordExceptionWhenPasswordIsWrong()
    {
        LoginUserRequest request = ControllersFakeData.LoginUserRequest;
        User user = ControllersFakeData.User;
        user.senha = "wrongPassword";
        _userRepository.Setup(ex => 
                ex.GetUserByEmail(request.email))
            .ReturnsAsync(user);
        
        Assert.ThrowsAsync<WrongUserPasswordException>(() => 
            _userController.LoginUser(request));
    }
}