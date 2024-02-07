﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NLWExpertAPI.Context;

#nullable disable

namespace NLWExpertAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.1");

            modelBuilder.Entity("NLWExpertAPI.Models.Auction", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("ends")
                        .HasColumnType("TEXT");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("starts")
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("Auctions", (string)null);
                });

            modelBuilder.Entity("NLWExpertAPI.Models.Item", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("auctionId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("bestPrice")
                        .HasColumnType("TEXT");

                    b.Property<string>("brand")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<int>("condition")
                        .HasColumnType("INTEGER");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.HasIndex("auctionId");

                    b.ToTable("Items", (string)null);
                });

            modelBuilder.Entity("NLWExpertAPI.Models.Offer", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("TEXT");

                    b.Property<int>("itemId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("price")
                        .HasColumnType("TEXT");

                    b.Property<int>("userId")
                        .HasColumnType("INTEGER");

                    b.HasKey("id");

                    b.HasIndex("itemId")
                        .IsUnique();

                    b.HasIndex("userId")
                        .IsUnique();

                    b.ToTable("Offers", (string)null);
                });

            modelBuilder.Entity("NLWExpertAPI.Models.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("senha")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.HasIndex("email")
                        .IsUnique();

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("NLWExpertAPI.Models.Item", b =>
                {
                    b.HasOne("NLWExpertAPI.Models.Auction", null)
                        .WithMany("items")
                        .HasForeignKey("auctionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NLWExpertAPI.Models.Offer", b =>
                {
                    b.HasOne("NLWExpertAPI.Models.Item", null)
                        .WithOne()
                        .HasForeignKey("NLWExpertAPI.Models.Offer", "itemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NLWExpertAPI.Models.User", "user")
                        .WithOne()
                        .HasForeignKey("NLWExpertAPI.Models.Offer", "userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("NLWExpertAPI.Models.Auction", b =>
                {
                    b.Navigation("items");
                });
#pragma warning restore 612, 618
        }
    }
}
