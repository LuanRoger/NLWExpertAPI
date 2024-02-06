using Microsoft.EntityFrameworkCore;
using NLWExpertAPI.Context;
using NLWExpertAPI.Controllers;
using NLWExpertAPI.Endpoints;
WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlite("Data Source=nlwexpert.db");
});
builder.Services.AddScoped<IAuctionController, AuctionController>();

WebApplication app = builder.Build();

if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    using IServiceScope serviceScope = app.Services.CreateScope();
    AppDbContext context = serviceScope.ServiceProvider.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}

RouteGroupBuilder auctionGroup = app.MapGroup("action");
auctionGroup.MapAuctionEndpoints();

app.Run();