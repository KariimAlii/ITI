using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab5_CodeFirst_FromScratch.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PriceOffers_Books_BookId",
                table: "PriceOffers");

            migrationBuilder.DropIndex(
                name: "IX_PriceOffers_BookId",
                table: "PriceOffers");

            migrationBuilder.AlterColumn<int>(
                name: "BookId",
                table: "PriceOffers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PriceOffers_BookId",
                table: "PriceOffers",
                column: "BookId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PriceOffers_Books_BookId",
                table: "PriceOffers",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PriceOffers_Books_BookId",
                table: "PriceOffers");

            migrationBuilder.DropIndex(
                name: "IX_PriceOffers_BookId",
                table: "PriceOffers");

            migrationBuilder.AlterColumn<int>(
                name: "BookId",
                table: "PriceOffers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_PriceOffers_BookId",
                table: "PriceOffers",
                column: "BookId",
                unique: true,
                filter: "[BookId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_PriceOffers_Books_BookId",
                table: "PriceOffers",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "BookId");
        }
    }
}
