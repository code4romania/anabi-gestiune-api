using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Anabi.DataAccess.Ef.Migrations
{
    public partial class PrecautionaryMeasures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PrecautionaryMeasureId",
                schema: "dbo",
                table: "HistoricalStages",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PrecautionaryMeasures",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Code = table.Column<int>(type: "int", nullable: false),
                    LastChangeDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UserCodeAdd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserCodeLastChange = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrecautionaryMeasures", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HistoricalStages_PrecautionaryMeasureId",
                schema: "dbo",
                table: "HistoricalStages",
                column: "PrecautionaryMeasureId");

            migrationBuilder.AddForeignKey(
                name: "FK_HistoricalStages_PrecautionaryMeasures_PrecautionaryMeasureId",
                schema: "dbo",
                table: "HistoricalStages",
                column: "PrecautionaryMeasureId",
                principalSchema: "dbo",
                principalTable: "PrecautionaryMeasures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.Sql("Insert PrecautionaryMeasures([Name], [Code], AddedDate, UserCodeAdd) values ('Confiscare speciala', 1, getdate(), 'admin'), ('Amenda penala', 2, getdate(), 'admin'), ('Despagubiri acordate statului', 3, getdate(), 'admin')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HistoricalStages_PrecautionaryMeasures_PrecautionaryMeasureId",
                schema: "dbo",
                table: "HistoricalStages");

            migrationBuilder.DropTable(
                name: "PrecautionaryMeasures",
                schema: "dbo");

            migrationBuilder.DropIndex(
                name: "IX_HistoricalStages_PrecautionaryMeasureId",
                schema: "dbo",
                table: "HistoricalStages");

            migrationBuilder.DropColumn(
                name: "PrecautionaryMeasureId",
                schema: "dbo",
                table: "HistoricalStages");
        }
    }
}
