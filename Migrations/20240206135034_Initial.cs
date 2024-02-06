using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NLWExpertAPI.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Auctions",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nome = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    starts = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ends = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auctions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nome = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    brand = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    condition = table.Column<int>(type: "INTEGER", nullable: false),
                    bestPrice = table.Column<decimal>(type: "TEXT", nullable: false),
                    auctionId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.id);
                    table.ForeignKey(
                        name: "FK_Items_Auctions_auctionId",
                        column: x => x.auctionId,
                        principalTable: "Auctions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_auctionId",
                table: "Items",
                column: "auctionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Auctions");
        }
    }
}
