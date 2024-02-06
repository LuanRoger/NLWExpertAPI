using Microsoft.EntityFrameworkCore;
using NLWExpertAPI.Context.TypeConfigurations;
using NLWExpertAPI.Models;

namespace NLWExpertAPI.Context;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Auction> auctions { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        new AuctionModelTypeConfiguration().Configure(modelBuilder.Entity<Auction>());
    }
}