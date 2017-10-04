using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Anabi.DataAccess.Ef.Migrations
{
    public partial class Removed_CurrentStage_From_Asset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Counties",
                schema: "dbo",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Assets_Addresses",
                schema: "dbo",
                table: "Assets");

            migrationBuilder.DropForeignKey(
                name: "FK_Assets_Categories",
                schema: "dbo",
                table: "Assets");

            migrationBuilder.DropForeignKey(
                name: "FK_Assets_Stages",
                schema: "dbo",
                table: "Assets");

            migrationBuilder.DropForeignKey(
                name: "FK_Assets_Decisions",
                schema: "dbo",
                table: "Assets");

            migrationBuilder.DropForeignKey(
                name: "FK_Assets_Users_UserCodeAdd",
                schema: "dbo",
                table: "Assets");

            migrationBuilder.DropForeignKey(
                name: "FK_Assets_Users_UserCodeLastChange",
                schema: "dbo",
                table: "Assets");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetsFiles_Assets",
                schema: "dbo",
                table: "AssetsFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetsFiles_Files",
                schema: "dbo",
                table: "AssetsFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetsFiles_Users_UserCodeAdd",
                schema: "dbo",
                table: "AssetsFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetsFiles_Users_UserCodeLastChange",
                schema: "dbo",
                table: "AssetsFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetsStorageSpaces_Assets",
                schema: "dbo",
                table: "AssetsStorageSpaces");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetsStorageSpaces_StorageSpaces",
                schema: "dbo",
                table: "AssetsStorageSpaces");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetsStorageSpaces_Users_UserCodeAdd",
                schema: "dbo",
                table: "AssetsStorageSpaces");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetsStorageSpaces_Users_UserCodeLastChange",
                schema: "dbo",
                table: "AssetsStorageSpaces");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Parent",
                schema: "dbo",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_DefendantsFile_Dosare",
                schema: "dbo",
                table: "DefendantsFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_DefendantsFile_Persoane",
                schema: "dbo",
                table: "DefendantsFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_DefendantsFiles_Users_UserCodeAdd",
                schema: "dbo",
                table: "DefendantsFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_DefendantsFiles_Users_UserCodeLastChange",
                schema: "dbo",
                table: "DefendantsFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_NumereDosare_Institutii",
                schema: "dbo",
                table: "FileNumbers");

            migrationBuilder.DropForeignKey(
                name: "FK_FileNumbers_Users_UserCodeAdd",
                schema: "dbo",
                table: "FileNumbers");

            migrationBuilder.DropForeignKey(
                name: "FK_FileNumbers_Users_UserCodeLastChange",
                schema: "dbo",
                table: "FileNumbers");

            migrationBuilder.DropForeignKey(
                name: "FK_Files_Users_UserCodeAdd",
                schema: "dbo",
                table: "Files");

            migrationBuilder.DropForeignKey(
                name: "FK_Files_Users_UserCodeLastChange",
                schema: "dbo",
                table: "Files");

            migrationBuilder.DropForeignKey(
                name: "FK_HistoricalStages_Assets",
                schema: "dbo",
                table: "HistoricalStages");

            migrationBuilder.DropForeignKey(
                name: "FK_HistoricalStages_Decisions",
                schema: "dbo",
                table: "HistoricalStages");

            migrationBuilder.DropForeignKey(
                name: "FK_HistoricalStages_Institutions",
                schema: "dbo",
                table: "HistoricalStages");

            migrationBuilder.DropForeignKey(
                name: "FK_OwnerId",
                schema: "dbo",
                table: "HistoricalStages");

            migrationBuilder.DropForeignKey(
                name: "FK_HistoricalStages_Stages",
                schema: "dbo",
                table: "HistoricalStages");

            migrationBuilder.DropForeignKey(
                name: "FK_HistoricalStages_Users_UserCodeAdd",
                schema: "dbo",
                table: "HistoricalStages");

            migrationBuilder.DropForeignKey(
                name: "FK_HistoricalStages_Users_UserCodeLastChange",
                schema: "dbo",
                table: "HistoricalStages");

            migrationBuilder.DropForeignKey(
                name: "FK_Institutions_Categories",
                schema: "dbo",
                table: "Institutions");

            migrationBuilder.DropForeignKey(
                name: "FK_Institutions_Users_UserCodeAdd",
                schema: "dbo",
                table: "Institutions");

            migrationBuilder.DropForeignKey(
                name: "FK_Institutions_Users_UserCodeLastChange",
                schema: "dbo",
                table: "Institutions");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Addresses",
                schema: "dbo",
                table: "Persons");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Users_UserCodeAdd",
                schema: "dbo",
                table: "Persons");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Users_UserCodeLastChange",
                schema: "dbo",
                table: "Persons");

            migrationBuilder.DropForeignKey(
                name: "FK_StagesForDecision_Decision",
                schema: "dbo",
                table: "StagesForDecisions");

            migrationBuilder.DropForeignKey(
                name: "FK_StagesForDecision_Stage",
                schema: "dbo",
                table: "StagesForDecisions");

            migrationBuilder.DropForeignKey(
                name: "FK_StorageSpaces_Addresses",
                schema: "dbo",
                table: "StorageSpaces");

            migrationBuilder.DropForeignKey(
                name: "FK_StorageSpaces_Categories",
                schema: "dbo",
                table: "StorageSpaces");

            migrationBuilder.DropIndex(
                name: "IX_Assets_CurrentStageId",
                schema: "dbo",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "CurrentStageId",
                schema: "dbo",
                table: "Assets");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Counties",
                schema: "dbo",
                table: "Addresses",
                column: "CountyId",
                principalSchema: "dbo",
                principalTable: "Counties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Assets_Addresses",
                schema: "dbo",
                table: "Assets",
                column: "AddressId",
                principalSchema: "dbo",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Assets_Categories",
                schema: "dbo",
                table: "Assets",
                column: "CategoryId",
                principalSchema: "dbo",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Assets_Decisions",
                schema: "dbo",
                table: "Assets",
                column: "DecisionId",
                principalSchema: "dbo",
                principalTable: "Decisions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Assets_User_Add",
                schema: "dbo",
                table: "Assets",
                column: "UserCodeAdd",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "UserCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Assets_User_Change",
                schema: "dbo",
                table: "Assets",
                column: "UserCodeLastChange",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "UserCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetsFiles_Assets",
                schema: "dbo",
                table: "AssetsFiles",
                column: "AssetId",
                principalSchema: "dbo",
                principalTable: "Assets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetsFiles_Files",
                schema: "dbo",
                table: "AssetsFiles",
                column: "FileId",
                principalSchema: "dbo",
                principalTable: "Files",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetsFiles_User_Add",
                schema: "dbo",
                table: "AssetsFiles",
                column: "UserCodeAdd",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "UserCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetsFiles_User_Change",
                schema: "dbo",
                table: "AssetsFiles",
                column: "UserCodeLastChange",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "UserCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetsStorageSpaces_Assets",
                schema: "dbo",
                table: "AssetsStorageSpaces",
                column: "AssetId",
                principalSchema: "dbo",
                principalTable: "Assets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetsStorageSpaces_StorageSpaces",
                schema: "dbo",
                table: "AssetsStorageSpaces",
                column: "StorageSpaceId",
                principalSchema: "dbo",
                principalTable: "StorageSpaces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetsStorageSpaces_User_Add",
                schema: "dbo",
                table: "AssetsStorageSpaces",
                column: "UserCodeAdd",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "UserCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetsStorageSpaces_User_Change",
                schema: "dbo",
                table: "AssetsStorageSpaces",
                column: "UserCodeLastChange",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "UserCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Parent",
                schema: "dbo",
                table: "Categories",
                column: "ParentId",
                principalSchema: "dbo",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DefendantsFile_Dosare",
                schema: "dbo",
                table: "DefendantsFiles",
                column: "FileId",
                principalSchema: "dbo",
                principalTable: "Files",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DefendantsFile_Persoane",
                schema: "dbo",
                table: "DefendantsFiles",
                column: "PersonId",
                principalSchema: "dbo",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DefendantsFile_User_Add",
                schema: "dbo",
                table: "DefendantsFiles",
                column: "UserCodeAdd",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "UserCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DefendantsFile_User_Change",
                schema: "dbo",
                table: "DefendantsFiles",
                column: "UserCodeLastChange",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "UserCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NumereDosare_Institutii",
                schema: "dbo",
                table: "FileNumbers",
                column: "InstitutionId",
                principalSchema: "dbo",
                principalTable: "Institutions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NumereDosare_Utilizator_Adaugare",
                schema: "dbo",
                table: "FileNumbers",
                column: "UserCodeAdd",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "UserCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NumereDosare_Utilizator_Modificare",
                schema: "dbo",
                table: "FileNumbers",
                column: "UserCodeLastChange",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "UserCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Files_User_Add",
                schema: "dbo",
                table: "Files",
                column: "UserCodeAdd",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "UserCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Files_User_Change",
                schema: "dbo",
                table: "Files",
                column: "UserCodeLastChange",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "UserCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HistoricalStages_Assets",
                schema: "dbo",
                table: "HistoricalStages",
                column: "AssetId",
                principalSchema: "dbo",
                principalTable: "Assets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HistoricalStages_Decisions",
                schema: "dbo",
                table: "HistoricalStages",
                column: "DecizieId",
                principalSchema: "dbo",
                principalTable: "Decisions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HistoricalStages_Institutions",
                schema: "dbo",
                table: "HistoricalStages",
                column: "InstitutionId",
                principalSchema: "dbo",
                principalTable: "Institutions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OwnerId",
                schema: "dbo",
                table: "HistoricalStages",
                column: "OwnerId",
                principalSchema: "dbo",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HistoricalStages_Stages",
                schema: "dbo",
                table: "HistoricalStages",
                column: "StageId",
                principalSchema: "dbo",
                principalTable: "Stages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HistoricalStages_Utilizator_Add",
                schema: "dbo",
                table: "HistoricalStages",
                column: "UserCodeAdd",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "UserCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HistoricalStages_Utilizator_Change",
                schema: "dbo",
                table: "HistoricalStages",
                column: "UserCodeLastChange",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "UserCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Institutions_Categories",
                schema: "dbo",
                table: "Institutions",
                column: "CategoryId",
                principalSchema: "dbo",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Institutions_User_Add",
                schema: "dbo",
                table: "Institutions",
                column: "UserCodeAdd",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "UserCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Institutions_User_Change",
                schema: "dbo",
                table: "Institutions",
                column: "UserCodeLastChange",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "UserCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Addresses",
                schema: "dbo",
                table: "Persons",
                column: "AddressId",
                principalSchema: "dbo",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_User_Add",
                schema: "dbo",
                table: "Persons",
                column: "UserCodeAdd",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "UserCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_User_Change",
                schema: "dbo",
                table: "Persons",
                column: "UserCodeLastChange",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "UserCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StagesForDecision_Decision",
                schema: "dbo",
                table: "StagesForDecisions",
                column: "DecisionId",
                principalSchema: "dbo",
                principalTable: "Decisions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StagesForDecision_Stage",
                schema: "dbo",
                table: "StagesForDecisions",
                column: "StageId",
                principalSchema: "dbo",
                principalTable: "Stages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StorageSpaces_Addresses",
                schema: "dbo",
                table: "StorageSpaces",
                column: "AddressId",
                principalSchema: "dbo",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StorageSpaces_Categories",
                schema: "dbo",
                table: "StorageSpaces",
                column: "CategoryId",
                principalSchema: "dbo",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Counties",
                schema: "dbo",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Assets_Addresses",
                schema: "dbo",
                table: "Assets");

            migrationBuilder.DropForeignKey(
                name: "FK_Assets_Categories",
                schema: "dbo",
                table: "Assets");

            migrationBuilder.DropForeignKey(
                name: "FK_Assets_Decisions",
                schema: "dbo",
                table: "Assets");

            migrationBuilder.DropForeignKey(
                name: "FK_Assets_User_Add",
                schema: "dbo",
                table: "Assets");

            migrationBuilder.DropForeignKey(
                name: "FK_Assets_User_Change",
                schema: "dbo",
                table: "Assets");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetsFiles_Assets",
                schema: "dbo",
                table: "AssetsFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetsFiles_Files",
                schema: "dbo",
                table: "AssetsFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetsFiles_User_Add",
                schema: "dbo",
                table: "AssetsFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetsFiles_User_Change",
                schema: "dbo",
                table: "AssetsFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetsStorageSpaces_Assets",
                schema: "dbo",
                table: "AssetsStorageSpaces");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetsStorageSpaces_StorageSpaces",
                schema: "dbo",
                table: "AssetsStorageSpaces");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetsStorageSpaces_User_Add",
                schema: "dbo",
                table: "AssetsStorageSpaces");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetsStorageSpaces_User_Change",
                schema: "dbo",
                table: "AssetsStorageSpaces");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Parent",
                schema: "dbo",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_DefendantsFile_Dosare",
                schema: "dbo",
                table: "DefendantsFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_DefendantsFile_Persoane",
                schema: "dbo",
                table: "DefendantsFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_DefendantsFile_User_Add",
                schema: "dbo",
                table: "DefendantsFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_DefendantsFile_User_Change",
                schema: "dbo",
                table: "DefendantsFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_NumereDosare_Institutii",
                schema: "dbo",
                table: "FileNumbers");

            migrationBuilder.DropForeignKey(
                name: "FK_NumereDosare_Utilizator_Adaugare",
                schema: "dbo",
                table: "FileNumbers");

            migrationBuilder.DropForeignKey(
                name: "FK_NumereDosare_Utilizator_Modificare",
                schema: "dbo",
                table: "FileNumbers");

            migrationBuilder.DropForeignKey(
                name: "FK_Files_User_Add",
                schema: "dbo",
                table: "Files");

            migrationBuilder.DropForeignKey(
                name: "FK_Files_User_Change",
                schema: "dbo",
                table: "Files");

            migrationBuilder.DropForeignKey(
                name: "FK_HistoricalStages_Assets",
                schema: "dbo",
                table: "HistoricalStages");

            migrationBuilder.DropForeignKey(
                name: "FK_HistoricalStages_Decisions",
                schema: "dbo",
                table: "HistoricalStages");

            migrationBuilder.DropForeignKey(
                name: "FK_HistoricalStages_Institutions",
                schema: "dbo",
                table: "HistoricalStages");

            migrationBuilder.DropForeignKey(
                name: "FK_OwnerId",
                schema: "dbo",
                table: "HistoricalStages");

            migrationBuilder.DropForeignKey(
                name: "FK_HistoricalStages_Stages",
                schema: "dbo",
                table: "HistoricalStages");

            migrationBuilder.DropForeignKey(
                name: "FK_HistoricalStages_Utilizator_Add",
                schema: "dbo",
                table: "HistoricalStages");

            migrationBuilder.DropForeignKey(
                name: "FK_HistoricalStages_Utilizator_Change",
                schema: "dbo",
                table: "HistoricalStages");

            migrationBuilder.DropForeignKey(
                name: "FK_Institutions_Categories",
                schema: "dbo",
                table: "Institutions");

            migrationBuilder.DropForeignKey(
                name: "FK_Institutions_User_Add",
                schema: "dbo",
                table: "Institutions");

            migrationBuilder.DropForeignKey(
                name: "FK_Institutions_User_Change",
                schema: "dbo",
                table: "Institutions");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Addresses",
                schema: "dbo",
                table: "Persons");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_User_Add",
                schema: "dbo",
                table: "Persons");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_User_Change",
                schema: "dbo",
                table: "Persons");

            migrationBuilder.DropForeignKey(
                name: "FK_StagesForDecision_Decision",
                schema: "dbo",
                table: "StagesForDecisions");

            migrationBuilder.DropForeignKey(
                name: "FK_StagesForDecision_Stage",
                schema: "dbo",
                table: "StagesForDecisions");

            migrationBuilder.DropForeignKey(
                name: "FK_StorageSpaces_Addresses",
                schema: "dbo",
                table: "StorageSpaces");

            migrationBuilder.DropForeignKey(
                name: "FK_StorageSpaces_Categories",
                schema: "dbo",
                table: "StorageSpaces");

            migrationBuilder.AddColumn<int>(
                name: "CurrentStageId",
                schema: "dbo",
                table: "Assets",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Assets_CurrentStageId",
                schema: "dbo",
                table: "Assets",
                column: "CurrentStageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Counties",
                schema: "dbo",
                table: "Addresses",
                column: "CountyId",
                principalSchema: "dbo",
                principalTable: "Counties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Assets_Addresses",
                schema: "dbo",
                table: "Assets",
                column: "AddressId",
                principalSchema: "dbo",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Assets_Categories",
                schema: "dbo",
                table: "Assets",
                column: "CategoryId",
                principalSchema: "dbo",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Assets_Stages",
                schema: "dbo",
                table: "Assets",
                column: "CurrentStageId",
                principalSchema: "dbo",
                principalTable: "Stages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Assets_Decisions",
                schema: "dbo",
                table: "Assets",
                column: "DecisionId",
                principalSchema: "dbo",
                principalTable: "Decisions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Assets_Users_UserCodeAdd",
                schema: "dbo",
                table: "Assets",
                column: "UserCodeAdd",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "UserCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Assets_Users_UserCodeLastChange",
                schema: "dbo",
                table: "Assets",
                column: "UserCodeLastChange",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "UserCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetsFiles_Assets",
                schema: "dbo",
                table: "AssetsFiles",
                column: "AssetId",
                principalSchema: "dbo",
                principalTable: "Assets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetsFiles_Files",
                schema: "dbo",
                table: "AssetsFiles",
                column: "FileId",
                principalSchema: "dbo",
                principalTable: "Files",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetsFiles_Users_UserCodeAdd",
                schema: "dbo",
                table: "AssetsFiles",
                column: "UserCodeAdd",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "UserCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetsFiles_Users_UserCodeLastChange",
                schema: "dbo",
                table: "AssetsFiles",
                column: "UserCodeLastChange",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "UserCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetsStorageSpaces_Assets",
                schema: "dbo",
                table: "AssetsStorageSpaces",
                column: "AssetId",
                principalSchema: "dbo",
                principalTable: "Assets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetsStorageSpaces_StorageSpaces",
                schema: "dbo",
                table: "AssetsStorageSpaces",
                column: "StorageSpaceId",
                principalSchema: "dbo",
                principalTable: "StorageSpaces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetsStorageSpaces_Users_UserCodeAdd",
                schema: "dbo",
                table: "AssetsStorageSpaces",
                column: "UserCodeAdd",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "UserCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetsStorageSpaces_Users_UserCodeLastChange",
                schema: "dbo",
                table: "AssetsStorageSpaces",
                column: "UserCodeLastChange",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "UserCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Parent",
                schema: "dbo",
                table: "Categories",
                column: "ParentId",
                principalSchema: "dbo",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DefendantsFile_Dosare",
                schema: "dbo",
                table: "DefendantsFiles",
                column: "FileId",
                principalSchema: "dbo",
                principalTable: "Files",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DefendantsFile_Persoane",
                schema: "dbo",
                table: "DefendantsFiles",
                column: "PersonId",
                principalSchema: "dbo",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DefendantsFiles_Users_UserCodeAdd",
                schema: "dbo",
                table: "DefendantsFiles",
                column: "UserCodeAdd",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "UserCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DefendantsFiles_Users_UserCodeLastChange",
                schema: "dbo",
                table: "DefendantsFiles",
                column: "UserCodeLastChange",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "UserCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NumereDosare_Institutii",
                schema: "dbo",
                table: "FileNumbers",
                column: "InstitutionId",
                principalSchema: "dbo",
                principalTable: "Institutions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FileNumbers_Users_UserCodeAdd",
                schema: "dbo",
                table: "FileNumbers",
                column: "UserCodeAdd",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "UserCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FileNumbers_Users_UserCodeLastChange",
                schema: "dbo",
                table: "FileNumbers",
                column: "UserCodeLastChange",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "UserCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Users_UserCodeAdd",
                schema: "dbo",
                table: "Files",
                column: "UserCodeAdd",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "UserCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Users_UserCodeLastChange",
                schema: "dbo",
                table: "Files",
                column: "UserCodeLastChange",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "UserCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HistoricalStages_Assets",
                schema: "dbo",
                table: "HistoricalStages",
                column: "AssetId",
                principalSchema: "dbo",
                principalTable: "Assets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HistoricalStages_Decisions",
                schema: "dbo",
                table: "HistoricalStages",
                column: "DecizieId",
                principalSchema: "dbo",
                principalTable: "Decisions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HistoricalStages_Institutions",
                schema: "dbo",
                table: "HistoricalStages",
                column: "InstitutionId",
                principalSchema: "dbo",
                principalTable: "Institutions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OwnerId",
                schema: "dbo",
                table: "HistoricalStages",
                column: "OwnerId",
                principalSchema: "dbo",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HistoricalStages_Stages",
                schema: "dbo",
                table: "HistoricalStages",
                column: "StageId",
                principalSchema: "dbo",
                principalTable: "Stages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HistoricalStages_Users_UserCodeAdd",
                schema: "dbo",
                table: "HistoricalStages",
                column: "UserCodeAdd",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "UserCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HistoricalStages_Users_UserCodeLastChange",
                schema: "dbo",
                table: "HistoricalStages",
                column: "UserCodeLastChange",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "UserCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Institutions_Categories",
                schema: "dbo",
                table: "Institutions",
                column: "CategoryId",
                principalSchema: "dbo",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Institutions_Users_UserCodeAdd",
                schema: "dbo",
                table: "Institutions",
                column: "UserCodeAdd",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "UserCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Institutions_Users_UserCodeLastChange",
                schema: "dbo",
                table: "Institutions",
                column: "UserCodeLastChange",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "UserCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Addresses",
                schema: "dbo",
                table: "Persons",
                column: "AddressId",
                principalSchema: "dbo",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Users_UserCodeAdd",
                schema: "dbo",
                table: "Persons",
                column: "UserCodeAdd",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "UserCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Users_UserCodeLastChange",
                schema: "dbo",
                table: "Persons",
                column: "UserCodeLastChange",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "UserCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StagesForDecision_Decision",
                schema: "dbo",
                table: "StagesForDecisions",
                column: "DecisionId",
                principalSchema: "dbo",
                principalTable: "Decisions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StagesForDecision_Stage",
                schema: "dbo",
                table: "StagesForDecisions",
                column: "StageId",
                principalSchema: "dbo",
                principalTable: "Stages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StorageSpaces_Addresses",
                schema: "dbo",
                table: "StorageSpaces",
                column: "AddressId",
                principalSchema: "dbo",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StorageSpaces_Categories",
                schema: "dbo",
                table: "StorageSpaces",
                column: "CategoryId",
                principalSchema: "dbo",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
