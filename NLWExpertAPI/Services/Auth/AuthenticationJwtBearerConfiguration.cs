﻿using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NLWExpertAPI.Exceptions;
using NLWExpertAPI.Models;
using NLWExpertAPI.Utils;

namespace NLWExpertAPI.Services.Auth;

public class AuthenticationJwtBearerConfiguration : IConfigureNamedOptions<JwtBearerOptions>
{
    private readonly JwtParametersOption _jwtOptions;
    private readonly string _privateKey;

    public AuthenticationJwtBearerConfiguration(IOptions<JwtParametersOption> jwtOptions)
    {
        _jwtOptions = jwtOptions.Value;
        _privateKey = EnvVars.GetJwtSecret() ?? 
                      throw new EnvironmentVariableIsNullOrEmptyException(nameof(EnvVars.JWT_KEY));
    }
    
    public void Configure(string? name, JwtBearerOptions options)
    {
        byte[] privateKeyByte = Encoding.ASCII.GetBytes(_privateKey);
    
        options.TokenValidationParameters = new()
        {
            ValidateIssuer = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidateAudience = true,
            ValidIssuer = _jwtOptions.issuer,
            ValidAudience = _jwtOptions.audience,
            IssuerSigningKey = new SymmetricSecurityKey(privateKeyByte),
            ValidAlgorithms = new []{ SecurityAlgorithms.HmacSha256 }
        };
    }
    
    public void Configure(JwtBearerOptions options) =>
        Configure(JwtBearerDefaults.AuthenticationScheme, options);
}