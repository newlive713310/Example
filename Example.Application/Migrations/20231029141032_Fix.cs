using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Example.Application.Migrations
{
    /// <inheritdoc />
    public partial class Fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryAdditionalFields_Categories_CategoryId",
                table: "CategoryAdditionalFields");

            migrationBuilder.DropIndex(
                name: "IX_CategoryAdditionalFields_CategoryId",
                table: "CategoryAdditionalFields");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
