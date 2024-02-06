using Microsoft.EntityFrameworkCore;
using NLWExpertAPI.Context;
using NLWExpertAPI.Models;

namespace NLWExpertAPI.Repositories;

public class AuctionRepository(AppDbContext db) : IAuctionRepository
{
    public async Task<Auction?> GetAuctionById(int id) =>
        await db.auctions.FindAsync(id);
    public async Task<IEnumerable<Auction>> GetAllActions()
    {
        return await db.auctions.ToListAsync();
    }
    public async Task<Auction?> GetActiveAuctionByTime(DateTime time) =>
        await db.auctions
            .FirstOrDefaultAsync(a => a.starts <= time && a.ends >= time);
}