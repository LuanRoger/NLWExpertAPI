using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using NLWExpertAPI.Context;
using NLWExpertAPI.Controllers;
using NLWExpertAPI.Exceptions;
using NLWExpertAPI.Mappers;
using NLWExpertAPI.Mappers.Interfaces;
using NLWExpertAPI.Mappers.RequestModelsMappers;
using NLWExpertAPI.Models;
using NLWExpertAPI.Repositories;
using NLWExpertAPI.Services.Auth;
using NLWExpertAPI.Services.Jwt;
using NLWExpertAPI.Utils;

namespace NLWExpertAPI.Services;

public static class Di
{
    public static IServiceCollection ConfigureServices(this IServiceCollection services, 
        IConfigurationManager configuration)
    {
        services.Configure<JwtParametersOption>(
            configuration.GetSection(JwtParametersOption.JWT_PARAMETERS));

        return services;
    }
    public static IServiceCollection AddConfiguration(this IServiceCollection services)
    {
        services.AddTransient<IConfigureOptions<JwtBearerOptions>, AuthenticationJwtBearerConfiguration>();
        services.AddSingleton<IJwtService, JwtService>();

        return services;
    }

    public static IServiceCollection AddSqliteContext(this IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            string? connectionString = EnvVars.GetSqliteConnectionString();
            if(connectionString is null)
                throw new EnvironmentVariableIsNullOrEmptyException(nameof(EnvVars.SQLITE_CONNECTION_STRING));
    
            options.UseSqlite(connectionString);
        });

        return services;
    }

    public static IServiceCollection AddMappers(this IServiceCollection services)
    {
        services.AddScoped<IItemMapper, ItemMapper>();
        services.AddScoped<IAuctionMapper, AuctionMapper>();
        services.AddScoped<IOfferMapper, OfferMapper>();
        services.AddScoped<IUserMapper, UserMapper>();
        services.AddScoped<IRegisterNewUserMapper, RegisterNewUserMapper>();
        services.AddScoped<INewItemForAuctionMapper, NewItemForAuctionMapper>();
        services.AddScoped<ICreateNewAuctionMapper, CreateNewAuctionMapper>();

        return services;
    }
    
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IAuctionRepository, AuctionRepository>();
        services.AddScoped<IOfferRepository, OfferRepository>();
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }

    public static IServiceCollection AddCustomControllers(this IServiceCollection services)
    {
        services.AddScoped<IAuctionController, AuctionController>();
        services.AddScoped<IOfferController, OfferController>();
        services.AddScoped<IUserController, UserController>();

        return services;
    }

    public static IServiceCollection AddAuth(this IServiceCollection services)
    {
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer();
        services.AddAuthorizationBuilder()
            .AddPolicy(AuthorizationPolicies.REQUIRE_IDENTIFIER, 
                AuthorizationPolicies.RequireIdentifierAndUserRole);

        return services;
    }

    public static IServiceCollection AddSwaggerDependencies(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        return services;
    }
}