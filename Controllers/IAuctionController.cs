using NLWExpertAPI.Models.Dto;

namespace NLWExpertAPI.Controllers;

public interface IAuctionController
{
    public AuctionDto GetAuction();
}