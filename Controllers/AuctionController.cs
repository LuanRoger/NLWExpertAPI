using NLWExpertAPI.Models.Dto;

namespace NLWExpertAPI.Controllers;

public class AuctionController : IAuctionController
{
    public AuctionDto GetAuction()
    {
        return new()
        {
            nome = "Leilão de um carro",
            starts = DateTime.Now,
            ends = DateTime.Now.AddDays(1),
        };
    }
}