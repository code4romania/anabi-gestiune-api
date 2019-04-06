using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Anabi.DataAccess.Ef.Migrations
{
    public partial class _20190406_add_storage_space_type : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            /*migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Counties",
                schema: "dbo",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetDefendants_User_Add",
                schema: "dbo",
                table: "AssetDefendants");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetDefendants_User_Change",
                schema: "dbo",
                table: "AssetDefendants");

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
                name: "FK_Assets_Files_FileDbId",
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
                name: "FK_FileNumbers_Files_FileDbId",
                schema: "dbo",
                table: "FileNumbers");

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
                name: "FK_Files_FileNumbers_CurrentNumberId",
                schema: "dbo",
                table: "Files");

            migrationBuilder.DropForeignKey(
                name: "FK_Files_FileNumbers_InitialNumberId",
                schema: "dbo",
                table: "Files");

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
                name: "FK_Identifiers_User_Add",
                schema: "dbo",
                table: "Identifiers");

            migrationBuilder.DropForeignKey(
                name: "FK_Identifiers_User_Change",
                schema: "dbo",
                table: "Identifiers");

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
                name: "FK_Persons_Identifiers",
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

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Users_UserCode",
                schema: "dbo",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_Email",
                schema: "dbo",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserCode",
                schema: "dbo",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_StorageSpaces_Name",
                schema: "dbo",
                table: "StorageSpaces");

            migrationBuilder.DropIndex(
                name: "indx_Stage_Decision",
                schema: "dbo",
                table: "StagesForDecisions");

            migrationBuilder.DropIndex(
                name: "indx_uq_stagename",
                schema: "dbo",
                table: "Stages");

            migrationBuilder.DropIndex(
                name: "IX_RecoveryBeneficiaries_Name",
                schema: "dbo",
                table: "RecoveryBeneficiaries");

            migrationBuilder.DropIndex(
                name: "indx_uq_Persons",
                schema: "dbo",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Persons_UserCodeAdd",
                schema: "dbo",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Persons_UserCodeLastChange",
                schema: "dbo",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Institutions_UserCodeAdd",
                schema: "dbo",
                table: "Institutions");

            migrationBuilder.DropIndex(
                name: "IX_Institutions_UserCodeLastChange",
                schema: "dbo",
                table: "Institutions");

            migrationBuilder.DropIndex(
                name: "IX_Identifiers_UserCodeAdd",
                schema: "dbo",
                table: "Identifiers");

            migrationBuilder.DropIndex(
                name: "IX_Identifiers_UserCodeLastChange",
                schema: "dbo",
                table: "Identifiers");

            migrationBuilder.DropIndex(
                name: "IX_HistoricalStages_DecizieId",
                schema: "dbo",
                table: "HistoricalStages");

            migrationBuilder.DropIndex(
                name: "IX_HistoricalStages_InstitutionId",
                schema: "dbo",
                table: "HistoricalStages");

            migrationBuilder.DropIndex(
                name: "IX_HistoricalStages_OwnerId",
                schema: "dbo",
                table: "HistoricalStages");

            migrationBuilder.DropIndex(
                name: "IX_HistoricalStages_UserCodeAdd",
                schema: "dbo",
                table: "HistoricalStages");

            migrationBuilder.DropIndex(
                name: "IX_HistoricalStages_UserCodeLastChange",
                schema: "dbo",
                table: "HistoricalStages");

            migrationBuilder.DropIndex(
                name: "indx_uq_Decision",
                schema: "dbo",
                table: "Decisions");

            migrationBuilder.DropIndex(
                name: "IX_Counties_Abreviation",
                schema: "dbo",
                table: "Counties");

            migrationBuilder.DropIndex(
                name: "indx_code_forentity",
                schema: "dbo",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Assets_DecisionId",
                schema: "dbo",
                table: "Assets");

            migrationBuilder.DropIndex(
                name: "IX_Assets_UserCodeAdd",
                schema: "dbo",
                table: "Assets");

            migrationBuilder.DropIndex(
                name: "IX_Assets_UserCodeLastChange",
                schema: "dbo",
                table: "Assets");

            migrationBuilder.DropIndex(
                name: "IX_AssetDefendants_UserCodeAdd",
                schema: "dbo",
                table: "AssetDefendants");

            migrationBuilder.DropIndex(
                name: "IX_AssetDefendants_UserCodeLastChange",
                schema: "dbo",
                table: "AssetDefendants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Files",
                schema: "dbo",
                table: "Files");

            migrationBuilder.DropIndex(
                name: "IX_Files_UserCodeAdd",
                schema: "dbo",
                table: "Files");

            migrationBuilder.DropIndex(
                name: "IX_Files_UserCodeLastChange",
                schema: "dbo",
                table: "Files");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FileNumbers",
                schema: "dbo",
                table: "FileNumbers");

            migrationBuilder.DropIndex(
                name: "IX_FileNumbers_UserCodeAdd",
                schema: "dbo",
                table: "FileNumbers");

            migrationBuilder.DropIndex(
                name: "IX_FileNumbers_UserCodeLastChange",
                schema: "dbo",
                table: "FileNumbers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DefendantsFiles",
                schema: "dbo",
                table: "DefendantsFiles");

            migrationBuilder.DropIndex(
                name: "IX_DefendantsFiles_UserCodeAdd",
                schema: "dbo",
                table: "DefendantsFiles");

            migrationBuilder.DropIndex(
                name: "IX_DefendantsFiles_UserCodeLastChange",
                schema: "dbo",
                table: "DefendantsFiles");

            migrationBuilder.DropIndex(
                name: "indx_uq_DefendantsFile",
                schema: "dbo",
                table: "DefendantsFiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AssetsStorageSpaces",
                schema: "dbo",
                table: "AssetsStorageSpaces");

            migrationBuilder.DropIndex(
                name: "IX_AssetsStorageSpaces_UserCodeAdd",
                schema: "dbo",
                table: "AssetsStorageSpaces");

            migrationBuilder.DropIndex(
                name: "IX_AssetsStorageSpaces_UserCodeLastChange",
                schema: "dbo",
                table: "AssetsStorageSpaces");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AssetsFiles",
                schema: "dbo",
                table: "AssetsFiles");

            migrationBuilder.DropIndex(
                name: "IX_AssetsFiles_UserCodeAdd",
                schema: "dbo",
                table: "AssetsFiles");

            migrationBuilder.DropIndex(
                name: "IX_AssetsFiles_UserCodeLastChange",
                schema: "dbo",
                table: "AssetsFiles");

            migrationBuilder.RenameTable(
                name: "Users",
                schema: "dbo",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "StorageSpaces",
                schema: "dbo",
                newName: "StorageSpaces");

            migrationBuilder.RenameTable(
                name: "StagesForDecisions",
                schema: "dbo",
                newName: "StagesForDecisions");

            migrationBuilder.RenameTable(
                name: "Stages",
                schema: "dbo",
                newName: "Stages");

            migrationBuilder.RenameTable(
                name: "RecoveryBeneficiaries",
                schema: "dbo",
                newName: "RecoveryBeneficiaries");

            migrationBuilder.RenameTable(
                name: "PrecautionaryMeasures",
                schema: "dbo",
                newName: "PrecautionaryMeasures");

            migrationBuilder.RenameTable(
                name: "Persons",
                schema: "dbo",
                newName: "Persons");

            migrationBuilder.RenameTable(
                name: "Institutions",
                schema: "dbo",
                newName: "Institutions");

            migrationBuilder.RenameTable(
                name: "Identifiers",
                schema: "dbo",
                newName: "Identifiers");

            migrationBuilder.RenameTable(
                name: "HistoricalStages",
                schema: "dbo",
                newName: "HistoricalStages");

            migrationBuilder.RenameTable(
                name: "Decisions",
                schema: "dbo",
                newName: "Decisions");

            migrationBuilder.RenameTable(
                name: "CrimeTypes",
                schema: "dbo",
                newName: "CrimeTypes");

            migrationBuilder.RenameTable(
                name: "Counties",
                schema: "dbo",
                newName: "Counties");

            migrationBuilder.RenameTable(
                name: "Categories",
                schema: "dbo",
                newName: "Categories");

            migrationBuilder.RenameTable(
                name: "Assets",
                schema: "dbo",
                newName: "Assets");

            migrationBuilder.RenameTable(
                name: "AssetDefendants",
                schema: "dbo",
                newName: "AssetDefendants");

            migrationBuilder.RenameTable(
                name: "Addresses",
                schema: "dbo",
                newName: "Addresses");

            migrationBuilder.RenameTable(
                name: "Files",
                schema: "dbo",
                newName: "Dosare");

            migrationBuilder.RenameTable(
                name: "FileNumbers",
                schema: "dbo",
                newName: "NumereDosare");

            migrationBuilder.RenameTable(
                name: "DefendantsFiles",
                schema: "dbo",
                newName: "InculpatiDosar");

            migrationBuilder.RenameTable(
                name: "AssetsStorageSpaces",
                schema: "dbo",
                newName: "AssetStorageSpaces");

            migrationBuilder.RenameTable(
                name: "AssetsFiles",
                schema: "dbo",
                newName: "BunuriDosare");

            migrationBuilder.RenameIndex(
                name: "IX_Files_InitialNumberId",
                table: "Dosare",
                newName: "IX_Dosare_InitialNumberId");

            migrationBuilder.RenameIndex(
                name: "IX_Files_CurrentNumberId",
                table: "Dosare",
                newName: "IX_Dosare_CurrentNumberId");

            migrationBuilder.RenameIndex(
                name: "IX_FileNumbers_InstitutionId",
                table: "NumereDosare",
                newName: "IX_NumereDosare_InstitutionId");

            migrationBuilder.RenameIndex(
                name: "IX_FileNumbers_FileDbId",
                table: "NumereDosare",
                newName: "IX_NumereDosare_FileDbId");

            migrationBuilder.RenameIndex(
                name: "IX_DefendantsFiles_FileId",
                table: "InculpatiDosar",
                newName: "IX_InculpatiDosar_FileId");

            migrationBuilder.RenameIndex(
                name: "IX_AssetsStorageSpaces_StorageSpaceId",
                table: "AssetStorageSpaces",
                newName: "IX_AssetStorageSpaces_StorageSpaceId");

            migrationBuilder.RenameIndex(
                name: "IX_AssetsStorageSpaces_AssetId",
                table: "AssetStorageSpaces",
                newName: "IX_AssetStorageSpaces_AssetId");

            migrationBuilder.RenameIndex(
                name: "IX_AssetsFiles_FileId",
                table: "BunuriDosare",
                newName: "IX_BunuriDosare_FileId");

            migrationBuilder.RenameIndex(
                name: "IX_AssetsFiles_AssetId",
                table: "BunuriDosare",
                newName: "IX_BunuriDosare_AssetId");

            migrationBuilder.AlterColumn<string>(
                name: "UserCode",
                table: "Users",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Salt",
                table: "Users",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "Users",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 5000);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Users",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Users",
                nullable: false,
                oldClrType: typeof(bool),
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<decimal>(
                name: "Width",
                table: "StorageSpaces",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "Decimal(20, 2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "UndevelopedArea",
                table: "StorageSpaces",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "Decimal(20, 2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalVolume",
                table: "StorageSpaces",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "Decimal(20, 2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "StorageSpaces",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<decimal>(
                name: "MonthlyMaintenanceCost",
                table: "StorageSpaces",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "Decimal(20, 2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Length",
                table: "StorageSpaces",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "Decimal(20, 2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "StorageSpaces",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 2000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ContactData",
                table: "StorageSpaces",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "StorageSpaces",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<decimal>(
                name: "AvailableVolume",
                table: "StorageSpaces",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "Decimal(20, 2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "AsphaltedArea",
                table: "StorageSpaces",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "Decimal(20, 2)",
                oldNullable: true);*/

            migrationBuilder.AddColumn<int>(
                name: "StorageSpacesType",
                table: "StorageSpaces",
                nullable: false,
                defaultValue: 0);

            /*migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Stages",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "RecoveryBeneficiaries",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 200);

            migrationBuilder.AddColumn<DateTime>(
                name: "AddedDate",
                table: "RecoveryBeneficiaries",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastChangeDate",
                table: "RecoveryBeneficiaries",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserCodeAdd",
                table: "RecoveryBeneficiaries",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserCodeLastChange",
                table: "RecoveryBeneficiaries",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserCodeLastChange",
                table: "PrecautionaryMeasures",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserCodeAdd",
                table: "PrecautionaryMeasures",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Persons",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastChangeDate",
                table: "Persons",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "Datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Identification",
                table: "Persons",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "IdSerie",
                table: "Persons",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 2,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IdNumber",
                table: "Persons",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 6,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AddressId",
                table: "Persons",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<DateTime>(
                name: "AddedDate",
                table: "Persons",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DateTime");

            migrationBuilder.AddColumn<int>(
                name: "UserDbId",
                table: "Persons",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserDbId1",
                table: "Persons",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Institutions",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastChangeDate",
                table: "Institutions",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "Datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "AddedDate",
                table: "Institutions",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DateTime");

            migrationBuilder.AddColumn<int>(
                name: "UserDbId",
                table: "Institutions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserDbId1",
                table: "Institutions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserDbId",
                table: "Identifiers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserDbId1",
                table: "Identifiers",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OwnerId",
                table: "HistoricalStages",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "Int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LegalBasis",
                table: "HistoricalStages",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastChangeDate",
                table: "HistoricalStages",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "Datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "InstitutionId",
                table: "HistoricalStages",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "EstimatedAmountCurrency",
                table: "HistoricalStages",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 3);

            migrationBuilder.AlterColumn<decimal>(
                name: "EstimatedAmount",
                table: "HistoricalStages",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "Decimal(20,2)");

            migrationBuilder.AlterColumn<int>(
                name: "DecizieId",
                table: "HistoricalStages",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "DecisionNumber",
                table: "HistoricalStages",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DecisionDate",
                table: "HistoricalStages",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "Date");

            migrationBuilder.AlterColumn<string>(
                name: "AssetState",
                table: "HistoricalStages",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "AddedDate",
                table: "HistoricalStages",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DateTime");

            migrationBuilder.AlterColumn<string>(
                name: "ActualValueCurrency",
                table: "HistoricalStages",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 3);

            migrationBuilder.AlterColumn<decimal>(
                name: "ActualValue",
                table: "HistoricalStages",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "Decimal(20, 2)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DecisionId",
                table: "HistoricalStages",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IssuingInstitutionId",
                table: "HistoricalStages",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "HistoricalStages",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserDbId",
                table: "HistoricalStages",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserDbId1",
                table: "HistoricalStages",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Decisions",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "UserCodeLastChange",
                table: "CrimeTypes",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserCodeAdd",
                table: "CrimeTypes",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Counties",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Abreviation",
                table: "Counties",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 2);

            migrationBuilder.AlterColumn<string>(
                name: "ForEntity",
                table: "Categories",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Categories",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 2000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Categories",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<decimal>(
                name: "NecessaryVolume",
                table: "Assets",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "Decimal(20, 2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastChangeDate",
                table: "Assets",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "Datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Identifier",
                table: "Assets",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DecisionId",
                table: "Assets",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "AddressId",
                table: "Assets",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<DateTime>(
                name: "AddedDate",
                table: "Assets",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DateTime");

            migrationBuilder.AddColumn<int>(
                name: "CurrentDecisionId",
                table: "Assets",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserDbId",
                table: "Assets",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserDbId1",
                table: "Assets",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserDbId",
                table: "AssetDefendants",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserDbId1",
                table: "AssetDefendants",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserCodeLastChange",
                table: "Addresses",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserCodeAdd",
                table: "Addresses",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Street",
                table: "Addresses",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Stair",
                table: "Addresses",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 5,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Floor",
                table: "Addresses",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 5,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FlatNo",
                table: "Addresses",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 5,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Addresses",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Building",
                table: "Addresses",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LegalClassification",
                table: "Dosare",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastChangeDate",
                table: "Dosare",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "Datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "InitialFileNumber",
                table: "Dosare",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "DamageCurrency",
                table: "Dosare",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "CurrentFileNumber",
                table: "Dosare",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "CriminalField",
                table: "Dosare",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<DateTime>(
                name: "AddedDate",
                table: "Dosare",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DateTime");

            migrationBuilder.AddColumn<int>(
                name: "UserDbId",
                table: "Dosare",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserDbId1",
                table: "Dosare",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "NumberDate",
                table: "NumereDosare",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "Datetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastChangeDate",
                table: "NumereDosare",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "Datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FileNumber",
                table: "NumereDosare",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<DateTime>(
                name: "AddedDate",
                table: "NumereDosare",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DateTime");

            migrationBuilder.AddColumn<int>(
                name: "UserDbId",
                table: "NumereDosare",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserDbId1",
                table: "NumereDosare",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastChangeDate",
                table: "InculpatiDosar",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "Datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "AddedDate",
                table: "InculpatiDosar",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DateTime");

            migrationBuilder.AddColumn<int>(
                name: "DefendantId",
                table: "InculpatiDosar",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserDbId",
                table: "InculpatiDosar",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserDbId1",
                table: "InculpatiDosar",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastChangeDate",
                table: "AssetStorageSpaces",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "Datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExitDate",
                table: "AssetStorageSpaces",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "Datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "EntryDate",
                table: "AssetStorageSpaces",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DateTime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "AddedDate",
                table: "AssetStorageSpaces",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DateTime");

            migrationBuilder.AddColumn<int>(
                name: "UserDbId",
                table: "AssetStorageSpaces",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserDbId1",
                table: "AssetStorageSpaces",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastChangeDate",
                table: "BunuriDosare",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "Datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "AddedDate",
                table: "BunuriDosare",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DateTime");

            migrationBuilder.AddColumn<int>(
                name: "UserDbId",
                table: "BunuriDosare",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserDbId1",
                table: "BunuriDosare",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dosare",
                table: "Dosare",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NumereDosare",
                table: "NumereDosare",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InculpatiDosar",
                table: "InculpatiDosar",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AssetStorageSpaces",
                table: "AssetStorageSpaces",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BunuriDosare",
                table: "BunuriDosare",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_StagesForDecisions_StageId",
                table: "StagesForDecisions",
                column: "StageId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_UserDbId",
                table: "Persons",
                column: "UserDbId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_UserDbId1",
                table: "Persons",
                column: "UserDbId1");

            migrationBuilder.CreateIndex(
                name: "IX_Institutions_UserDbId",
                table: "Institutions",
                column: "UserDbId");

            migrationBuilder.CreateIndex(
                name: "IX_Institutions_UserDbId1",
                table: "Institutions",
                column: "UserDbId1");

            migrationBuilder.CreateIndex(
                name: "IX_Identifiers_UserDbId",
                table: "Identifiers",
                column: "UserDbId");

            migrationBuilder.CreateIndex(
                name: "IX_Identifiers_UserDbId1",
                table: "Identifiers",
                column: "UserDbId1");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricalStages_DecisionId",
                table: "HistoricalStages",
                column: "DecisionId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricalStages_IssuingInstitutionId",
                table: "HistoricalStages",
                column: "IssuingInstitutionId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricalStages_PersonId",
                table: "HistoricalStages",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricalStages_UserDbId",
                table: "HistoricalStages",
                column: "UserDbId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricalStages_UserDbId1",
                table: "HistoricalStages",
                column: "UserDbId1");

            migrationBuilder.CreateIndex(
                name: "IX_Assets_CurrentDecisionId",
                table: "Assets",
                column: "CurrentDecisionId");

            migrationBuilder.CreateIndex(
                name: "IX_Assets_UserDbId",
                table: "Assets",
                column: "UserDbId");

            migrationBuilder.CreateIndex(
                name: "IX_Assets_UserDbId1",
                table: "Assets",
                column: "UserDbId1");

            migrationBuilder.CreateIndex(
                name: "IX_AssetDefendants_UserDbId",
                table: "AssetDefendants",
                column: "UserDbId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetDefendants_UserDbId1",
                table: "AssetDefendants",
                column: "UserDbId1");

            migrationBuilder.CreateIndex(
                name: "IX_Dosare_UserDbId",
                table: "Dosare",
                column: "UserDbId");

            migrationBuilder.CreateIndex(
                name: "IX_Dosare_UserDbId1",
                table: "Dosare",
                column: "UserDbId1");

            migrationBuilder.CreateIndex(
                name: "IX_NumereDosare_UserDbId",
                table: "NumereDosare",
                column: "UserDbId");

            migrationBuilder.CreateIndex(
                name: "IX_NumereDosare_UserDbId1",
                table: "NumereDosare",
                column: "UserDbId1");

            migrationBuilder.CreateIndex(
                name: "IX_InculpatiDosar_DefendantId",
                table: "InculpatiDosar",
                column: "DefendantId");

            migrationBuilder.CreateIndex(
                name: "IX_InculpatiDosar_UserDbId",
                table: "InculpatiDosar",
                column: "UserDbId");

            migrationBuilder.CreateIndex(
                name: "IX_InculpatiDosar_UserDbId1",
                table: "InculpatiDosar",
                column: "UserDbId1");

            migrationBuilder.CreateIndex(
                name: "IX_AssetStorageSpaces_UserDbId",
                table: "AssetStorageSpaces",
                column: "UserDbId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetStorageSpaces_UserDbId1",
                table: "AssetStorageSpaces",
                column: "UserDbId1");

            migrationBuilder.CreateIndex(
                name: "IX_BunuriDosare_UserDbId",
                table: "BunuriDosare",
                column: "UserDbId");

            migrationBuilder.CreateIndex(
                name: "IX_BunuriDosare_UserDbId1",
                table: "BunuriDosare",
                column: "UserDbId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Counties_CountyId",
                table: "Addresses",
                column: "CountyId",
                principalTable: "Counties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetDefendants_Users_UserDbId",
                table: "AssetDefendants",
                column: "UserDbId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetDefendants_Users_UserDbId1",
                table: "AssetDefendants",
                column: "UserDbId1",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Assets_Addresses_AddressId",
                table: "Assets",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Assets_Categories_CategoryId",
                table: "Assets",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Assets_Decisions_CurrentDecisionId",
                table: "Assets",
                column: "CurrentDecisionId",
                principalTable: "Decisions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Assets_Dosare_FileDbId",
                table: "Assets",
                column: "FileDbId",
                principalTable: "Dosare",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Assets_Users_UserDbId",
                table: "Assets",
                column: "UserDbId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Assets_Users_UserDbId1",
                table: "Assets",
                column: "UserDbId1",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetStorageSpaces_Assets_AssetId",
                table: "AssetStorageSpaces",
                column: "AssetId",
                principalTable: "Assets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetStorageSpaces_StorageSpaces_StorageSpaceId",
                table: "AssetStorageSpaces",
                column: "StorageSpaceId",
                principalTable: "StorageSpaces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetStorageSpaces_Users_UserDbId",
                table: "AssetStorageSpaces",
                column: "UserDbId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetStorageSpaces_Users_UserDbId1",
                table: "AssetStorageSpaces",
                column: "UserDbId1",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BunuriDosare_Assets_AssetId",
                table: "BunuriDosare",
                column: "AssetId",
                principalTable: "Assets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BunuriDosare_Dosare_FileId",
                table: "BunuriDosare",
                column: "FileId",
                principalTable: "Dosare",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BunuriDosare_Users_UserDbId",
                table: "BunuriDosare",
                column: "UserDbId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BunuriDosare_Users_UserDbId1",
                table: "BunuriDosare",
                column: "UserDbId1",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Categories_ParentId",
                table: "Categories",
                column: "ParentId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Dosare_NumereDosare_CurrentNumberId",
                table: "Dosare",
                column: "CurrentNumberId",
                principalTable: "NumereDosare",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Dosare_NumereDosare_InitialNumberId",
                table: "Dosare",
                column: "InitialNumberId",
                principalTable: "NumereDosare",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Dosare_Users_UserDbId",
                table: "Dosare",
                column: "UserDbId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Dosare_Users_UserDbId1",
                table: "Dosare",
                column: "UserDbId1",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HistoricalStages_Assets_AssetId",
                table: "HistoricalStages",
                column: "AssetId",
                principalTable: "Assets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HistoricalStages_Decisions_DecisionId",
                table: "HistoricalStages",
                column: "DecisionId",
                principalTable: "Decisions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HistoricalStages_Institutions_IssuingInstitutionId",
                table: "HistoricalStages",
                column: "IssuingInstitutionId",
                principalTable: "Institutions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HistoricalStages_Persons_PersonId",
                table: "HistoricalStages",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HistoricalStages_Stages_StageId",
                table: "HistoricalStages",
                column: "StageId",
                principalTable: "Stages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HistoricalStages_Users_UserDbId",
                table: "HistoricalStages",
                column: "UserDbId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HistoricalStages_Users_UserDbId1",
                table: "HistoricalStages",
                column: "UserDbId1",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Identifiers_Users_UserDbId",
                table: "Identifiers",
                column: "UserDbId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Identifiers_Users_UserDbId1",
                table: "Identifiers",
                column: "UserDbId1",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InculpatiDosar_Persons_DefendantId",
                table: "InculpatiDosar",
                column: "DefendantId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InculpatiDosar_Dosare_FileId",
                table: "InculpatiDosar",
                column: "FileId",
                principalTable: "Dosare",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InculpatiDosar_Users_UserDbId",
                table: "InculpatiDosar",
                column: "UserDbId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InculpatiDosar_Users_UserDbId1",
                table: "InculpatiDosar",
                column: "UserDbId1",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Institutions_Categories_CategoryId",
                table: "Institutions",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Institutions_Users_UserDbId",
                table: "Institutions",
                column: "UserDbId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Institutions_Users_UserDbId1",
                table: "Institutions",
                column: "UserDbId1",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NumereDosare_Dosare_FileDbId",
                table: "NumereDosare",
                column: "FileDbId",
                principalTable: "Dosare",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NumereDosare_Institutions_InstitutionId",
                table: "NumereDosare",
                column: "InstitutionId",
                principalTable: "Institutions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NumereDosare_Users_UserDbId",
                table: "NumereDosare",
                column: "UserDbId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NumereDosare_Users_UserDbId1",
                table: "NumereDosare",
                column: "UserDbId1",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Addresses_AddressId",
                table: "Persons",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Identifiers_IdentifierId",
                table: "Persons",
                column: "IdentifierId",
                principalTable: "Identifiers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Users_UserDbId",
                table: "Persons",
                column: "UserDbId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Users_UserDbId1",
                table: "Persons",
                column: "UserDbId1",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StagesForDecisions_Decisions_DecisionId",
                table: "StagesForDecisions",
                column: "DecisionId",
                principalTable: "Decisions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StagesForDecisions_Stages_StageId",
                table: "StagesForDecisions",
                column: "StageId",
                principalTable: "Stages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StorageSpaces_Addresses_AddressId",
                table: "StorageSpaces",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StorageSpaces_Categories_CategoryId",
                table: "StorageSpaces",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }*/

        /*protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Counties_CountyId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetDefendants_Users_UserDbId",
                table: "AssetDefendants");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetDefendants_Users_UserDbId1",
                table: "AssetDefendants");

            migrationBuilder.DropForeignKey(
                name: "FK_Assets_Addresses_AddressId",
                table: "Assets");

            migrationBuilder.DropForeignKey(
                name: "FK_Assets_Categories_CategoryId",
                table: "Assets");

            migrationBuilder.DropForeignKey(
                name: "FK_Assets_Decisions_CurrentDecisionId",
                table: "Assets");

            migrationBuilder.DropForeignKey(
                name: "FK_Assets_Dosare_FileDbId",
                table: "Assets");

            migrationBuilder.DropForeignKey(
                name: "FK_Assets_Users_UserDbId",
                table: "Assets");

            migrationBuilder.DropForeignKey(
                name: "FK_Assets_Users_UserDbId1",
                table: "Assets");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetStorageSpaces_Assets_AssetId",
                table: "AssetStorageSpaces");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetStorageSpaces_StorageSpaces_StorageSpaceId",
                table: "AssetStorageSpaces");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetStorageSpaces_Users_UserDbId",
                table: "AssetStorageSpaces");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetStorageSpaces_Users_UserDbId1",
                table: "AssetStorageSpaces");

            migrationBuilder.DropForeignKey(
                name: "FK_BunuriDosare_Assets_AssetId",
                table: "BunuriDosare");

            migrationBuilder.DropForeignKey(
                name: "FK_BunuriDosare_Dosare_FileId",
                table: "BunuriDosare");

            migrationBuilder.DropForeignKey(
                name: "FK_BunuriDosare_Users_UserDbId",
                table: "BunuriDosare");

            migrationBuilder.DropForeignKey(
                name: "FK_BunuriDosare_Users_UserDbId1",
                table: "BunuriDosare");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Categories_ParentId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Dosare_NumereDosare_CurrentNumberId",
                table: "Dosare");

            migrationBuilder.DropForeignKey(
                name: "FK_Dosare_NumereDosare_InitialNumberId",
                table: "Dosare");

            migrationBuilder.DropForeignKey(
                name: "FK_Dosare_Users_UserDbId",
                table: "Dosare");

            migrationBuilder.DropForeignKey(
                name: "FK_Dosare_Users_UserDbId1",
                table: "Dosare");

            migrationBuilder.DropForeignKey(
                name: "FK_HistoricalStages_Assets_AssetId",
                table: "HistoricalStages");

            migrationBuilder.DropForeignKey(
                name: "FK_HistoricalStages_Decisions_DecisionId",
                table: "HistoricalStages");

            migrationBuilder.DropForeignKey(
                name: "FK_HistoricalStages_Institutions_IssuingInstitutionId",
                table: "HistoricalStages");

            migrationBuilder.DropForeignKey(
                name: "FK_HistoricalStages_Persons_PersonId",
                table: "HistoricalStages");

            migrationBuilder.DropForeignKey(
                name: "FK_HistoricalStages_Stages_StageId",
                table: "HistoricalStages");

            migrationBuilder.DropForeignKey(
                name: "FK_HistoricalStages_Users_UserDbId",
                table: "HistoricalStages");

            migrationBuilder.DropForeignKey(
                name: "FK_HistoricalStages_Users_UserDbId1",
                table: "HistoricalStages");

            migrationBuilder.DropForeignKey(
                name: "FK_Identifiers_Users_UserDbId",
                table: "Identifiers");

            migrationBuilder.DropForeignKey(
                name: "FK_Identifiers_Users_UserDbId1",
                table: "Identifiers");

            migrationBuilder.DropForeignKey(
                name: "FK_InculpatiDosar_Persons_DefendantId",
                table: "InculpatiDosar");

            migrationBuilder.DropForeignKey(
                name: "FK_InculpatiDosar_Dosare_FileId",
                table: "InculpatiDosar");

            migrationBuilder.DropForeignKey(
                name: "FK_InculpatiDosar_Users_UserDbId",
                table: "InculpatiDosar");

            migrationBuilder.DropForeignKey(
                name: "FK_InculpatiDosar_Users_UserDbId1",
                table: "InculpatiDosar");

            migrationBuilder.DropForeignKey(
                name: "FK_Institutions_Categories_CategoryId",
                table: "Institutions");

            migrationBuilder.DropForeignKey(
                name: "FK_Institutions_Users_UserDbId",
                table: "Institutions");

            migrationBuilder.DropForeignKey(
                name: "FK_Institutions_Users_UserDbId1",
                table: "Institutions");

            migrationBuilder.DropForeignKey(
                name: "FK_NumereDosare_Dosare_FileDbId",
                table: "NumereDosare");

            migrationBuilder.DropForeignKey(
                name: "FK_NumereDosare_Institutions_InstitutionId",
                table: "NumereDosare");

            migrationBuilder.DropForeignKey(
                name: "FK_NumereDosare_Users_UserDbId",
                table: "NumereDosare");

            migrationBuilder.DropForeignKey(
                name: "FK_NumereDosare_Users_UserDbId1",
                table: "NumereDosare");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Addresses_AddressId",
                table: "Persons");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Identifiers_IdentifierId",
                table: "Persons");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Users_UserDbId",
                table: "Persons");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Users_UserDbId1",
                table: "Persons");

            migrationBuilder.DropForeignKey(
                name: "FK_StagesForDecisions_Decisions_DecisionId",
                table: "StagesForDecisions");

            migrationBuilder.DropForeignKey(
                name: "FK_StagesForDecisions_Stages_StageId",
                table: "StagesForDecisions");

            migrationBuilder.DropForeignKey(
                name: "FK_StorageSpaces_Addresses_AddressId",
                table: "StorageSpaces");

            migrationBuilder.DropForeignKey(
                name: "FK_StorageSpaces_Categories_CategoryId",
                table: "StorageSpaces");

            migrationBuilder.DropIndex(
                name: "IX_StagesForDecisions_StageId",
                table: "StagesForDecisions");

            migrationBuilder.DropIndex(
                name: "IX_Persons_UserDbId",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Persons_UserDbId1",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Institutions_UserDbId",
                table: "Institutions");

            migrationBuilder.DropIndex(
                name: "IX_Institutions_UserDbId1",
                table: "Institutions");

            migrationBuilder.DropIndex(
                name: "IX_Identifiers_UserDbId",
                table: "Identifiers");

            migrationBuilder.DropIndex(
                name: "IX_Identifiers_UserDbId1",
                table: "Identifiers");

            migrationBuilder.DropIndex(
                name: "IX_HistoricalStages_DecisionId",
                table: "HistoricalStages");

            migrationBuilder.DropIndex(
                name: "IX_HistoricalStages_IssuingInstitutionId",
                table: "HistoricalStages");

            migrationBuilder.DropIndex(
                name: "IX_HistoricalStages_PersonId",
                table: "HistoricalStages");

            migrationBuilder.DropIndex(
                name: "IX_HistoricalStages_UserDbId",
                table: "HistoricalStages");

            migrationBuilder.DropIndex(
                name: "IX_HistoricalStages_UserDbId1",
                table: "HistoricalStages");

            migrationBuilder.DropIndex(
                name: "IX_Assets_CurrentDecisionId",
                table: "Assets");

            migrationBuilder.DropIndex(
                name: "IX_Assets_UserDbId",
                table: "Assets");

            migrationBuilder.DropIndex(
                name: "IX_Assets_UserDbId1",
                table: "Assets");

            migrationBuilder.DropIndex(
                name: "IX_AssetDefendants_UserDbId",
                table: "AssetDefendants");

            migrationBuilder.DropIndex(
                name: "IX_AssetDefendants_UserDbId1",
                table: "AssetDefendants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NumereDosare",
                table: "NumereDosare");

            migrationBuilder.DropIndex(
                name: "IX_NumereDosare_UserDbId",
                table: "NumereDosare");

            migrationBuilder.DropIndex(
                name: "IX_NumereDosare_UserDbId1",
                table: "NumereDosare");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InculpatiDosar",
                table: "InculpatiDosar");

            migrationBuilder.DropIndex(
                name: "IX_InculpatiDosar_DefendantId",
                table: "InculpatiDosar");

            migrationBuilder.DropIndex(
                name: "IX_InculpatiDosar_UserDbId",
                table: "InculpatiDosar");

            migrationBuilder.DropIndex(
                name: "IX_InculpatiDosar_UserDbId1",
                table: "InculpatiDosar");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Dosare",
                table: "Dosare");

            migrationBuilder.DropIndex(
                name: "IX_Dosare_UserDbId",
                table: "Dosare");

            migrationBuilder.DropIndex(
                name: "IX_Dosare_UserDbId1",
                table: "Dosare");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BunuriDosare",
                table: "BunuriDosare");

            migrationBuilder.DropIndex(
                name: "IX_BunuriDosare_UserDbId",
                table: "BunuriDosare");

            migrationBuilder.DropIndex(
                name: "IX_BunuriDosare_UserDbId1",
                table: "BunuriDosare");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AssetStorageSpaces",
                table: "AssetStorageSpaces");

            migrationBuilder.DropIndex(
                name: "IX_AssetStorageSpaces_UserDbId",
                table: "AssetStorageSpaces");

            migrationBuilder.DropIndex(
                name: "IX_AssetStorageSpaces_UserDbId1",
                table: "AssetStorageSpaces");

            migrationBuilder.DropColumn(
                name: "StorageSpacesType",
                table: "StorageSpaces");

            migrationBuilder.DropColumn(
                name: "AddedDate",
                table: "RecoveryBeneficiaries");

            migrationBuilder.DropColumn(
                name: "LastChangeDate",
                table: "RecoveryBeneficiaries");

            migrationBuilder.DropColumn(
                name: "UserCodeAdd",
                table: "RecoveryBeneficiaries");

            migrationBuilder.DropColumn(
                name: "UserCodeLastChange",
                table: "RecoveryBeneficiaries");

            migrationBuilder.DropColumn(
                name: "UserDbId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "UserDbId1",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "UserDbId",
                table: "Institutions");

            migrationBuilder.DropColumn(
                name: "UserDbId1",
                table: "Institutions");

            migrationBuilder.DropColumn(
                name: "UserDbId",
                table: "Identifiers");

            migrationBuilder.DropColumn(
                name: "UserDbId1",
                table: "Identifiers");

            migrationBuilder.DropColumn(
                name: "DecisionId",
                table: "HistoricalStages");

            migrationBuilder.DropColumn(
                name: "IssuingInstitutionId",
                table: "HistoricalStages");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "HistoricalStages");

            migrationBuilder.DropColumn(
                name: "UserDbId",
                table: "HistoricalStages");

            migrationBuilder.DropColumn(
                name: "UserDbId1",
                table: "HistoricalStages");

            migrationBuilder.DropColumn(
                name: "CurrentDecisionId",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "UserDbId",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "UserDbId1",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "UserDbId",
                table: "AssetDefendants");

            migrationBuilder.DropColumn(
                name: "UserDbId1",
                table: "AssetDefendants");

            migrationBuilder.DropColumn(
                name: "UserDbId",
                table: "NumereDosare");

            migrationBuilder.DropColumn(
                name: "UserDbId1",
                table: "NumereDosare");

            migrationBuilder.DropColumn(
                name: "DefendantId",
                table: "InculpatiDosar");

            migrationBuilder.DropColumn(
                name: "UserDbId",
                table: "InculpatiDosar");

            migrationBuilder.DropColumn(
                name: "UserDbId1",
                table: "InculpatiDosar");

            migrationBuilder.DropColumn(
                name: "UserDbId",
                table: "Dosare");

            migrationBuilder.DropColumn(
                name: "UserDbId1",
                table: "Dosare");

            migrationBuilder.DropColumn(
                name: "UserDbId",
                table: "BunuriDosare");

            migrationBuilder.DropColumn(
                name: "UserDbId1",
                table: "BunuriDosare");

            migrationBuilder.DropColumn(
                name: "UserDbId",
                table: "AssetStorageSpaces");

            migrationBuilder.DropColumn(
                name: "UserDbId1",
                table: "AssetStorageSpaces");

            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "Users",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "StorageSpaces",
                newName: "StorageSpaces",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "StagesForDecisions",
                newName: "StagesForDecisions",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Stages",
                newName: "Stages",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "RecoveryBeneficiaries",
                newName: "RecoveryBeneficiaries",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "PrecautionaryMeasures",
                newName: "PrecautionaryMeasures",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Persons",
                newName: "Persons",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Institutions",
                newName: "Institutions",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Identifiers",
                newName: "Identifiers",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "HistoricalStages",
                newName: "HistoricalStages",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Decisions",
                newName: "Decisions",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "CrimeTypes",
                newName: "CrimeTypes",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Counties",
                newName: "Counties",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Categories",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Assets",
                newName: "Assets",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "AssetDefendants",
                newName: "AssetDefendants",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Addresses",
                newName: "Addresses",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "NumereDosare",
                newName: "FileNumbers",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "InculpatiDosar",
                newName: "DefendantsFiles",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Dosare",
                newName: "Files",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "BunuriDosare",
                newName: "AssetsFiles",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "AssetStorageSpaces",
                newName: "AssetsStorageSpaces",
                newSchema: "dbo");

            migrationBuilder.RenameIndex(
                name: "IX_NumereDosare_InstitutionId",
                schema: "dbo",
                table: "FileNumbers",
                newName: "IX_FileNumbers_InstitutionId");

            migrationBuilder.RenameIndex(
                name: "IX_NumereDosare_FileDbId",
                schema: "dbo",
                table: "FileNumbers",
                newName: "IX_FileNumbers_FileDbId");

            migrationBuilder.RenameIndex(
                name: "IX_InculpatiDosar_FileId",
                schema: "dbo",
                table: "DefendantsFiles",
                newName: "IX_DefendantsFiles_FileId");

            migrationBuilder.RenameIndex(
                name: "IX_Dosare_InitialNumberId",
                schema: "dbo",
                table: "Files",
                newName: "IX_Files_InitialNumberId");

            migrationBuilder.RenameIndex(
                name: "IX_Dosare_CurrentNumberId",
                schema: "dbo",
                table: "Files",
                newName: "IX_Files_CurrentNumberId");

            migrationBuilder.RenameIndex(
                name: "IX_BunuriDosare_FileId",
                schema: "dbo",
                table: "AssetsFiles",
                newName: "IX_AssetsFiles_FileId");

            migrationBuilder.RenameIndex(
                name: "IX_BunuriDosare_AssetId",
                schema: "dbo",
                table: "AssetsFiles",
                newName: "IX_AssetsFiles_AssetId");

            migrationBuilder.RenameIndex(
                name: "IX_AssetStorageSpaces_StorageSpaceId",
                schema: "dbo",
                table: "AssetsStorageSpaces",
                newName: "IX_AssetsStorageSpaces_StorageSpaceId");

            migrationBuilder.RenameIndex(
                name: "IX_AssetStorageSpaces_AssetId",
                schema: "dbo",
                table: "AssetsStorageSpaces",
                newName: "IX_AssetsStorageSpaces_AssetId");

            migrationBuilder.AlterColumn<string>(
                name: "UserCode",
                schema: "dbo",
                table: "Users",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Salt",
                schema: "dbo",
                table: "Users",
                type: "varchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                schema: "dbo",
                table: "Users",
                maxLength: 5000,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                schema: "dbo",
                table: "Users",
                type: "varchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "dbo",
                table: "Users",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                schema: "dbo",
                table: "Users",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "dbo",
                table: "Users",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Width",
                schema: "dbo",
                table: "StorageSpaces",
                type: "Decimal(20, 2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "UndevelopedArea",
                schema: "dbo",
                table: "StorageSpaces",
                type: "Decimal(20, 2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalVolume",
                schema: "dbo",
                table: "StorageSpaces",
                type: "Decimal(20, 2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "dbo",
                table: "StorageSpaces",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "MonthlyMaintenanceCost",
                schema: "dbo",
                table: "StorageSpaces",
                type: "Decimal(20, 2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Length",
                schema: "dbo",
                table: "StorageSpaces",
                type: "Decimal(20, 2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "dbo",
                table: "StorageSpaces",
                maxLength: 2000,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ContactData",
                schema: "dbo",
                table: "StorageSpaces",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                schema: "dbo",
                table: "StorageSpaces",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "AvailableVolume",
                schema: "dbo",
                table: "StorageSpaces",
                type: "Decimal(20, 2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "AsphaltedArea",
                schema: "dbo",
                table: "StorageSpaces",
                type: "Decimal(20, 2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "dbo",
                table: "Stages",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "dbo",
                table: "RecoveryBeneficiaries",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserCodeLastChange",
                schema: "dbo",
                table: "PrecautionaryMeasures",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserCodeAdd",
                schema: "dbo",
                table: "PrecautionaryMeasures",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "dbo",
                table: "Persons",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastChangeDate",
                schema: "dbo",
                table: "Persons",
                type: "Datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Identification",
                schema: "dbo",
                table: "Persons",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IdSerie",
                schema: "dbo",
                table: "Persons",
                maxLength: 2,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IdNumber",
                schema: "dbo",
                table: "Persons",
                maxLength: 6,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AddressId",
                schema: "dbo",
                table: "Persons",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "AddedDate",
                schema: "dbo",
                table: "Persons",
                type: "DateTime",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "dbo",
                table: "Institutions",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastChangeDate",
                schema: "dbo",
                table: "Institutions",
                type: "Datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "AddedDate",
                schema: "dbo",
                table: "Institutions",
                type: "DateTime",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<int>(
                name: "OwnerId",
                schema: "dbo",
                table: "HistoricalStages",
                type: "Int",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LegalBasis",
                schema: "dbo",
                table: "HistoricalStages",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastChangeDate",
                schema: "dbo",
                table: "HistoricalStages",
                type: "Datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "InstitutionId",
                schema: "dbo",
                table: "HistoricalStages",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EstimatedAmountCurrency",
                schema: "dbo",
                table: "HistoricalStages",
                maxLength: 3,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "EstimatedAmount",
                schema: "dbo",
                table: "HistoricalStages",
                type: "Decimal(20,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DecizieId",
                schema: "dbo",
                table: "HistoricalStages",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DecisionNumber",
                schema: "dbo",
                table: "HistoricalStages",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DecisionDate",
                schema: "dbo",
                table: "HistoricalStages",
                type: "Date",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<string>(
                name: "AssetState",
                schema: "dbo",
                table: "HistoricalStages",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "AddedDate",
                schema: "dbo",
                table: "HistoricalStages",
                type: "DateTime",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<string>(
                name: "ActualValueCurrency",
                schema: "dbo",
                table: "HistoricalStages",
                maxLength: 3,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "ActualValue",
                schema: "dbo",
                table: "HistoricalStages",
                type: "Decimal(20, 2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "dbo",
                table: "Decisions",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserCodeLastChange",
                schema: "dbo",
                table: "CrimeTypes",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserCodeAdd",
                schema: "dbo",
                table: "CrimeTypes",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "dbo",
                table: "Counties",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Abreviation",
                schema: "dbo",
                table: "Counties",
                maxLength: 2,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ForEntity",
                schema: "dbo",
                table: "Categories",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "dbo",
                table: "Categories",
                maxLength: 2000,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                schema: "dbo",
                table: "Categories",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "NecessaryVolume",
                schema: "dbo",
                table: "Assets",
                type: "Decimal(20, 2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastChangeDate",
                schema: "dbo",
                table: "Assets",
                type: "Datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Identifier",
                schema: "dbo",
                table: "Assets",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DecisionId",
                schema: "dbo",
                table: "Assets",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AddressId",
                schema: "dbo",
                table: "Assets",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "AddedDate",
                schema: "dbo",
                table: "Assets",
                type: "DateTime",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<string>(
                name: "UserCodeLastChange",
                schema: "dbo",
                table: "Addresses",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserCodeAdd",
                schema: "dbo",
                table: "Addresses",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Street",
                schema: "dbo",
                table: "Addresses",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Stair",
                schema: "dbo",
                table: "Addresses",
                maxLength: 5,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Floor",
                schema: "dbo",
                table: "Addresses",
                maxLength: 5,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FlatNo",
                schema: "dbo",
                table: "Addresses",
                maxLength: 5,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "City",
                schema: "dbo",
                table: "Addresses",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Building",
                schema: "dbo",
                table: "Addresses",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "NumberDate",
                schema: "dbo",
                table: "FileNumbers",
                type: "Datetime",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastChangeDate",
                schema: "dbo",
                table: "FileNumbers",
                type: "Datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FileNumber",
                schema: "dbo",
                table: "FileNumbers",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "AddedDate",
                schema: "dbo",
                table: "FileNumbers",
                type: "DateTime",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastChangeDate",
                schema: "dbo",
                table: "DefendantsFiles",
                type: "Datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "AddedDate",
                schema: "dbo",
                table: "DefendantsFiles",
                type: "DateTime",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<string>(
                name: "LegalClassification",
                schema: "dbo",
                table: "Files",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastChangeDate",
                schema: "dbo",
                table: "Files",
                type: "Datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "InitialFileNumber",
                schema: "dbo",
                table: "Files",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DamageCurrency",
                schema: "dbo",
                table: "Files",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CurrentFileNumber",
                schema: "dbo",
                table: "Files",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CriminalField",
                schema: "dbo",
                table: "Files",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "AddedDate",
                schema: "dbo",
                table: "Files",
                type: "DateTime",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastChangeDate",
                schema: "dbo",
                table: "AssetsFiles",
                type: "Datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "AddedDate",
                schema: "dbo",
                table: "AssetsFiles",
                type: "DateTime",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastChangeDate",
                schema: "dbo",
                table: "AssetsStorageSpaces",
                type: "Datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExitDate",
                schema: "dbo",
                table: "AssetsStorageSpaces",
                type: "Datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "EntryDate",
                schema: "dbo",
                table: "AssetsStorageSpaces",
                type: "DateTime",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "AddedDate",
                schema: "dbo",
                table: "AssetsStorageSpaces",
                type: "DateTime",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Users_UserCode",
                schema: "dbo",
                table: "Users",
                column: "UserCode");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FileNumbers",
                schema: "dbo",
                table: "FileNumbers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DefendantsFiles",
                schema: "dbo",
                table: "DefendantsFiles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Files",
                schema: "dbo",
                table: "Files",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AssetsFiles",
                schema: "dbo",
                table: "AssetsFiles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AssetsStorageSpaces",
                schema: "dbo",
                table: "AssetsStorageSpaces",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                schema: "dbo",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserCode",
                schema: "dbo",
                table: "Users",
                column: "UserCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StorageSpaces_Name",
                schema: "dbo",
                table: "StorageSpaces",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "indx_Stage_Decision",
                schema: "dbo",
                table: "StagesForDecisions",
                columns: new[] { "StageId", "DecisionId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "indx_uq_stagename",
                schema: "dbo",
                table: "Stages",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RecoveryBeneficiaries_Name",
                schema: "dbo",
                table: "RecoveryBeneficiaries",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "indx_uq_Persons",
                schema: "dbo",
                table: "Persons",
                column: "Identification",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Persons_UserCodeAdd",
                schema: "dbo",
                table: "Persons",
                column: "UserCodeAdd");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_UserCodeLastChange",
                schema: "dbo",
                table: "Persons",
                column: "UserCodeLastChange");

            migrationBuilder.CreateIndex(
                name: "IX_Institutions_UserCodeAdd",
                schema: "dbo",
                table: "Institutions",
                column: "UserCodeAdd");

            migrationBuilder.CreateIndex(
                name: "IX_Institutions_UserCodeLastChange",
                schema: "dbo",
                table: "Institutions",
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

            migrationBuilder.CreateIndex(
                name: "IX_HistoricalStages_DecizieId",
                schema: "dbo",
                table: "HistoricalStages",
                column: "DecizieId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricalStages_InstitutionId",
                schema: "dbo",
                table: "HistoricalStages",
                column: "InstitutionId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricalStages_OwnerId",
                schema: "dbo",
                table: "HistoricalStages",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricalStages_UserCodeAdd",
                schema: "dbo",
                table: "HistoricalStages",
                column: "UserCodeAdd");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricalStages_UserCodeLastChange",
                schema: "dbo",
                table: "HistoricalStages",
                column: "UserCodeLastChange");

            migrationBuilder.CreateIndex(
                name: "indx_uq_Decision",
                schema: "dbo",
                table: "Decisions",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Counties_Abreviation",
                schema: "dbo",
                table: "Counties",
                column: "Abreviation",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "indx_code_forentity",
                schema: "dbo",
                table: "Categories",
                columns: new[] { "Code", "ForEntity" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Assets_DecisionId",
                schema: "dbo",
                table: "Assets",
                column: "DecisionId");

            migrationBuilder.CreateIndex(
                name: "IX_Assets_UserCodeAdd",
                schema: "dbo",
                table: "Assets",
                column: "UserCodeAdd");

            migrationBuilder.CreateIndex(
                name: "IX_Assets_UserCodeLastChange",
                schema: "dbo",
                table: "Assets",
                column: "UserCodeLastChange");

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
                name: "IX_FileNumbers_UserCodeAdd",
                schema: "dbo",
                table: "FileNumbers",
                column: "UserCodeAdd");

            migrationBuilder.CreateIndex(
                name: "IX_FileNumbers_UserCodeLastChange",
                schema: "dbo",
                table: "FileNumbers",
                column: "UserCodeLastChange");

            migrationBuilder.CreateIndex(
                name: "IX_DefendantsFiles_UserCodeAdd",
                schema: "dbo",
                table: "DefendantsFiles",
                column: "UserCodeAdd");

            migrationBuilder.CreateIndex(
                name: "IX_DefendantsFiles_UserCodeLastChange",
                schema: "dbo",
                table: "DefendantsFiles",
                column: "UserCodeLastChange");

            migrationBuilder.CreateIndex(
                name: "indx_uq_DefendantsFile",
                schema: "dbo",
                table: "DefendantsFiles",
                columns: new[] { "PersonId", "FileId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Files_UserCodeAdd",
                schema: "dbo",
                table: "Files",
                column: "UserCodeAdd");

            migrationBuilder.CreateIndex(
                name: "IX_Files_UserCodeLastChange",
                schema: "dbo",
                table: "Files",
                column: "UserCodeLastChange");

            migrationBuilder.CreateIndex(
                name: "IX_AssetsFiles_UserCodeAdd",
                schema: "dbo",
                table: "AssetsFiles",
                column: "UserCodeAdd");

            migrationBuilder.CreateIndex(
                name: "IX_AssetsFiles_UserCodeLastChange",
                schema: "dbo",
                table: "AssetsFiles",
                column: "UserCodeLastChange");

            migrationBuilder.CreateIndex(
                name: "IX_AssetsStorageSpaces_UserCodeAdd",
                schema: "dbo",
                table: "AssetsStorageSpaces",
                column: "UserCodeAdd");

            migrationBuilder.CreateIndex(
                name: "IX_AssetsStorageSpaces_UserCodeLastChange",
                schema: "dbo",
                table: "AssetsStorageSpaces",
                column: "UserCodeLastChange");

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
                name: "FK_AssetDefendants_User_Add",
                schema: "dbo",
                table: "AssetDefendants",
                column: "UserCodeAdd",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "UserCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetDefendants_User_Change",
                schema: "dbo",
                table: "AssetDefendants",
                column: "UserCodeLastChange",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "UserCode",
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
                name: "FK_Assets_Files_FileDbId",
                schema: "dbo",
                table: "Assets",
                column: "FileDbId",
                principalSchema: "dbo",
                principalTable: "Files",
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
                name: "FK_FileNumbers_Files_FileDbId",
                schema: "dbo",
                table: "FileNumbers",
                column: "FileDbId",
                principalSchema: "dbo",
                principalTable: "Files",
                principalColumn: "Id",
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
                name: "FK_Files_FileNumbers_CurrentNumberId",
                schema: "dbo",
                table: "Files",
                column: "CurrentNumberId",
                principalSchema: "dbo",
                principalTable: "FileNumbers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Files_FileNumbers_InitialNumberId",
                schema: "dbo",
                table: "Files",
                column: "InitialNumberId",
                principalSchema: "dbo",
                principalTable: "FileNumbers",
                principalColumn: "Id",
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
                name: "FK_Identifiers_User_Add",
                schema: "dbo",
                table: "Identifiers",
                column: "UserCodeAdd",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "UserCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Identifiers_User_Change",
                schema: "dbo",
                table: "Identifiers",
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
                name: "FK_Persons_Identifiers",
                schema: "dbo",
                table: "Persons",
                column: "IdentifierId",
                principalSchema: "dbo",
                principalTable: "Identifiers",
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
                onDelete: ReferentialAction.Restrict);*/
        }
    }
}
