namespace NLWExpertAPI.Exceptions;

public class NoActiveAuctionByTimeException(DateTime time) 
    : Exception(string.Format(MESSAGE, time))
{
    private const string MESSAGE = "There is no active auction at the moment DateTime[{0}]";
}