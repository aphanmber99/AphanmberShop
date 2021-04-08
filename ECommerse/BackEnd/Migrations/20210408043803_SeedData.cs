using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEnd.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "Hair" },
                    { 2, "Makeup" },
                    { 3, "SkinCare" },
                    { 4, "Fragnance" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "proID", "CategoryId", "Image", "proDescription", "proName", "proPrice" },
                values: new object[,]
                {
                    { 1, 1, "p1.webp", "Product Desscription", "Product Name 1", 50.0 },
                    { 2, 1, "p3.webp", "Product Desscription", "Product Name 2", 50.0 },
                    { 3, 1, "p4.webp", "Product Desscription", "Product Name 3", 50.0 },
                    { 4, 1, "p5.webp", "Product Desscription", "Product Name 4", 50.0 },
                    { 5, 2, "p1.webp", "Product Desscription", "Product Name 6", 50.0 },
                    { 6, 2, "p3.webp", "Product Desscription", "Product Name 7", 50.0 },
                    { 7, 2, "p4.webp", "Product Desscription", "Product Name 8", 50.0 },
                    { 8, 2, "p5.webp", "Product Desscription", "Product Name 9", 50.0 },
                    { 9, 3, "p1.webp", "Product Desscription", "Product Name 10", 50.0 },
                    { 10, 3, "p3.webp", "Product Desscription", "Product Name 11", 50.0 },
                    { 11, 3, "p4.webp", "Product Desscription", "Product Name 12", 50.0 },
                    { 12, 3, "p5.webp", "Product Desscription", "Product Name 13", 50.0 },
                    { 13, 4, "p1.webp", "Product Desscription", "Product Name 14", 50.0 },
                    { 14, 4, "p3.webp", "Product Desscription", "Product Name 15", 50.0 },
                    { 15, 4, "p4.webp", "Product Desscription", "Product Name 16", 50.0 },
                    { 16, 4, "p5.webp", "Product Desscription", "Product Name 17", 50.0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "proID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "proID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "proID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "proID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "proID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "proID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "proID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "proID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "proID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "proID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "proID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "proID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "proID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "proID",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "proID",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "proID",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 4);
        }
    }
}
