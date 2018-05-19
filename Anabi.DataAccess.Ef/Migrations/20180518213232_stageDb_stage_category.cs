using Microsoft.EntityFrameworkCore.Migrations;

namespace Anabi.DataAccess.Ef.Migrations
{
    public partial class stageDb_stage_category : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StageCategory",
                schema: "dbo",
                table: "Stages",
                type: "int",
                nullable: true);

            migrationBuilder.Sql("Update Stages set StageCategory = 4 where [Name] like '%valorificare%'");
            migrationBuilder.Sql("Update Stages set StageCategory = 1 where [Name] like '%sechestru%'");
            migrationBuilder.Sql("Update Stages set StageCategory = 2 where [Name] like '%confiscare%'");
            migrationBuilder.Sql("Update Stages set StageCategory = 3 where [Name] like '%ridicare%'");
            migrationBuilder.Sql("Update Stages set StageCategory = 5 where [Name] like '%administrare%'");
            migrationBuilder.Sql("Update Stages set StageCategory = 6 where [Name] like '%reutilizare%'");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StageCategory",
                schema: "dbo",
                table: "Stages");
        }
    }
}
