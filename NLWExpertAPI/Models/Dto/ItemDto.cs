namespace NLWExpertAPI.Models.Dto;

public class ItemDto
{
    public string nome { get; set; }
    public string brand { get; set; }
    public int condition { get; set; }
    public decimal bestPrice { get; set; }
    public int auctionId { get; set; }
}