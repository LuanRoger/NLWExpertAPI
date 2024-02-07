using Microsoft.EntityFrameworkCore;
using NLWExpertAPI.Context;
using NLWExpertAPI.Controllers;
using NLWExpertAPI.Endpoints;
using NLWExpertAPI.Mappers;
using NLWExpertAPI.Mappers.Interfaces;
using NLWExpertAPI.Repositories;
WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlite("Data Source=nlwexpert.db");
});

builder.Services.AddScoped<IItemMapper, ItemMapper>();
builder.Services.AddScoped<IAuctionMapper, AuctionMapper>();
builder.Services.AddScoped<IOfferMapper, OfferMapper>();

builder.Services.AddScoped<IAuctionRepository, AuctionRepository>();
builder.Services.AddScoped<IOfferRepository, OfferRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IAuctionController, AuctionController>();
builder.Services.AddScoped<IOfferController, OfferController>();

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

RouteGroupBuilder auctionGroup = app.MapGroup("auction");
auctionGroup.MapAuctionEndpoints();

RouteGroupBuilder offerGroup = app.MapGroup("offer");
offerGroup.MapOfferEndpoints();

app.Run();