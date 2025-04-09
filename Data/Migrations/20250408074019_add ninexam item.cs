using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class addninexamitem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExamList",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NinOptions",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NinOptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NinQuestions",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    seri = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NinQuestions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExamEvent",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ExamId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    examListId = table.Column<int>(type: "int", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamEvent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExamEvent_ExamList_examListId",
                        column: x => x.examListId,
                        principalSchema: "dbo",
                        principalTable: "ExamList",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ExamEvent_MyUser_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "MyUser",
                        principalColumn: "ItUserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NinUserAnswers",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItUserId = table.Column<int>(type: "int", nullable: false),
                    ninQuestionId = table.Column<int>(type: "int", nullable: false),
                    ninOptionId = table.Column<int>(type: "int", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NinUserAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NinUserAnswers_MyUser_ItUserId",
                        column: x => x.ItUserId,
                        principalSchema: "dbo",
                        principalTable: "MyUser",
                        principalColumn: "ItUserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NinUserAnswers_NinOptions_ninOptionId",
                        column: x => x.ninOptionId,
                        principalSchema: "dbo",
                        principalTable: "NinOptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NinUserAnswers_NinQuestions_ninQuestionId",
                        column: x => x.ninQuestionId,
                        principalSchema: "dbo",
                        principalTable: "NinQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExamEvent_examListId",
                schema: "dbo",
                table: "ExamEvent",
                column: "examListId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamEvent_UserId",
                schema: "dbo",
                table: "ExamEvent",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_NinUserAnswers_ItUserId",
                schema: "dbo",
                table: "NinUserAnswers",
                column: "ItUserId");

            migrationBuilder.CreateIndex(
                name: "IX_NinUserAnswers_ninOptionId",
                schema: "dbo",
                table: "NinUserAnswers",
                column: "ninOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_NinUserAnswers_ninQuestionId",
                schema: "dbo",
                table: "NinUserAnswers",
                column: "ninQuestionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExamEvent",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "NinUserAnswers",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ExamList",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "NinOptions",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "NinQuestions",
                schema: "dbo");
        }
    }
}
