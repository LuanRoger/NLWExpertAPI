using Microsoft.AspNetCore.Mvc;
using NLWExpertAPI.Controllers;
using NLWExpertAPI.Endpoints.RequestResponseModels;
using NLWExpertAPI.Exceptions;
using NLWExpertAPI.Models.Dto;

namespace NLWExpertAPI.Endpoints;

public static class UserEndpoints
{
    public static RouteGroupBuilder MapUserEndpoints(this RouteGroupBuilder builder)
    {
        builder.MapPost("/register", PostRegisterNewUser);
        builder.MapPost("/login", PostLoginUser);
        
        return builder;
    }
    async private static Task<IResult> PostRegisterNewUser(HttpContext context,
        [FromBody] RegisterNewUserRequest request,
        [FromServices] IUserController controller)
    {
        //TODO: It will thrown if the email is already in use, catch it later
        UserDto newUser = await controller.RegisterNewUser(request);
        
        return Results.Created($"/user/{newUser.id}", newUser);
    }
    async private static Task<IResult> PostLoginUser(HttpContext context,
        [FromBody] LoginUserRequest request,
        [FromServices] IUserController controller)
    {
        string userJwt;
        try
        {
            userJwt = await controller.LoginUser(request);
        }
        catch(EntityNotFoundException e) { return Results.NotFound(e.Message); }
        catch(WrongUserPasswordException) { return Results.Unauthorized(); }
        
        return Results.Ok(userJwt);
    }
}