using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Anabi.DataAccess.Ef.Migrations
{
    public partial class NewRecoveryFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "RecoveryApplicationDate",
                table: "HistoricalStages",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RecoveryApplicationNumber",
                table: "HistoricalStages",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RecoveryDocumentType",
                table: "HistoricalStages",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RecoveryIssuingInstitution",
                table: "HistoricalStages",
                maxLength: 200,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RecoveryApplicationDate",
                table: "HistoricalStages");

            migrationBuilder.DropColumn(
                name: "RecoveryApplicationNumber",
                table: "HistoricalStages");

            migrationBuilder.DropColumn(
                name: "RecoveryDocumentType",
                table: "HistoricalStages");

            migrationBuilder.DropColumn(
                name: "RecoveryIssuingInstitution",
                table: "HistoricalStages");
        }
    }
}
