using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Anabi.DataAccess.Ef.Migrations
{
    public partial class Stage_Parent_Desc_columns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "dbo",
                table: "Stages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                schema: "dbo",
                table: "Stages",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Stages_ParentId",
                schema: "dbo",
                table: "Stages",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Stages_Stages_ParentId",
                schema: "dbo",
                table: "Stages",
                column: "ParentId",
                principalSchema: "dbo",
                principalTable: "Stages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stages_Stages_ParentId",
                schema: "dbo",
                table: "Stages");

            migrationBuilder.DropIndex(
                name: "IX_Stages_ParentId",
                schema: "dbo",
                table: "Stages");

            migrationBuilder.DropColumn(
                name: "Description",
                schema: "dbo",
                table: "Stages");

            migrationBuilder.DropColumn(
                name: "ParentId",
                schema: "dbo",
                table: "Stages");
        }
    }
}
