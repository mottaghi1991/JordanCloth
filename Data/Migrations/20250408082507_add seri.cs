using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class addseri : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "seri",
                schema: "dbo",
                table: "NinQuestions");

            migrationBuilder.AddColumn<int>(
                name: "seriId",
                schema: "dbo",
                table: "NinQuestions",
                type: "int",
                maxLength: 50,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Seri",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seri", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NinQuestions_seriId",
                schema: "dbo",
                table: "NinQuestions",
                column: "seriId");

            migrationBuilder.AddForeignKey(
                name: "FK_NinQuestions_Seri_seriId",
                schema: "dbo",
                table: "NinQuestions",
                column: "seriId",
                principalSchema: "dbo",
                principalTable: "Seri",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NinQuestions_Seri_seriId",
                schema: "dbo",
                table: "NinQuestions");

            migrationBuilder.DropTable(
                name: "Seri",
                schema: "dbo");

            migrationBuilder.DropIndex(
                name: "IX_NinQuestions_seriId",
                schema: "dbo",
                table: "NinQuestions");

            migrationBuilder.DropColumn(
                name: "seriId",
                schema: "dbo",
                table: "NinQuestions");

            migrationBuilder.AddColumn<string>(
                name: "seri",
                schema: "dbo",
                table: "NinQuestions",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}
