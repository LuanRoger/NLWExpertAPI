using Microsoft.EntityFrameworkCore;
using NLWExpertAPI.Context;
using NLWExpertAPI.Endpoints;
using NLWExpertAPI.Services;
using NLWExpertAPI.Services.Auth;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services
    .ConfigureServices(builder.Configuration)
    .AddConfiguration()
    .AddSqliteContext()
    .AddMappers()
    .AddRepositories()
    .AddCustomControllers()
    .AddAuth()
    .AddSwaggerDependencies();

WebApplication app = builder.Build();

if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    using IServiceScope serviceScope = app.Services.CreateScope();
    AppDbContext context = serviceScope.ServiceProvider.GetRequiredService<AppDbContext>();
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