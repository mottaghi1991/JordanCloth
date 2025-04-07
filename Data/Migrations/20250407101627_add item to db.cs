using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class additemtodb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.AddColumn<int>(
                name: "QuestionId",
                schema: "dbo",
                table: "Options",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                schema: "dbo",
                table: "JobQuestions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TItle",
                schema: "dbo",
                table: "JobOptions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Options_QuestionId",
                schema: "dbo",
                table: "Options",
                column: "QuestionId");

           
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Options_Questions_QuestionId",
                schema: "dbo",
                table: "Options");

            migrationBuilder.DropIndex(
                name: "IX_Options_QuestionId",
                schema: "dbo",
                table: "Options");

            migrationBuilder.DropColumn(
                name: "descript",
                schema: "dbo",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "QuestionId",
                schema: "dbo",
                table: "Options");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                schema: "dbo",
                table: "JobQuestions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "TItle",
                schema: "dbo",
                table: "JobOptions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
