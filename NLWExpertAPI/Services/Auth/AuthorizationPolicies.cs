using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace NLWExpertAPI.Services.Auth;

public static class AuthorizationPolicies
{
    public const string REQUIRE_IDENTIFIER = "RequireIdentifier";
    
    public static void RequireIdentifierAndUserRole(AuthorizationPolicyBuilder builder)
    {
        builder.RequireClaim(ClaimTypes.Name);
    }
}