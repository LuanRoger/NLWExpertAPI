using NLWExpertAPI.Models.Enums;

namespace NLWExpertAPI.Endpoints.RequestResponseModels;

public class NewItemForAuctionRequest
{
    public string nome { get; init; }
    public string brand { get; init; }
    public Condition condition { get; init; }
    public decimal bestPrice { get; init; }
}