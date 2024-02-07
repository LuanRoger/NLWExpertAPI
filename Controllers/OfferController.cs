using NLWExpertAPI.Exceptions;
using NLWExpertAPI.Mappers.Interfaces;
using NLWExpertAPI.Models;
using NLWExpertAPI.Models.Dto;
using NLWExpertAPI.Repositories;

namespace NLWExpertAPI.Controllers;

public class OfferController(
    IOfferRepository offerRepository,
    IUserRepository userRepository,
    IOfferMapper offerMapper
    ) : IOfferController
{
    public async Task<OfferDto> CreateNewOffer(CreateNewOfferRequest request, int userId)
    {
        User? user = await userRepository.GetUserById(userId);
        if(user is null)
            throw new EntityNotFoundException(nameof(userId), userId.ToString());
        
        DateTime now = DateTime.Now;
        Offer newOffer = new()
        {
            createdAt = now,
            price = request.price,
            itemId = request.itemId,
            userId = userId
        };
        newOffer = await offerRepository.CreateNewOffer(newOffer);
        await offerRepository.FlushChanges();

        OfferDto offerDto = offerMapper.ToDto(newOffer);
        return offerDto;
    }
}