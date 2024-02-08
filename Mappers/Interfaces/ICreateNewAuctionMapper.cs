using NLWExpertAPI.Endpoints.RequestResponseModels;
using NLWExpertAPI.Models;

namespace NLWExpertAPI.Mappers.Interfaces;

public interface ICreateNewAuctionMapper
{
    public abstract Auction ToConcreteAuction(CreateNewAuctionRequest request);
}