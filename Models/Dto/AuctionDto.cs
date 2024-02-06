namespace NLWExpertAPI.Models.Dto;

public class AuctionDto
{
    public required string nome { get; init; }
    public required DateTime starts { get; init; }
    public required DateTime ends { get; init; }
    public IReadOnlyCollection<Item> items { get; init; } = new List<Item>();
}