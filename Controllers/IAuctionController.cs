using NLWExpertAPI.Endpoints.RequestResponseModels;
using NLWExpertAPI.Models.Dto;

namespace NLWExpertAPI.Controllers;

public interface IAuctionController
{
    public Task<AuctionDto> GetAuctionById(int id);
    public Task<List<AuctionDto>> GetAllAuction();
    public Task<AuctionDto> GetActiveAuctionByTime();
    public Task<AuctionDto> CreateNewAuction(CreateNewAuctionRequest request);
}