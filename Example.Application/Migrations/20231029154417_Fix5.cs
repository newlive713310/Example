using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Example.Application.Migrations
{
    /// <inheritdoc />
    public partial class Fix5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductAdditionalFields_CategoryAdditionalFields_CategoryAd~",
                table: "ProductAdditionalFields");

            migrationBuilder.DropIndex(
                name: "IX_ProductAdditionalFields_CategoryAdditionalFieldId",
                table: "ProductAdditionalFields");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ProductAdditionalFields_CategoryAdditionalFieldId",
                table: "ProductAdditionalFields",
                column: "CategoryAdditionalFieldId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductAdditionalFields_CategoryAdditionalFields_CategoryAd~",
                table: "ProductAdditionalFields",
                column: "CategoryAdditionalFieldId",
                principalTable: "CategoryAdditionalFields",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
