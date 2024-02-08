using NLWExpertAPI.Models;

namespace NLWExpertAPI.Repositories;

public interface IOfferRepository
{
    public Task<Offer> CreateNewOffer(Offer offer);
    public Task FlushChanges();
}