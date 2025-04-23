using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class addmysptodb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var createProcSql = @"
            IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = '[SearchPermission]')
            BEGIN
                EXEC('
                    CREATE PROCEDURE [dbo].[SearchPermission](@Area NVARCHAR(50),@Controller NVARCHAR(50))
AS
SELECT [SM].[PermissionListId],
       [SM].[ParentId],
       [SM].[Radif],
       [SM].[Descript],
       [SM].[Area],
       [SM].[ControllerName],
       [SM].[ActionName],
       ISNULL([SM].[Status],-1) AS [IsPublic] FROM [dbo].[PermissionList]  AS [SM]
WHERE ([SM].[Area]=@Area OR [SM].[Area] IS NULL) AND ([SM].[ControllerName]=@Controller OR @Controller IS null) 

                ')
            END
        ";
            migrationBuilder.Sql(createProcSql);  // این خط رو اضافه کردیم

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
