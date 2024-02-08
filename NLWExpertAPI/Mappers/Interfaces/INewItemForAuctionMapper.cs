using NLWExpertAPI.Endpoints.RequestResponseModels;
using NLWExpertAPI.Models;

namespace NLWExpertAPI.Mappers.Interfaces;

public interface INewItemForAuctionMapper
{
    public abstract Item ToConcreteItem(NewItemForAuctionRequest request);
}