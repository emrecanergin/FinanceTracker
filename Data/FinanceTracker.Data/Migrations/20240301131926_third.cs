using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinanceTracker.Data.Migrations
{
    /// <inheritdoc />
    public partial class third : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "CoinAsset");

            migrationBuilder.DropColumn(
                name: "Symbol",
                table: "CoinAsset");

            migrationBuilder.AddColumn<int>(
                name: "CoinId",
                table: "CoinAsset",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CoinAsset_CoinId",
                table: "CoinAsset",
                column: "CoinId");

            migrationBuilder.AddForeignKey(
                name: "FK_CoinAsset_Coins_CoinId",
                table: "CoinAsset",
                column: "CoinId",
                principalTable: "Coins",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CoinAsset_Coins_CoinId",
                table: "CoinAsset");

            migrationBuilder.DropIndex(
                name: "IX_CoinAsset_CoinId",
                table: "CoinAsset");

            migrationBuilder.DropColumn(
                name: "CoinId",
                table: "CoinAsset");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "CoinAsset",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Symbol",
                table: "CoinAsset",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
