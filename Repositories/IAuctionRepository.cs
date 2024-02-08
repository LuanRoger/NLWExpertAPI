using NLWExpertAPI.Models;

namespace NLWExpertAPI.Repositories;

public interface IAuctionRepository
{
    public Task<Auction?> GetAuctionById(int id);
    public Task<IEnumerable<Auction>> GetAllActions();
    public Task<Auction?> GetActiveAuctionByTime(DateTime time);
    public Task<Auction> AddNewAction(Auction auction);
    public Task FlushChanges();
}