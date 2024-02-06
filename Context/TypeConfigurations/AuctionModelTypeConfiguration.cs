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
            .HasKey(a => a.id);
        builder.Property(p => p.nome)
            .HasMaxLength(100)
            .IsRequired();
        builder.Property(p => p.starts)
            .IsRequired();
        builder.Property(p => p.ends)
            .IsRequired();
    }
}