using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using NLWExpertAPI.Controllers;
using NLWExpertAPI.Endpoints.RequestResponseModels;
using NLWExpertAPI.Exceptions;
using NLWExpertAPI.Models.Dto;

namespace NLWExpertAPI.Endpoints;

public static class OfferEndpoints
{
    public static RouteGroupBuilder MapOfferEndpoints(this RouteGroupBuilder builder)
    {
        builder.MapPost("/{itemId:int}", PostCreateNewOffer);

        return builder;
    }
    async private static Task<IResult> PostCreateNewOffer(HttpContext context,
        [FromRoute] int itemId,
        [FromBody] CreateNewOfferRequest request,
        [FromServices] IOfferController controller)
    {
        int userId = int.Parse(context.User.Claims
            .First(c => c.Type == ClaimTypes.Name).Value);
        
        OfferDto createdOffer;
        try
        {
            createdOffer = await controller.CreateNewOffer(request, itemId, userId);
        }
        catch (EntityNotFoundException) { return Results.NotFound(); }
        catch (Exception) { return Results.BadRequest(); }

        return Results.Created($"/offer/{itemId}/", createdOffer);
    }
}