using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLWExpertAPI.Models;

namespace NLWExpertAPI.Context.TypeConfigurations;

public class AuctionModelTypeConfiguration : IEntityTypeConfiguration<Auction>
{
    public void Configure(EntityTypeBuilder<Auction> builder)
    {
        builder
            .ToTable("Auctions");
        builder
            .HasKey(f => f.id);
        builder.Property(f => f.nome)
            .HasMaxLength(100)
            .IsRequired();
        builder.Property(f => f.starts)
            .IsRequired();
        builder.Property(f => f.ends)
            .IsRequired();
        builder
            .HasMany(f => f.items)
            .WithOne()
            .HasForeignKey(f => f.auctionId)
            .IsRequired();
    }
}