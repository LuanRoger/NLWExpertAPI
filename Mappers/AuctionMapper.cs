using NLWExpertAPI.Mappers.Interfaces;
using NLWExpertAPI.Models;
using NLWExpertAPI.Models.Dto;
using Riok.Mapperly.Abstractions;

namespace NLWExpertAPI.Mappers;

[Mapper]
public partial class AuctionMapper : IAuctionMapper
{
    [UseMapper] private readonly ItemMapper _itemMapper = new();
    
    public partial AuctionDto ToDto(Auction auction);
}