using NLWExpertAPI.Mappers.Interfaces;
using NLWExpertAPI.Models;
using NLWExpertAPI.Models.Dto;
using Riok.Mapperly.Abstractions;

namespace NLWExpertAPI.Mappers;

[Mapper]
public partial class AuctionMapper : IAuctionMapper
{
    public partial AuctionDto ToDto(Auction auction);
}