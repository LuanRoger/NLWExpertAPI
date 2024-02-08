using NLWExpertAPI.Endpoints.RequestResponseModels;
using NLWExpertAPI.Mappers.Interfaces;
using NLWExpertAPI.Models;
using Riok.Mapperly.Abstractions;

namespace NLWExpertAPI.Mappers.RequestModelsMappers;

[Mapper]
public partial class CreateNewAuctionMapper : ICreateNewAuctionMapper
{
    [UseMapper]
    private readonly NewItemForAuctionMapper _newItemForAuctionMapper = new();
    
    public partial Auction ToConcreteAuction(CreateNewAuctionRequest request);
}