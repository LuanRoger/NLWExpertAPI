namespace NLWExpertAPI.Exceptions;

public class EnvironmentVariableIsNullOrEmptyException(string? envVarName) : 
    Exception(string.Format(MESSAGE, envVarName))
{
    private const string MESSAGE = "Environment variable {0} is null or empty and it is required.";
}