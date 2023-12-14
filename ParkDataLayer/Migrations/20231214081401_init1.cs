using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkDataLayer.Migrations
{
    /// <inheritdoc />
    public partial class init1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Naam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Locatie = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Huurders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Huurders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Huizen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Straat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nr = table.Column<int>(type: "int", nullable: false),
                    Actief = table.Column<bool>(type: "bit", nullable: false),
                    ParkId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Huizen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Huizen_Categories_ParkId",
                        column: x => x.ParkId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Huurcontracten",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StartDatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EindDatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Aantaldagen = table.Column<int>(type: "int", nullable: false),
                    HuurderId = table.Column<int>(type: "int", nullable: true),
                    HuisId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Huurcontracten", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Huurcontracten_Huizen_HuisId",
                        column: x => x.HuisId,
                        principalTable: "Huizen",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Huurcontracten_Huurders_HuurderId",
                        column: x => x.HuurderId,
                        principalTable: "Huurders",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Huizen_ParkId",
                table: "Huizen",
                column: "ParkId");

            migrationBuilder.CreateIndex(
                name: "IX_Huurcontracten_HuisId",
                table: "Huurcontracten",
                column: "HuisId");

            migrationBuilder.CreateIndex(
                name: "IX_Huurcontracten_HuurderId",
                table: "Huurcontracten",
                column: "HuurderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Huurcontracten");

            migrationBuilder.DropTable(
                name: "Huizen");

            migrationBuilder.DropTable(
                name: "Huurders");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
