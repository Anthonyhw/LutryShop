using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LutryShop.ProductApi.Migrations
{
    public partial class seeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryName", "Description", "ImageURL", "Name", "Price" },
                values: new object[,]
                {
                    { 1L, "Seed Category Name 1", "Seed Description 1", "Seed ImageURL 1", "Seed Name 1", 1m },
                    { 2L, "Seed Category Name 2", "Seed Description 2", "Seed ImageURL 2", "Seed Name 2", 2m },
                    { 3L, "Seed Category Name 3", "Seed Description 3", "Seed ImageURL 3", "Seed Name 3", 3m },
                    { 4L, "Seed Category Name 4", "Seed Description 4", "Seed ImageURL 4", "Seed Name 4", 4m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4L);
        }
    }
}
