using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Anabi.DataAccess.Ef.Migrations
{
    public partial class Defendants_for_assets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Birthdate",
                schema: "dbo",
                table: "Persons",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                schema: "dbo",
                table: "Persons",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdentifierId",
                schema: "dbo",
                table: "Persons",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nationality",
                schema: "dbo",
                table: "Persons",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AssetDefendants",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AssetId = table.Column<int>(type: "int", nullable: false),
                    LastChangeDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    UserCodeAdd = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    UserCodeLastChange = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetDefendants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssetDefendants_Assets_AssetId",
                        column: x => x.AssetId,
                        principalSchema: "dbo",
                        principalTable: "Assets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssetDefendants_Persons_PersonId",
                        column: x => x.PersonId,
                        principalSchema: "dbo",
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssetDefendants_User_Add",
                        column: x => x.UserCodeAdd,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "UserCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AssetDefendants_User_Change",
                        column: x => x.UserCodeLastChange,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "UserCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Identifiers",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdentifierType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsForPerson = table.Column<bool>(type: "bit", nullable: false),
                    LastChangeDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserCodeAdd = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    UserCodeLastChange = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Identifiers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Identifiers_User_Add",
                        column: x => x.UserCodeAdd,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "UserCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Identifiers_User_Change",
                        column: x => x.UserCodeLastChange,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "UserCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Persons_IdentifierId",
                schema: "dbo",
                table: "Persons",
                column: "IdentifierId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetDefendants_AssetId",
                schema: "dbo",
                table: "AssetDefendants",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetDefendants_PersonId",
                schema: "dbo",
                table: "AssetDefendants",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetDefendants_UserCodeAdd",
                schema: "dbo",
                table: "AssetDefendants",
                column: "UserCodeAdd");

            migrationBuilder.CreateIndex(
                name: "IX_AssetDefendants_UserCodeLastChange",
                schema: "dbo",
                table: "AssetDefendants",
                column: "UserCodeLastChange");

            migrationBuilder.CreateIndex(
                name: "IX_Identifiers_UserCodeAdd",
                schema: "dbo",
                table: "Identifiers",
                column: "UserCodeAdd");

            migrationBuilder.CreateIndex(
                name: "IX_Identifiers_UserCodeLastChange",
                schema: "dbo",
                table: "Identifiers",
                column: "UserCodeLastChange");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Identifiers",
                schema: "dbo",
                table: "Persons",
                column: "IdentifierId",
                principalSchema: "dbo",
                principalTable: "Identifiers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.Sql("INSERT Identifiers(IdentifierType, IsForPerson, UserCodeAdd, AddedDate) values ('CNP', 1, 'admin', getdate()), ('Pasaport', 1, 'admin', getdate()), ('CUI', 0, 'admin', getdate())");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Identifiers",
                schema: "dbo",
                table: "Persons");

            migrationBuilder.DropTable(
                name: "AssetDefendants",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Identifiers",
                schema: "dbo");

            migrationBuilder.DropIndex(
                name: "IX_Persons_IdentifierId",
                schema: "dbo",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "Birthdate",
                schema: "dbo",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "FirstName",
                schema: "dbo",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "IdentifierId",
                schema: "dbo",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "Nationality",
                schema: "dbo",
                table: "Persons");
        }
    }
}
