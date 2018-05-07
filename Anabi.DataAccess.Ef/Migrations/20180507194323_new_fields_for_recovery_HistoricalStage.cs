using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Anabi.DataAccess.Ef.Migrations
{
    public partial class new_fields_for_recovery_HistoricalStage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EvaluationCommittee",
                schema: "dbo",
                table: "HistoricalStages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EvaluationCommitteeDesignationDate",
                schema: "dbo",
                table: "HistoricalStages",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EvaluationCommitteePresident",
                schema: "dbo",
                table: "HistoricalStages",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RecoveryCommittee",
                schema: "dbo",
                table: "HistoricalStages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RecoveryCommitteeDesignationDate",
                schema: "dbo",
                table: "HistoricalStages",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RecoveryCommitteePresident",
                schema: "dbo",
                table: "HistoricalStages",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RecoveryState",
                schema: "dbo",
                table: "HistoricalStages",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EvaluationCommittee",
                schema: "dbo",
                table: "HistoricalStages");

            migrationBuilder.DropColumn(
                name: "EvaluationCommitteeDesignationDate",
                schema: "dbo",
                table: "HistoricalStages");

            migrationBuilder.DropColumn(
                name: "EvaluationCommitteePresident",
                schema: "dbo",
                table: "HistoricalStages");

            migrationBuilder.DropColumn(
                name: "RecoveryCommittee",
                schema: "dbo",
                table: "HistoricalStages");

            migrationBuilder.DropColumn(
                name: "RecoveryCommitteeDesignationDate",
                schema: "dbo",
                table: "HistoricalStages");

            migrationBuilder.DropColumn(
                name: "RecoveryCommitteePresident",
                schema: "dbo",
                table: "HistoricalStages");

            migrationBuilder.DropColumn(
                name: "RecoveryState",
                schema: "dbo",
                table: "HistoricalStages");
        }
    }
}
