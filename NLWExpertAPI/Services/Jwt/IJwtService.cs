using NLWExpertAPI.Services.Jwt.Models;

namespace NLWExpertAPI.Services.Jwt;

public interface IJwtService
{
    public string GenerateJwt(JwtPayload payload);
}