using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class addhobgroupindex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

           

            migrationBuilder.AddColumn<int>(
                name: "jobGroupIndexId",
                schema: "dbo",
                table: "JobOptions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "JopGroupIndex",
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
                    table.PrimaryKey("PK_JopGroupIndex", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobOptions_jobGroupIndexId",
                schema: "dbo",
                table: "JobOptions",
                column: "jobGroupIndexId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobOptions_JopGroupIndex_jobGroupIndexId",
                schema: "dbo",
                table: "JobOptions",
                column: "jobGroupIndexId",
                principalSchema: "dbo",
                principalTable: "JopGroupIndex",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
           
            migrationBuilder.DropTable(
                name: "JopGroupIndex",
                schema: "dbo");

          

          
        }
    }
}
