using NLWExpertAPI.Context;
using NLWExpertAPI.Models;

namespace NLWExpertAPI.Repositories;

public class OfferRepository(AppDbContext dbContext) : IOfferRepository
{
    public async Task<Offer> CreateNewOffer(Offer offer)
    {
        var newEntity = await dbContext.offers.AddAsync(offer);
        Offer createdOffer = newEntity.Entity;
        return createdOffer;
    }
    
    public async Task FlushChanges() =>
        await dbContext.SaveChangesAsync();
}