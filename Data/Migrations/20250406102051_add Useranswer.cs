using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class addUseranswer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JobUserAnswers",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobQuestionId = table.Column<int>(type: "int", nullable: false),
                    OptionId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobUserAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobUserAnswers_JobOptions_OptionId",
                        column: x => x.OptionId,
                        principalSchema: "dbo",
                        principalTable: "JobOptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                   
                    table.ForeignKey(
                        name: "FK_JobUserAnswers_MyUser_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "MyUser",
                        principalColumn: "ItUserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobUserAnswers_JobQuestionId",
                schema: "dbo",
                table: "JobUserAnswers",
                column: "JobQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_JobUserAnswers_OptionId",
                schema: "dbo",
                table: "JobUserAnswers",
                column: "OptionId");

            migrationBuilder.CreateIndex(
                name: "IX_JobUserAnswers_UserId",
                schema: "dbo",
                table: "JobUserAnswers",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobUserAnswers",
                schema: "dbo");
        }
    }
}
