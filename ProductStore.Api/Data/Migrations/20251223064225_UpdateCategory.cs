using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductStore.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductsCount",
                table: "Catagories",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Catagories",
                keyColumn: "Id",
                keyValue: 1,
                column: "ProductsCount",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Catagories",
                keyColumn: "Id",
                keyValue: 2,
                column: "ProductsCount",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Catagories",
                keyColumn: "Id",
                keyValue: 3,
                column: "ProductsCount",
                value: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductsCount",
                table: "Catagories");
        }
    }
}
