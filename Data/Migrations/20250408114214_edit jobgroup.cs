using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class editjobgroup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobOptions_JopGroupIndex_jobGroupIndexId",
                schema: "dbo",
                table: "JobOptions");

            migrationBuilder.DropTable(
                name: "JopGroupIndex",
                schema: "dbo");

            migrationBuilder.CreateTable(
                name: "JobGroupIndex",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Order = table.Column<int>(type: "int", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobGroupIndex", x => x.Id);
                });

           
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
          

            migrationBuilder.DropTable(
                name: "JobGroupIndex",
                schema: "dbo");

            migrationBuilder.CreateTable(
                name: "JopGroupIndex",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JopGroupIndex", x => x.Id);
                });

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
    }
}
