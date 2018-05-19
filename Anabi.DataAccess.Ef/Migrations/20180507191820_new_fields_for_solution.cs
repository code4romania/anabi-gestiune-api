using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Anabi.DataAccess.Ef.Migrations
{
    public partial class new_fields_for_solution : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CrimeType",
                schema: "dbo",
                table: "HistoricalStages",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DefinitiveDate",
                schema: "dbo",
                table: "HistoricalStages",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileNumber",
                schema: "dbo",
                table: "HistoricalStages",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FileNumberParquet",
                schema: "dbo",
                table: "HistoricalStages",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDefinitive",
                schema: "dbo",
                table: "HistoricalStages",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReceivingDate",
                schema: "dbo",
                table: "HistoricalStages",
                type: "datetime2",
                nullable: false,
                defaultValue: DateTime.Today);

            migrationBuilder.AddColumn<int>(
                name: "RecoveryBeneficiaryId",
                schema: "dbo",
                table: "HistoricalStages",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SendToAuthoritiesDate",
                schema: "dbo",
                table: "HistoricalStages",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "SentOnEmail",
                schema: "dbo",
                table: "HistoricalStages",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Source",
                schema: "dbo",
                table: "HistoricalStages",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_HistoricalStages_RecoveryBeneficiaryId",
                schema: "dbo",
                table: "HistoricalStages",
                column: "RecoveryBeneficiaryId");

            migrationBuilder.AddForeignKey(
                name: "FK_HistoricalStages_RecoveryBeneficiaries_RecoveryBeneficiaryId",
                schema: "dbo",
                table: "HistoricalStages",
                column: "RecoveryBeneficiaryId",
                principalSchema: "dbo",
                principalTable: "RecoveryBeneficiaries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HistoricalStages_RecoveryBeneficiaries_RecoveryBeneficiaryId",
                schema: "dbo",
                table: "HistoricalStages");

            migrationBuilder.DropIndex(
                name: "IX_HistoricalStages_RecoveryBeneficiaryId",
                schema: "dbo",
                table: "HistoricalStages");

            migrationBuilder.DropColumn(
                name: "CrimeType",
                schema: "dbo",
                table: "HistoricalStages");

            migrationBuilder.DropColumn(
                name: "DefinitiveDate",
                schema: "dbo",
                table: "HistoricalStages");

            migrationBuilder.DropColumn(
                name: "FileNumber",
                schema: "dbo",
                table: "HistoricalStages");

            migrationBuilder.DropColumn(
                name: "FileNumberParquet",
                schema: "dbo",
                table: "HistoricalStages");

            migrationBuilder.DropColumn(
                name: "IsDefinitive",
                schema: "dbo",
                table: "HistoricalStages");

            migrationBuilder.DropColumn(
                name: "ReceivingDate",
                schema: "dbo",
                table: "HistoricalStages");

            migrationBuilder.DropColumn(
                name: "RecoveryBeneficiaryId",
                schema: "dbo",
                table: "HistoricalStages");

            migrationBuilder.DropColumn(
                name: "SendToAuthoritiesDate",
                schema: "dbo",
                table: "HistoricalStages");

            migrationBuilder.DropColumn(
                name: "SentOnEmail",
                schema: "dbo",
                table: "HistoricalStages");

            migrationBuilder.DropColumn(
                name: "Source",
                schema: "dbo",
                table: "HistoricalStages");
        }
    }
}
