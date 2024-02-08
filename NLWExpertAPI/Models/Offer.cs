namespace NLWExpertAPI.Models;

public class Offer
{
    public int id { get; set; }
    public DateTime createdAt { get; set; }
    public decimal price { get; set; }
    public int itemId { get; set; }
    public User user { get; set; }
    public int userId { get; set; }
}