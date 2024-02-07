using NLWExpertAPI.Models;
using NLWExpertAPI.Models.Dto;

namespace NLWExpertAPI.Mappers.Interfaces;

public interface IUserMapper
{
    public abstract UserDto ToDto(User user);
}