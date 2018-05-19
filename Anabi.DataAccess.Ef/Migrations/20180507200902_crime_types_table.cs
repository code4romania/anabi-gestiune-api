using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Anabi.DataAccess.Ef.Migrations
{
    public partial class crime_types_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CrimeType",
                schema: "dbo",
                table: "HistoricalStages");

            migrationBuilder.AddColumn<int>(
                name: "CrimeTypeId",
                schema: "dbo",
                table: "HistoricalStages",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CrimeTypes",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CrimeName = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    LastChangeDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserCodeAdd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserCodeLastChange = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrimeTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HistoricalStages_CrimeTypeId",
                schema: "dbo",
                table: "HistoricalStages",
                column: "CrimeTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_HistoricalStages_CrimeTypes_CrimeTypeId",
                schema: "dbo",
                table: "HistoricalStages",
                column: "CrimeTypeId",
                principalSchema: "dbo",
                principalTable: "CrimeTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HistoricalStages_CrimeTypes_CrimeTypeId",
                schema: "dbo",
                table: "HistoricalStages");

            migrationBuilder.DropTable(
                name: "CrimeTypes",
                schema: "dbo");

            migrationBuilder.DropIndex(
                name: "IX_HistoricalStages_CrimeTypeId",
                schema: "dbo",
                table: "HistoricalStages");

            migrationBuilder.DropColumn(
                name: "CrimeTypeId",
                schema: "dbo",
                table: "HistoricalStages");

            migrationBuilder.AddColumn<int>(
                name: "CrimeType",
                schema: "dbo",
                table: "HistoricalStages",
                nullable: true);
        }
    }
}
