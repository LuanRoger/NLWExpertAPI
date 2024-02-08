using NLWExpertAPI.Endpoints.RequestResponseModels;
using NLWExpertAPI.Models.Dto;

namespace NLWExpertAPI.Controllers;

public interface IUserController
{
    public Task<UserDto> RegisterNewUser(RegisterNewUserRequest request);
    public Task<string> LoginUser(LoginUserRequest request);
}