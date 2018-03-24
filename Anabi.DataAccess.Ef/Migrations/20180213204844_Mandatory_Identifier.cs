using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Anabi.DataAccess.Ef.Migrations
{
    public partial class Mandatory_Identifier : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("update Persons set IdentifierId = case when IsPerson = 1 then 1 else 3 end");

            migrationBuilder.AlterColumn<int>(
                name: "IdentifierId",
                schema: "dbo",
                table: "Persons",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "IdentifierId",
                schema: "dbo",
                table: "Persons",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
