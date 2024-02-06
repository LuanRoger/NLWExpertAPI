namespace NLWExpertAPI.Models;

public class Item
{
    public int id { get; set; }
    public string nome { get; set; }
    public string brand { get; set; }
    public int condition { get; set; }
    public decimal bestPrice { get; set; }
    public int auctionId { get; set; }
}