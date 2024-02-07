using NLWExpertAPI.Models.Enums;

namespace NLWExpertAPI.Models;

public class Item
{
    public int id { get; set; }
    public string nome { get; set; }
    public string brand { get; set; }
    public Condition condition { get; set; }
    public decimal bestPrice { get; set; }
    public int auctionId { get; set; }
}