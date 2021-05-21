using Microsoft.EntityFrameworkCore.Migrations;

namespace Catalog.Persistence.Database.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Catalog");

            migrationBuilder.CreateTable(
                name: "Products",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stocks",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stocks_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "Catalog",
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "Catalog",
                table: "Products",
                columns: new[] { "Id", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Description of product 1", "Product 1", 856m },
                    { 73, "Description of product 73", "Product 73", 516m },
                    { 72, "Description of product 72", "Product 72", 221m },
                    { 71, "Description of product 71", "Product 71", 542m },
                    { 70, "Description of product 70", "Product 70", 318m },
                    { 69, "Description of product 69", "Product 69", 971m },
                    { 68, "Description of product 68", "Product 68", 851m },
                    { 67, "Description of product 67", "Product 67", 379m },
                    { 66, "Description of product 66", "Product 66", 365m },
                    { 65, "Description of product 65", "Product 65", 339m },
                    { 64, "Description of product 64", "Product 64", 886m },
                    { 63, "Description of product 63", "Product 63", 719m },
                    { 62, "Description of product 62", "Product 62", 446m },
                    { 61, "Description of product 61", "Product 61", 343m },
                    { 60, "Description of product 60", "Product 60", 718m },
                    { 59, "Description of product 59", "Product 59", 912m },
                    { 58, "Description of product 58", "Product 58", 972m },
                    { 57, "Description of product 57", "Product 57", 979m },
                    { 56, "Description of product 56", "Product 56", 141m },
                    { 55, "Description of product 55", "Product 55", 194m },
                    { 54, "Description of product 54", "Product 54", 309m },
                    { 53, "Description of product 53", "Product 53", 667m },
                    { 74, "Description of product 74", "Product 74", 489m },
                    { 52, "Description of product 52", "Product 52", 750m },
                    { 75, "Description of product 75", "Product 75", 540m },
                    { 77, "Description of product 77", "Product 77", 365m },
                    { 98, "Description of product 98", "Product 98", 663m },
                    { 97, "Description of product 97", "Product 97", 444m },
                    { 96, "Description of product 96", "Product 96", 610m },
                    { 95, "Description of product 95", "Product 95", 298m },
                    { 94, "Description of product 94", "Product 94", 698m },
                    { 93, "Description of product 93", "Product 93", 648m },
                    { 92, "Description of product 92", "Product 92", 633m },
                    { 91, "Description of product 91", "Product 91", 176m },
                    { 90, "Description of product 90", "Product 90", 640m },
                    { 89, "Description of product 89", "Product 89", 745m },
                    { 88, "Description of product 88", "Product 88", 736m },
                    { 87, "Description of product 87", "Product 87", 388m },
                    { 86, "Description of product 86", "Product 86", 442m },
                    { 85, "Description of product 85", "Product 85", 631m },
                    { 84, "Description of product 84", "Product 84", 670m },
                    { 83, "Description of product 83", "Product 83", 446m }
                });

            migrationBuilder.InsertData(
                schema: "Catalog",
                table: "Products",
                columns: new[] { "Id", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 82, "Description of product 82", "Product 82", 746m },
                    { 81, "Description of product 81", "Product 81", 829m },
                    { 80, "Description of product 80", "Product 80", 389m },
                    { 79, "Description of product 79", "Product 79", 908m },
                    { 78, "Description of product 78", "Product 78", 552m },
                    { 76, "Description of product 76", "Product 76", 687m },
                    { 51, "Description of product 51", "Product 51", 424m },
                    { 50, "Description of product 50", "Product 50", 617m },
                    { 49, "Description of product 49", "Product 49", 253m },
                    { 22, "Description of product 22", "Product 22", 815m },
                    { 21, "Description of product 21", "Product 21", 750m },
                    { 20, "Description of product 20", "Product 20", 497m },
                    { 19, "Description of product 19", "Product 19", 931m },
                    { 18, "Description of product 18", "Product 18", 833m },
                    { 17, "Description of product 17", "Product 17", 681m },
                    { 16, "Description of product 16", "Product 16", 148m },
                    { 15, "Description of product 15", "Product 15", 374m },
                    { 14, "Description of product 14", "Product 14", 653m },
                    { 13, "Description of product 13", "Product 13", 691m },
                    { 12, "Description of product 12", "Product 12", 325m },
                    { 11, "Description of product 11", "Product 11", 320m },
                    { 10, "Description of product 10", "Product 10", 432m },
                    { 9, "Description of product 9", "Product 9", 842m },
                    { 8, "Description of product 8", "Product 8", 906m },
                    { 7, "Description of product 7", "Product 7", 946m },
                    { 6, "Description of product 6", "Product 6", 623m },
                    { 5, "Description of product 5", "Product 5", 241m },
                    { 4, "Description of product 4", "Product 4", 230m },
                    { 3, "Description of product 3", "Product 3", 886m },
                    { 2, "Description of product 2", "Product 2", 693m },
                    { 23, "Description of product 23", "Product 23", 714m },
                    { 24, "Description of product 24", "Product 24", 914m },
                    { 25, "Description of product 25", "Product 25", 318m },
                    { 26, "Description of product 26", "Product 26", 523m },
                    { 48, "Description of product 48", "Product 48", 634m },
                    { 47, "Description of product 47", "Product 47", 693m },
                    { 46, "Description of product 46", "Product 46", 929m },
                    { 45, "Description of product 45", "Product 45", 105m },
                    { 44, "Description of product 44", "Product 44", 261m },
                    { 43, "Description of product 43", "Product 43", 549m },
                    { 42, "Description of product 42", "Product 42", 163m },
                    { 41, "Description of product 41", "Product 41", 957m }
                });

            migrationBuilder.InsertData(
                schema: "Catalog",
                table: "Products",
                columns: new[] { "Id", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 40, "Description of product 40", "Product 40", 542m },
                    { 39, "Description of product 39", "Product 39", 416m },
                    { 99, "Description of product 99", "Product 99", 922m },
                    { 38, "Description of product 38", "Product 38", 560m },
                    { 36, "Description of product 36", "Product 36", 156m },
                    { 35, "Description of product 35", "Product 35", 682m },
                    { 34, "Description of product 34", "Product 34", 839m },
                    { 33, "Description of product 33", "Product 33", 946m },
                    { 32, "Description of product 32", "Product 32", 955m },
                    { 31, "Description of product 31", "Product 31", 193m },
                    { 30, "Description of product 30", "Product 30", 956m },
                    { 29, "Description of product 29", "Product 29", 287m },
                    { 28, "Description of product 28", "Product 28", 599m },
                    { 27, "Description of product 27", "Product 27", 380m },
                    { 37, "Description of product 37", "Product 37", 605m },
                    { 100, "Description of product 100", "Product 100", 740m }
                });

            migrationBuilder.InsertData(
                schema: "Catalog",
                table: "Stocks",
                columns: new[] { "Id", "ProductId", "Stock" },
                values: new object[,]
                {
                    { 1, 1, 9 },
                    { 73, 73, 6 },
                    { 72, 72, 8 },
                    { 71, 71, 16 },
                    { 70, 70, 0 },
                    { 69, 69, 16 },
                    { 68, 68, 11 },
                    { 67, 67, 8 },
                    { 66, 66, 13 },
                    { 65, 65, 16 },
                    { 64, 64, 0 },
                    { 63, 63, 12 },
                    { 62, 62, 9 },
                    { 61, 61, 9 },
                    { 60, 60, 11 },
                    { 59, 59, 10 },
                    { 58, 58, 10 },
                    { 57, 57, 19 },
                    { 56, 56, 19 },
                    { 55, 55, 2 },
                    { 54, 54, 0 },
                    { 53, 53, 10 },
                    { 74, 74, 10 },
                    { 52, 52, 18 },
                    { 75, 75, 11 },
                    { 77, 77, 18 },
                    { 98, 98, 10 },
                    { 97, 97, 0 },
                    { 96, 96, 9 },
                    { 95, 95, 7 },
                    { 94, 94, 14 },
                    { 93, 93, 17 },
                    { 92, 92, 7 },
                    { 91, 91, 6 },
                    { 90, 90, 15 },
                    { 89, 89, 14 },
                    { 88, 88, 18 },
                    { 87, 87, 14 },
                    { 86, 86, 9 },
                    { 85, 85, 12 },
                    { 84, 84, 15 },
                    { 83, 83, 0 }
                });

            migrationBuilder.InsertData(
                schema: "Catalog",
                table: "Stocks",
                columns: new[] { "Id", "ProductId", "Stock" },
                values: new object[,]
                {
                    { 82, 82, 11 },
                    { 81, 81, 9 },
                    { 80, 80, 6 },
                    { 79, 79, 0 },
                    { 78, 78, 12 },
                    { 76, 76, 6 },
                    { 51, 51, 1 },
                    { 50, 50, 5 },
                    { 49, 49, 5 },
                    { 22, 22, 9 },
                    { 21, 21, 19 },
                    { 20, 20, 10 },
                    { 19, 19, 7 },
                    { 18, 18, 12 },
                    { 17, 17, 16 },
                    { 16, 16, 14 },
                    { 15, 15, 6 },
                    { 14, 14, 11 },
                    { 13, 13, 8 },
                    { 12, 12, 7 },
                    { 11, 11, 18 },
                    { 10, 10, 5 },
                    { 9, 9, 14 },
                    { 8, 8, 13 },
                    { 7, 7, 16 },
                    { 6, 6, 13 },
                    { 5, 5, 2 },
                    { 4, 4, 0 },
                    { 3, 3, 5 },
                    { 2, 2, 18 },
                    { 23, 23, 19 },
                    { 24, 24, 15 },
                    { 25, 25, 10 },
                    { 26, 26, 11 },
                    { 48, 48, 12 },
                    { 47, 47, 1 },
                    { 46, 46, 4 },
                    { 45, 45, 15 },
                    { 44, 44, 6 },
                    { 43, 43, 10 },
                    { 42, 42, 13 },
                    { 41, 41, 18 }
                });

            migrationBuilder.InsertData(
                schema: "Catalog",
                table: "Stocks",
                columns: new[] { "Id", "ProductId", "Stock" },
                values: new object[,]
                {
                    { 40, 40, 16 },
                    { 39, 39, 6 },
                    { 99, 99, 10 },
                    { 38, 38, 7 },
                    { 36, 36, 6 },
                    { 35, 35, 14 },
                    { 34, 34, 16 },
                    { 33, 33, 18 },
                    { 32, 32, 5 },
                    { 31, 31, 8 },
                    { 30, 30, 14 },
                    { 29, 29, 1 },
                    { 28, 28, 6 },
                    { 27, 27, 3 },
                    { 37, 37, 17 },
                    { 100, 100, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_Id",
                schema: "Catalog",
                table: "Products",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_Id",
                schema: "Catalog",
                table: "Stocks",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_ProductId",
                schema: "Catalog",
                table: "Stocks",
                column: "ProductId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stocks",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "Products",
                schema: "Catalog");
        }
    }
}
