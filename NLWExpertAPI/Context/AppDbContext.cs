using Microsoft.EntityFrameworkCore;
using NLWExpertAPI.Context.TypeConfigurations;
using NLWExpertAPI.Models;

namespace NLWExpertAPI.Context;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Auction> auctions { get; set; } = null!;
    public DbSet<Item> items { get; set; } = null!;
    public DbSet<Offer> offers { get; set; } = null!;
    public DbSet<User> users { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        new AuctionModelTypeConfiguration().Configure(modelBuilder.Entity<Auction>());
        new ItemModelTypeConfiguration().Configure(modelBuilder.Entity<Item>());
        new OfferModelTypeConfiguration().Configure(modelBuilder.Entity<Offer>());
        new UserModelTypeConfiguration().Configure(modelBuilder.Entity<User>());
    }
}