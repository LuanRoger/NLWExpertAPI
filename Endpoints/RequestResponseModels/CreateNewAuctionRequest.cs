namespace NLWExpertAPI.Endpoints.RequestResponseModels;

public class CreateNewAuctionRequest
{
    public string nome { get; init; }
    public DateTime ends { get; init; }
    public IEnumerable<NewItemForAuctionRequest> items { get; init; }
}