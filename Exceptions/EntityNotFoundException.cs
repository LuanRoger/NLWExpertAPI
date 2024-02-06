namespace NLWExpertAPI.Exceptions;

public class EntityNotFoundException(string property, string propertyValue) : 
    Exception(string.Format(MESSAGE, property, propertyValue))
{
    private const string MESSAGE = "The entity with {0}[{1}] was not found";
}