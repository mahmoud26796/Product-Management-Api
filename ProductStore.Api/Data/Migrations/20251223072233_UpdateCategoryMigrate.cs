using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductStore.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCategoryMigrate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Catagories_CategoryId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Catagories",
                table: "Catagories");

            migrationBuilder.RenameTable(
                name: "Catagories",
                newName: "Categories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Catagories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Catagories",
                table: "Catagories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Catagories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Catagories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
