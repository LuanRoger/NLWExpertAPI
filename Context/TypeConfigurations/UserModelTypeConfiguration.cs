using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLWExpertAPI.Models;

namespace NLWExpertAPI.Context.TypeConfigurations;

public class UserModelTypeConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
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
            .HasIndex(f => f.email)
            .IsUnique();
        builder
            .Property(f => f.email)
            .IsRequired();
        builder
            .Property(f => f.senha)
            .HasMaxLength(50)
            .IsRequired();

    }
}