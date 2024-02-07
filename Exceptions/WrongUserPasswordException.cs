namespace NLWExpertAPI.Exceptions;

public class WrongUserPasswordException(string email) : 
    Exception(string.Format(MESSAGE, email))
{
    private const string MESSAGE = "The password provided is incorrect for user Email[{0}]";
}