using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Example.Application.Migrations
{
    /// <inheritdoc />
    public partial class Fix4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ProductAdditionalFields_CategoryAdditionalFieldId",
                table: "ProductAdditionalFields",
                column: "CategoryAdditionalFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryAdditionalFields_CategoryId",
                table: "CategoryAdditionalFields",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryAdditionalFields_Categories_CategoryId",
                table: "CategoryAdditionalFields",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductAdditionalFields_CategoryAdditionalFields_CategoryAd~",
                table: "ProductAdditionalFields",
                column: "CategoryAdditionalFieldId",
                principalTable: "CategoryAdditionalFields",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryAdditionalFields_Categories_CategoryId",
                table: "CategoryAdditionalFields");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductAdditionalFields_CategoryAdditionalFields_CategoryAd~",
                table: "ProductAdditionalFields");

            migrationBuilder.DropIndex(
                name: "IX_ProductAdditionalFields_CategoryAdditionalFieldId",
                table: "ProductAdditionalFields");

            migrationBuilder.DropIndex(
                name: "IX_CategoryAdditionalFields_CategoryId",
                table: "CategoryAdditionalFields");
        }
    }
}
