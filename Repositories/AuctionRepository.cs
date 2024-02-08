using Microsoft.EntityFrameworkCore;
using NLWExpertAPI.Context;
using NLWExpertAPI.Models;

namespace NLWExpertAPI.Repositories;

public class AuctionRepository(AppDbContext db) : IAuctionRepository
{
    public async Task<Auction?> GetAuctionById(int id) =>
        await db.auctions.FindAsync(id);
    public async Task<IEnumerable<Auction>> GetAllActions() =>
        await db.auctions
            .Include(f => f.items)
            .AsNoTracking()
            .ToListAsync();
    public async Task<Auction?> GetActiveAuctionByTime(DateTime time) =>
        await db.auctions
            .FirstOrDefaultAsync(a => a.starts <= time && a.ends >= time);
    public async Task<Auction> AddNewAction(Auction auction)
    {
        var newEntity = await db.auctions.AddAsync(auction);
        Auction newAuction = newEntity.Entity;
        return newAuction;
    }
    
    public async Task FlushChanges() =>
        await db.SaveChangesAsync();
}