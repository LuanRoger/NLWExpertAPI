using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NLWExpertAPI.Exceptions;
using NLWExpertAPI.Models;
using NLWExpertAPI.Utils;
using JwtPayload = NLWExpertAPI.Services.Jwt.Models.JwtPayload;

namespace NLWExpertAPI.Services.Jwt;

public class JwtService : IJwtService
{
    private readonly JwtParametersOption _options;
    private readonly string _privateKey;

    private SigningCredentials credentials
    {
        get
        {
            byte[] privateKeyByte = Encoding.ASCII.GetBytes(_privateKey);
            
            return new(new SymmetricSecurityKey(privateKeyByte), SecurityAlgorithms.HmacSha256);
        }
    }

    public JwtService(IOptions<JwtParametersOption> options)
    {
        _options = options.Value;
        _privateKey = EnvVars.GetJwtSecret() ?? 
                      throw new EnvironmentVariableIsNullOrEmptyException(nameof(EnvVars.JWT_KEY));
    }
    
    public string GenerateJwt(JwtPayload payload)
    {
        JwtSecurityTokenHandler tokenHandler = new();
        
        SecurityToken securityToken = tokenHandler.CreateToken(new()
        {
            SigningCredentials = credentials,
            Issuer = _options.issuer,
            IssuedAt = DateTime.Now,
            Expires = DateTime.Now.AddHours(5),
            Audience = _options.audience,
            Subject = payload.CreateClaimsIdentity()
        });
        
        return tokenHandler.WriteToken(securityToken);
    }
}