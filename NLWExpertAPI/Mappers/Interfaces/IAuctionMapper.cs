using NLWExpertAPI.Models;
using NLWExpertAPI.Models.Dto;

namespace NLWExpertAPI.Mappers.Interfaces;

public interface IAuctionMapper
{
    public abstract AuctionDto ToDto(Auction auction);
}