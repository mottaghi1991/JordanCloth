using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class addfeaturetoproduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Features",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    subCategoryId = table.Column<int>(type: "int", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Features", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Features_SubCategories_subCategoryId",
                        column: x => x.subCategoryId,
                        principalSchema: "dbo",
                        principalTable: "SubCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FeatureValues",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FeatureId = table.Column<int>(type: "int", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeatureValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FeatureValues_Features_FeatureId",
                        column: x => x.FeatureId,
                        principalSchema: "dbo",
                        principalTable: "Features",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductFeatureValues",
                schema: "dbo",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    FeatureValueId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductFeatureValues", x => new { x.ProductId, x.FeatureValueId });
                    table.ForeignKey(
                        name: "FK_ProductFeatureValues_FeatureValues_FeatureValueId",
                        column: x => x.FeatureValueId,
                        principalSchema: "dbo",
                        principalTable: "FeatureValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductFeatureValues_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "dbo",
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Features_subCategoryId",
                schema: "dbo",
                table: "Features",
                column: "subCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_FeatureValues_FeatureId",
                schema: "dbo",
                table: "FeatureValues",
                column: "FeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductFeatureValues_FeatureValueId",
                schema: "dbo",
                table: "ProductFeatureValues",
                column: "FeatureValueId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductFeatureValues",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "FeatureValues",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Features",
                schema: "dbo");
        }
    }
}
