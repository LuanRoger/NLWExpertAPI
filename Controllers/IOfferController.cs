using NLWExpertAPI.Endpoints.RequestResponseModels;
using NLWExpertAPI.Models.Dto;

namespace NLWExpertAPI.Controllers;

public interface IOfferController
{
    public Task<OfferDto> CreateNewOffer(CreateNewOfferRequest request, int itemId, int userId);
}