using NLWExpertAPI.Exceptions;
using NLWExpertAPI.Mappers.Interfaces;
using NLWExpertAPI.Models;
using NLWExpertAPI.Models.Dto;
using NLWExpertAPI.Repositories;

namespace NLWExpertAPI.Controllers;

public class AuctionController(
    IAuctionRepository auctionRepository,
    IAuctionMapper auctionMapper
    ) : IAuctionController
{
    public async Task<AuctionDto> GetAuctionById(int id)
    {
        Auction? auction = await auctionRepository.GetAuctionById(id);
        if(auction is null)
            throw new EntityNotFoundException(nameof(id), id.ToString());

        AuctionDto auctionDto = auctionMapper.ToDto(auction);

        return auctionDto;
    }
    public async Task<List<AuctionDto>> GetAllAuction()
    {
        var auctions = await auctionRepository.GetAllActions();
        var dtoAuctions = auctions.Select(auctionMapper.ToDto)
            .ToList();

        return dtoAuctions;
    }
    public async Task<AuctionDto> GetActiveAuctionByTime()
    {
        DateTime now = DateTime.Now;
        Auction? auction = await auctionRepository.GetActiveAuctionByTime(now);
        if(auction is null)
            throw new NoActiveAuctionByTimeException(now);

        AuctionDto dtoAuction = auctionMapper.ToDto(auction);

        return dtoAuction;
    }
}