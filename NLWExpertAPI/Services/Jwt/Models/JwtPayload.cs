using System.Security.Claims;

namespace NLWExpertAPI.Services.Jwt.Models;

public record JwtPayload(int userId)
{
    public ClaimsIdentity CreateClaimsIdentity()
    {
        ClaimsIdentity claims = new();
        claims.AddClaims(new Claim[]
        {
            new(ClaimTypes.Name, userId.ToString()),
        });
        
        return claims;
    }
}