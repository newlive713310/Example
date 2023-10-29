using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Example.Application.Migrations
{
    /// <inheritdoc />
    public partial class Fix3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ProductAdditionalFields_ProductId",
                table: "ProductAdditionalFields",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductAdditionalFields_Products_ProductId",
                table: "ProductAdditionalFields",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductAdditionalFields_Products_ProductId",
                table: "ProductAdditionalFields");

            migrationBuilder.DropIndex(
                name: "IX_ProductAdditionalFields_ProductId",
                table: "ProductAdditionalFields");
        }
    }
}
