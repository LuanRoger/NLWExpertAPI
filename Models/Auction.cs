namespace NLWExpertAPI.Models;

public class Auction
{
    public int id { get; set; }
    public string nome { get; set; }
    public DateTime starts { get; set; }
    public DateTime ends { get; set; }
}