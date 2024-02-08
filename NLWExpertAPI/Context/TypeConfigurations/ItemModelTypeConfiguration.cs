using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLWExpertAPI.Models;

namespace NLWExpertAPI.Context.TypeConfigurations;

public class ItemModelTypeConfiguration : IEntityTypeConfiguration<Item>
{
    public void Configure(EntityTypeBuilder<Item> builder)
    {
        builder
            .ToTable("Items");
        builder
            .HasKey(f => f.id);
        builder
            .Property(f => f.id)
            .ValueGeneratedOnAdd();
        builder
            .Property(f => f.nome)
            .HasMaxLength(100)
            .IsRequired();
        builder
            .Property(f => f.brand)
            .HasMaxLength(100)
            .IsRequired();;
        builder
            .Property(f => f.condition)
            .IsRequired();
        builder
            .Property(f => f.bestPrice)
            .IsRequired();
        builder
            .HasOne<Auction>()
            .WithMany(f => f.items)
            .HasForeignKey(f => f.auctionId)
            .IsRequired();
    }
}