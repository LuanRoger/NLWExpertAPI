using NLWExpertAPI.Models;
using NLWExpertAPI.Models.Dto;

namespace NLWExpertAPI.Controllers;

public interface IOfferController
{
    public Task<OfferDto> CreateNewOffer(CreateNewOfferRequest request, int userId);
}