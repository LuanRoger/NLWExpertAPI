using NLWExpertAPI.Models;
using NLWExpertAPI.Models.Dto;

namespace NLWExpertAPI.Mappers.Interfaces;

public interface IOfferMapper
{
    public abstract OfferDto ToDto(Offer offer);
}