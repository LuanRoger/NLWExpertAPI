using NLWExpertAPI.Mappers.Interfaces;
using NLWExpertAPI.Models;
using NLWExpertAPI.Models.Dto;
using Riok.Mapperly.Abstractions;

namespace NLWExpertAPI.Mappers;

[Mapper]
public partial class UserMapper : IUserMapper
{
    public partial UserDto ToDto(User user);
}