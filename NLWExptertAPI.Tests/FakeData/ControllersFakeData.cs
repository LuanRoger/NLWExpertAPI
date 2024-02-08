using NLWExpertAPI.Endpoints.RequestResponseModels;
using NLWExpertAPI.Models;

namespace NLWExptertAPI.Tests.FakeData;

public static class ControllersFakeData
{
    public static RegisterNewUserRequest RegisterNewUserRequest => new()
    {
        nome = "test",
        email = "test@test.com",
        senha = "test"
    };

    public static User User => new()
    {
        nome = "test",
        email = "test@test.com",
        senha = "test123"
    };

    public static LoginUserRequest LoginUserRequest => new()
    {
        email = "test@test.com",
        senha = "test123"
    };

    public const string JWT_USER_TOKEN = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJuYmYiOjE3MDc0MTQzMDQsImV4cCI6MTcwNzQzMjMwNCwiaWF0IjoxNzA3NDE0MzA0LCJpc3MiOiJOTFdFeHBlcnRBUEkiLCJhdWQiOiJOTFdFeHBlcnRGcm9udGVuZCJ9.8rk1KCJziLtCL9QsY4vB8KR9cd7KqbpJ4iIfjhPf16Q";
}