using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLWExpertAPI.Models;

namespace NLWExpertAPI.Context.TypeConfigurations;

public class OfferModelTypeConfiguration : IEntityTypeConfiguration<Offer>
{
    public void Configure(EntityTypeBuilder<Offer> builder)
    {
        builder
            .ToTable("Offers");
        builder
            .HasKey(f => f.id);
        builder
            .Property(f => f.id)
            .ValueGeneratedOnAdd();
        builder
            .Property(f => f.createdAt)
            .IsRequired();
        builder
            .Property(f => f.price)
            .IsRequired();
        builder
            .HasOne<Item>()
            .WithOne()
            .HasForeignKey<Offer>(f => f.itemId)
            .IsRequired();
        builder
            .HasOne<User>(f => f.user)
            .WithOne()
            .HasForeignKey<Offer>(f => f.userId)
            .IsRequired();
    }
}