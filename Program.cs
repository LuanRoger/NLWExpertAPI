using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using NLWExpertAPI.Context;
using NLWExpertAPI.Controllers;
using NLWExpertAPI.Endpoints;
using NLWExpertAPI.Exceptions;
using NLWExpertAPI.Mappers;
using NLWExpertAPI.Mappers.Interfaces;
using NLWExpertAPI.Mappers.RequestModelsMappers;
using NLWExpertAPI.Models;
using NLWExpertAPI.Repositories;
using NLWExpertAPI.Services.Auth;
using NLWExpertAPI.Services.Jwt;
using NLWExpertAPI.Utils;
WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    string? connectionString = EnvVars.GetSqliteConnectionString();
    if(connectionString is null)
        throw new EnvironmentVariableIsNullOrEmptyException(nameof(EnvVars.SQLITE_CONNECTION_STRING));
    
    options.UseSqlite(connectionString);
});

builder.Services.Configure<JwtParametersOption>(builder
    .Configuration
    .GetSection(JwtParametersOption.JWT_PARAMETERS));

builder.Services.AddTransient<IConfigureOptions<JwtBearerOptions>, AuthenticationJwtBearerConfiguration>();
builder.Services.AddSingleton<IJwtService, JwtService>();

builder.Services.AddScoped<IItemMapper, ItemMapper>();
builder.Services.AddScoped<IAuctionMapper, AuctionMapper>();
builder.Services.AddScoped<IOfferMapper, OfferMapper>();
builder.Services.AddScoped<IUserMapper, UserMapper>();
builder.Services.AddScoped<IRegisterNewUserMapper, RegisterNewUserMapper>();

builder.Services.AddScoped<IAuctionRepository, AuctionRepository>();
builder.Services.AddScoped<IOfferRepository, OfferRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IAuctionController, AuctionController>();
builder.Services.AddScoped<IOfferController, OfferController>();
builder.Services.AddScoped<IUserController, UserController>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer();
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy(AuthorizationPolicies.REQUIRE_IDENTIFIER, 
        AuthorizationPolicies.RequireIdentifierAndUserRole);
});

WebApplication app = builder.Build();

if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    using IServiceScope serviceScope = app.Services.CreateScope();
    AppDbContext context = serviceScope.ServiceProvider.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
    context.Database.Migrate();
}

RouteGroupBuilder authGroup = app.MapGroup("auth")
    .WithTags("Auth")
    .AllowAnonymous();
authGroup.MapUserEndpoints();

RouteGroupBuilder auctionGroup = app.MapGroup("auction")
    .WithTags("Auction")
    .RequireAuthorization(AuthorizationPolicies.REQUIRE_IDENTIFIER);
auctionGroup.MapAuctionEndpoints();

RouteGroupBuilder offerGroup = app.MapGroup("offer")
    .WithTags("Offer")
    .RequireAuthorization(AuthorizationPolicies.REQUIRE_IDENTIFIER);
offerGroup.MapOfferEndpoints();

app.Run();