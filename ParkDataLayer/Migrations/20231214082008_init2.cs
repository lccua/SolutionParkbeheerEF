using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkDataLayer.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Huizen_Categories_ParkId",
                table: "Huizen");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Parken");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Parken",
                table: "Parken",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Huizen_Parken_ParkId",
                table: "Huizen",
                column: "ParkId",
                principalTable: "Parken",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Huizen_Parken_ParkId",
                table: "Huizen");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Parken",
                table: "Parken");

            migrationBuilder.RenameTable(
                name: "Parken",
                newName: "Categories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Huizen_Categories_ParkId",
                table: "Huizen",
                column: "ParkId",
                principalTable: "Categories",
                principalColumn: "Id");
        }
    }
}
