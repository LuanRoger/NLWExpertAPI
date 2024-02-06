using Microsoft.AspNetCore.Mvc;
using NLWExpertAPI.Controllers;
using NLWExpertAPI.Models.Dto;

namespace NLWExpertAPI.Endpoints;

public static class AuctionEndpoints
{
    public static RouteGroupBuilder MapAuctionEndpoints(this RouteGroupBuilder builder)
    {
        builder.MapGet("/", GetAuction);

        return builder;
    }
    private static IResult GetAuction(HttpContext context,
        [FromServices] IAuctionController controller)
    {
        AuctionDto auction = controller.GetAuction();
        return Results.Ok(auction);
    }
}