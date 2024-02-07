namespace NLWExpertAPI.Utils;

internal static class EnvVars
{
    public const string SQLITE_CONNECTION_STRING = "SQLITE_CONNECTION_STRING";
    public const string JWT_KEY = "JWT_KEY";
        
    public static string? GetSqliteConnectionString() =>
        Environment.GetEnvironmentVariable(SQLITE_CONNECTION_STRING);
    public static string? GetJwtKey() =>
        Environment.GetEnvironmentVariable(JWT_KEY);
}