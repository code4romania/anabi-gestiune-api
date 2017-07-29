using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Anabi.DataAccess.Ef.Migrations
{
    public partial class mig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "ActualValue",
                schema: "dbo",
                table: "HistoricalStages",
                type: "Decimal(20, 2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ActualValueCurrency",
                schema: "dbo",
                table: "HistoricalStages",
                maxLength: 3,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AssetState",
                schema: "dbo",
                table: "HistoricalStages",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                schema: "dbo",
                table: "HistoricalStages",
                type: "Int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Identifier",
                schema: "dbo",
                table: "Assets",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "NecessaryVolume",
                schema: "dbo",
                table: "Assets",
                type: "Decimal(20, 2)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_HistoricalStages_OwnerId",
                schema: "dbo",
                table: "HistoricalStages",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_OwnerId",
                schema: "dbo",
                table: "HistoricalStages",
                column: "OwnerId",
                principalSchema: "dbo",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OwnerId",
                schema: "dbo",
                table: "HistoricalStages");

            migrationBuilder.DropIndex(
                name: "IX_HistoricalStages_OwnerId",
                schema: "dbo",
                table: "HistoricalStages");

            migrationBuilder.DropColumn(
                name: "ActualValue",
                schema: "dbo",
                table: "HistoricalStages");

            migrationBuilder.DropColumn(
                name: "ActualValueCurrency",
                schema: "dbo",
                table: "HistoricalStages");

            migrationBuilder.DropColumn(
                name: "AssetState",
                schema: "dbo",
                table: "HistoricalStages");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                schema: "dbo",
                table: "HistoricalStages");

            migrationBuilder.DropColumn(
                name: "Identifier",
                schema: "dbo",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "NecessaryVolume",
                schema: "dbo",
                table: "Assets");
        }
    }
}
