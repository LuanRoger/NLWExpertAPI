using NLWExpertAPI.Endpoints.RequestResponseModels;
using NLWExpertAPI.Mappers.Interfaces;
using NLWExpertAPI.Models;
using Riok.Mapperly.Abstractions;

namespace NLWExpertAPI.Mappers.RequestModelsMappers;

[Mapper]
public partial class RegisterNewUserMapper : IRegisterNewUserMapper
{
    public partial User MapToConcreteUser(RegisterNewUserRequest request);
}