using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Anabi.DataAccess.Ef.Migrations
{
    public partial class historicalstage_new_fields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "SentOnEmail",
                schema: "dbo",
                table: "HistoricalStages",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReceivingDate",
                schema: "dbo",
                table: "HistoricalStages",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<bool>(
                name: "IsDefinitive",
                schema: "dbo",
                table: "HistoricalStages",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<string>(
                name: "FileNumber",
                schema: "dbo",
                table: "HistoricalStages",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 200);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastActivity",
                schema: "dbo",
                table: "HistoricalStages",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PersonResponsible",
                schema: "dbo",
                table: "HistoricalStages",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastActivity",
                schema: "dbo",
                table: "HistoricalStages");

            migrationBuilder.DropColumn(
                name: "PersonResponsible",
                schema: "dbo",
                table: "HistoricalStages");

            migrationBuilder.AlterColumn<bool>(
                name: "SentOnEmail",
                schema: "dbo",
                table: "HistoricalStages",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReceivingDate",
                schema: "dbo",
                table: "HistoricalStages",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDefinitive",
                schema: "dbo",
                table: "HistoricalStages",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FileNumber",
                schema: "dbo",
                table: "HistoricalStages",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);
        }
    }
}
