using Microsoft.AspNetCore.Mvc;
using NLWExpertAPI.Controllers;
using NLWExpertAPI.Endpoints.RequestResponseModels;
using NLWExpertAPI.Exceptions;
using NLWExpertAPI.Models.Dto;

namespace NLWExpertAPI.Endpoints;

public static class AuctionEndpoints
{
    public static RouteGroupBuilder MapAuctionEndpoints(this RouteGroupBuilder builder)
    {
        builder.MapGet("/", GetAllAuctions);
        builder.MapGet("/{id:int}", GetAuctionById);
        builder.MapGet("/active", GetActiveAuctionsTime);
        builder.MapPost("/", PostNewAuction);

        return builder;
    }
    async private static Task<IResult> PostNewAuction(HttpContext context,
        [FromBody] CreateNewAuctionRequest request,
        [FromServices] IAuctionController controller)
    {
        AuctionDto newAuction = await controller.CreateNewAuction(request);
        
        return Results.Created($"/auction/{newAuction.id}", newAuction);
    }

    [ProducesResponseType(typeof(AuctionDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    async private static Task<IResult> GetAuctionById(HttpContext context, 
        [FromRoute] int id, 
        [FromServices] IAuctionController controller)
    {
        AuctionDto auctionResult;
        try
        {
            auctionResult = await controller.GetAuctionById(id);
        }
        catch (Exception) { return Results.NotFound(); }

        return Results.Ok(auctionResult);
    }
    
    [ProducesResponseType(typeof(ICollection<AuctionDto>), StatusCodes.Status200OK)]
    async private static Task<IResult> GetAllAuctions(HttpContext context,
        [FromServices] IAuctionController controller)
    {
        var auction = await controller.GetAllAuction();
        return Results.Ok(auction);
    }
    
    [ProducesResponseType(typeof(AuctionDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    async private static Task<IResult> GetActiveAuctionsTime(HttpContext context,
        [FromServices] IAuctionController controller)
    {
        AuctionDto auctionResult;
        try
        {
            auctionResult = await controller.GetActiveAuctionByTime();
        }
        catch (NoActiveAuctionByTimeException) { return Results.NoContent(); }
        catch (Exception) { return Results.NotFound(); }
        
        return Results.Ok(auctionResult);
    }
}