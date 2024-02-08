namespace NLWExpertAPI.Models;

public class JwtParametersOption
{
    public const string JWT_PARAMETERS = "JWTParameters";
    
    public string issuer { get; set; } = string.Empty;
    public string audience { get; set; } = string.Empty;
}