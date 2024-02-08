using NLWExpertAPI.Endpoints.RequestResponseModels;
using NLWExpertAPI.Models;

namespace NLWExpertAPI.Mappers.Interfaces;

public interface IRegisterNewUserMapper
{
    public abstract User ToConcreteUser(RegisterNewUserRequest request);
}