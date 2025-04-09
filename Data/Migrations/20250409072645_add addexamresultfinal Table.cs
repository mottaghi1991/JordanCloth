using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class addaddexamresultfinalTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
        

            

       
          

            migrationBuilder.CreateTable(
                name: "ExamResultFinals",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descript = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    FinalResult = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExamId = table.Column<int>(type: "int", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamResultFinals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExamResultFinals_ExamList_ExamId",
                        column: x => x.ExamId,
                        principalSchema: "dbo",
                        principalTable: "ExamList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExamResultFinals_ExamId",
                schema: "dbo",
                table: "ExamResultFinals",
                column: "ExamId");


        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.DropTable(
                name: "ExamResultFinals",
                schema: "dbo");
        }
    }
}
