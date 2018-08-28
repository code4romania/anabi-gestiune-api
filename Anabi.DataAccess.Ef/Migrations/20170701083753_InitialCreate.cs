using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Anabi.DataAccess.Ef.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Categories",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 2000, nullable: true),
                    ForEntity = table.Column<string>(maxLength: 20, nullable: false),
                    ParentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Parent",
                        column: x => x.ParentId,
                        principalSchema: "dbo",
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Counties",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Abreviation = table.Column<string>(maxLength: 2, nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Counties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Decisions",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Decisions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stages",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsFinal = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(nullable: false, defaultValue: true),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "varchar(max)", nullable: false),
                    Role = table.Column<string>(maxLength: 5000, nullable: false),
                    Salt = table.Column<string>(type: "varchar(max)", nullable: false),
                    UserCode = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.UniqueConstraint("AK_Users_UserCode", x => x.UserCode);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Building = table.Column<string>(maxLength: 10, nullable: true),
                    City = table.Column<string>(maxLength: 30, nullable: true),
                    CountyId = table.Column<int>(nullable: false),
                    FlatNo = table.Column<string>(maxLength: 5, nullable: true),
                    Floor = table.Column<string>(maxLength: 5, nullable: true),
                    Stair = table.Column<string>(maxLength: 5, nullable: true),
                    Street = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Counties",
                        column: x => x.CountyId,
                        principalSchema: "dbo",
                        principalTable: "Counties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StagesForDecisions",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DecisionId = table.Column<int>(nullable: false),
                    StageId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StagesForDecisions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StagesForDecision_Decision",
                        column: x => x.DecisionId,
                        principalSchema: "dbo",
                        principalTable: "Decisions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StagesForDecision_Stage",
                        column: x => x.StageId,
                        principalSchema: "dbo",
                        principalTable: "Stages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Institutions",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddedDate = table.Column<DateTime>(type: "DateTime", nullable: false),
                    AddressId = table.Column<int>(nullable: true),
                    CategoryId = table.Column<int>(nullable: false),
                    LastChangeDate = table.Column<DateTime>(type: "Datetime", nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    UserCodeAdd = table.Column<string>(maxLength: 20, nullable: false),
                    UserCodeLastChange = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Institutions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Institutions_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalSchema: "dbo",
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Institutions_Categories",
                        column: x => x.CategoryId,
                        principalSchema: "dbo",
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Institutions_Users_UserCodeAdd",
                        column: x => x.UserCodeAdd,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "UserCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Institutions_Users_UserCodeLastChange",
                        column: x => x.UserCodeLastChange,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "UserCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddedDate = table.Column<DateTime>(type: "DateTime", nullable: false),
                    AddressId = table.Column<int>(nullable: false),
                    IdNumber = table.Column<string>(maxLength: 6, nullable: true),
                    IdSerie = table.Column<string>(maxLength: 2, nullable: true),
                    Identification = table.Column<string>(maxLength: 20, nullable: false),
                    IsPerson = table.Column<bool>(nullable: false),
                    LastChangeDate = table.Column<DateTime>(type: "Datetime", nullable: true),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    UserCodeAdd = table.Column<string>(maxLength: 20, nullable: false),
                    UserCodeLastChange = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Persons_Addresses",
                        column: x => x.AddressId,
                        principalSchema: "dbo",
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Persons_Users_UserCodeAdd",
                        column: x => x.UserCodeAdd,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "UserCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Persons_Users_UserCodeLastChange",
                        column: x => x.UserCodeLastChange,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "UserCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StorageSpaces",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddressId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StorageSpaces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StorageSpaces_Addresses",
                        column: x => x.AddressId,
                        principalSchema: "dbo",
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Assets",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddedDate = table.Column<DateTime>(type: "DateTime", nullable: false),
                    AddressId = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    CurrentStageId = table.Column<int>(nullable: false),
                    DecisionId = table.Column<int>(nullable: false),
                    FileDbId = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastChangeDate = table.Column<DateTime>(type: "Datetime", nullable: true),
                    UserCodeAdd = table.Column<string>(maxLength: 20, nullable: false),
                    UserCodeLastChange = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assets_Addresses",
                        column: x => x.AddressId,
                        principalSchema: "dbo",
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Assets_Categories",
                        column: x => x.CategoryId,
                        principalSchema: "dbo",
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Assets_Stages",
                        column: x => x.CurrentStageId,
                        principalSchema: "dbo",
                        principalTable: "Stages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Assets_Decisions",
                        column: x => x.DecisionId,
                        principalSchema: "dbo",
                        principalTable: "Decisions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Assets_Users_UserCodeAdd",
                        column: x => x.UserCodeAdd,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "UserCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Assets_Users_UserCodeLastChange",
                        column: x => x.UserCodeLastChange,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "UserCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AssetsStorageSpaces",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddedDate = table.Column<DateTime>(type: "DateTime", nullable: false),
                    AssetId = table.Column<int>(nullable: false),
                    EntryDate = table.Column<DateTime>(type: "DateTime", nullable: false),
                    ExitDate = table.Column<DateTime>(type: "Datetime", nullable: true),
                    LastChangeDate = table.Column<DateTime>(type: "Datetime", nullable: true),
                    StorageSpaceId = table.Column<int>(nullable: false),
                    UserCodeAdd = table.Column<string>(maxLength: 20, nullable: false),
                    UserCodeLastChange = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetsStorageSpaces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssetsStorageSpaces_Assets",
                        column: x => x.AssetId,
                        principalSchema: "dbo",
                        principalTable: "Assets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AssetsStorageSpaces_StorageSpaces",
                        column: x => x.StorageSpaceId,
                        principalSchema: "dbo",
                        principalTable: "StorageSpaces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AssetsStorageSpaces_Users_UserCodeAdd",
                        column: x => x.UserCodeAdd,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "UserCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AssetsStorageSpaces_Users_UserCodeLastChange",
                        column: x => x.UserCodeLastChange,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "UserCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HistoricalStages",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddedDate = table.Column<DateTime>(type: "DateTime", nullable: false),
                    AssetId = table.Column<int>(nullable: false),
                    DecisionDate = table.Column<DateTime>(type: "Date", nullable: false),
                    DecisionNumber = table.Column<string>(maxLength: 50, nullable: false),
                    DecizieId = table.Column<int>(nullable: false),
                    EstimatedAmount = table.Column<decimal>(type: "Decimal(20,2)", nullable: false),
                    EstimatedAmountCurrency = table.Column<string>(maxLength: 3, nullable: false),
                    InstitutionId = table.Column<int>(nullable: false),
                    LastChangeDate = table.Column<DateTime>(type: "Datetime", nullable: true),
                    LegalBasis = table.Column<string>(maxLength: 200, nullable: false),
                    StageId = table.Column<int>(nullable: false),
                    UserCodeAdd = table.Column<string>(maxLength: 20, nullable: false),
                    UserCodeLastChange = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricalStages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistoricalStages_Assets",
                        column: x => x.AssetId,
                        principalSchema: "dbo",
                        principalTable: "Assets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HistoricalStages_Decisions",
                        column: x => x.DecizieId,
                        principalSchema: "dbo",
                        principalTable: "Decisions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HistoricalStages_Institutions",
                        column: x => x.InstitutionId,
                        principalSchema: "dbo",
                        principalTable: "Institutions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HistoricalStages_Stages",
                        column: x => x.StageId,
                        principalSchema: "dbo",
                        principalTable: "Stages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HistoricalStages_Users_UserCodeAdd",
                        column: x => x.UserCodeAdd,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "UserCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HistoricalStages_Users_UserCodeLastChange",
                        column: x => x.UserCodeLastChange,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "UserCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AssetsFiles",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddedDate = table.Column<DateTime>(type: "DateTime", nullable: false),
                    AssetId = table.Column<int>(nullable: false),
                    FileId = table.Column<int>(nullable: false),
                    LastChangeDate = table.Column<DateTime>(type: "Datetime", nullable: true),
                    UserCodeAdd = table.Column<string>(maxLength: 20, nullable: false),
                    UserCodeLastChange = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetsFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssetsFiles_Assets",
                        column: x => x.AssetId,
                        principalSchema: "dbo",
                        principalTable: "Assets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AssetsFiles_Users_UserCodeAdd",
                        column: x => x.UserCodeAdd,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "UserCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AssetsFiles_Users_UserCodeLastChange",
                        column: x => x.UserCodeLastChange,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "UserCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DefendantsFiles",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddedDate = table.Column<DateTime>(type: "DateTime", nullable: false),
                    FileId = table.Column<int>(nullable: false),
                    LastChangeDate = table.Column<DateTime>(type: "Datetime", nullable: true),
                    PersonId = table.Column<int>(nullable: false),
                    UserCodeAdd = table.Column<string>(maxLength: 20, nullable: false),
                    UserCodeLastChange = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DefendantsFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DefendantsFile_Persoane",
                        column: x => x.PersonId,
                        principalSchema: "dbo",
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DefendantsFiles_Users_UserCodeAdd",
                        column: x => x.UserCodeAdd,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "UserCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DefendantsFiles_Users_UserCodeLastChange",
                        column: x => x.UserCodeLastChange,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "UserCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FileNumbers",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddedDate = table.Column<DateTime>(type: "DateTime", nullable: false),
                    FileDbId = table.Column<int>(nullable: true),
                    FileNumber = table.Column<string>(maxLength: 50, nullable: false),
                    InstitutionId = table.Column<int>(nullable: false),
                    LastChangeDate = table.Column<DateTime>(type: "Datetime", nullable: true),
                    NumberDate = table.Column<DateTime>(type: "Datetime", nullable: false),
                    UserCodeAdd = table.Column<string>(maxLength: 20, nullable: false),
                    UserCodeLastChange = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileNumbers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NumereDosare_Institutii",
                        column: x => x.InstitutionId,
                        principalSchema: "dbo",
                        principalTable: "Institutions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FileNumbers_Users_UserCodeAdd",
                        column: x => x.UserCodeAdd,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "UserCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FileNumbers_Users_UserCodeLastChange",
                        column: x => x.UserCodeLastChange,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "UserCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Files",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddedDate = table.Column<DateTime>(type: "DateTime", nullable: false),
                    CriminalField = table.Column<string>(nullable: false),
                    CurrentFileNumber = table.Column<string>(maxLength: 50, nullable: false),
                    CurrentFileNumberId = table.Column<int>(nullable: false),
                    CurrentNumberId = table.Column<int>(nullable: true),
                    DamageAmount = table.Column<decimal>(nullable: false),
                    DamageCurrency = table.Column<string>(nullable: false),
                    InitialFileId = table.Column<int>(nullable: false),
                    InitialFileNumber = table.Column<string>(maxLength: 50, nullable: false),
                    InitialNumberId = table.Column<int>(nullable: true),
                    LastChangeDate = table.Column<DateTime>(type: "Datetime", nullable: true),
                    LegalClassification = table.Column<string>(nullable: false),
                    UserCodeAdd = table.Column<string>(maxLength: 20, nullable: false),
                    UserCodeLastChange = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Files_FileNumbers_CurrentNumberId",
                        column: x => x.CurrentNumberId,
                        principalSchema: "dbo",
                        principalTable: "FileNumbers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Files_FileNumbers_InitialNumberId",
                        column: x => x.InitialNumberId,
                        principalSchema: "dbo",
                        principalTable: "FileNumbers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Files_Users_UserCodeAdd",
                        column: x => x.UserCodeAdd,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "UserCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Files_Users_UserCodeLastChange",
                        column: x => x.UserCodeLastChange,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "UserCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CountyId",
                schema: "dbo",
                table: "Addresses",
                column: "CountyId");

            migrationBuilder.CreateIndex(
                name: "IX_Assets_AddressId",
                schema: "dbo",
                table: "Assets",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Assets_CategoryId",
                schema: "dbo",
                table: "Assets",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Assets_CurrentStageId",
                schema: "dbo",
                table: "Assets",
                column: "CurrentStageId");

            migrationBuilder.CreateIndex(
                name: "IX_Assets_DecisionId",
                schema: "dbo",
                table: "Assets",
                column: "DecisionId");

            migrationBuilder.CreateIndex(
                name: "IX_Assets_FileDbId",
                schema: "dbo",
                table: "Assets",
                column: "FileDbId");

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
                name: "IX_AssetsFiles_AssetId",
                schema: "dbo",
                table: "AssetsFiles",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetsFiles_FileId",
                schema: "dbo",
                table: "AssetsFiles",
                column: "FileId");

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
                name: "IX_AssetsStorageSpaces_AssetId",
                schema: "dbo",
                table: "AssetsStorageSpaces",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetsStorageSpaces_StorageSpaceId",
                schema: "dbo",
                table: "AssetsStorageSpaces",
                column: "StorageSpaceId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ParentId",
                schema: "dbo",
                table: "Categories",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "indx_code_forentity",
                schema: "dbo",
                table: "Categories",
                columns: new[] { "Code", "ForEntity" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Counties_Abreviation",
                schema: "dbo",
                table: "Counties",
                column: "Abreviation",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "indx_uq_Decision",
                schema: "dbo",
                table: "Decisions",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DefendantsFiles_FileId",
                schema: "dbo",
                table: "DefendantsFiles",
                column: "FileId");

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
                name: "IX_Files_CurrentNumberId",
                schema: "dbo",
                table: "Files",
                column: "CurrentNumberId");

            migrationBuilder.CreateIndex(
                name: "IX_Files_InitialNumberId",
                schema: "dbo",
                table: "Files",
                column: "InitialNumberId");

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
                name: "IX_FileNumbers_FileDbId",
                schema: "dbo",
                table: "FileNumbers",
                column: "FileDbId");

            migrationBuilder.CreateIndex(
                name: "IX_FileNumbers_InstitutionId",
                schema: "dbo",
                table: "FileNumbers",
                column: "InstitutionId");

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
                name: "IX_HistoricalStages_AssetId",
                schema: "dbo",
                table: "HistoricalStages",
                column: "AssetId");

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
                name: "IX_HistoricalStages_StageId",
                schema: "dbo",
                table: "HistoricalStages",
                column: "StageId");

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
                name: "IX_Institutions_AddressId",
                schema: "dbo",
                table: "Institutions",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Institutions_CategoryId",
                schema: "dbo",
                table: "Institutions",
                column: "CategoryId");

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
                name: "IX_Persons_AddressId",
                schema: "dbo",
                table: "Persons",
                column: "AddressId");

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
                name: "indx_uq_stagename",
                schema: "dbo",
                table: "Stages",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StagesForDecisions_DecisionId",
                schema: "dbo",
                table: "StagesForDecisions",
                column: "DecisionId");

            migrationBuilder.CreateIndex(
                name: "indx_Stage_Decision",
                schema: "dbo",
                table: "StagesForDecisions",
                columns: new[] { "StageId", "DecisionId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StorageSpaces_AddressId",
                schema: "dbo",
                table: "StorageSpaces",
                column: "AddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StorageSpaces_Name",
                schema: "dbo",
                table: "StorageSpaces",
                column: "Name",
                unique: true);

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
                name: "FK_AssetsFiles_Files",
                schema: "dbo",
                table: "AssetsFiles",
                column: "FileId",
                principalSchema: "dbo",
                principalTable: "Files",
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
                name: "FK_FileNumbers_Files_FileDbId",
                schema: "dbo",
                table: "FileNumbers",
                column: "FileDbId",
                principalSchema: "dbo",
                principalTable: "Files",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
                
                //add default user
                migrationBuilder.Sql("insert Users(Email, IsActive, Name, [Password], Role, Salt, UserCode) values ('admin@admin.com', 1, 'Admin', '$2a$10$McB4.Yuu8zeBaKvd8bHgU.zvg2aXM9l0Gj.gN6hi4xiFv4DsJyPQq', 'Admin', 'sarea', 'admin')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Counties",
                schema: "dbo",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Institutions_Addresses_AddressId",
                schema: "dbo",
                table: "Institutions");

            migrationBuilder.DropForeignKey(
                name: "FK_Institutions_Categories",
                schema: "dbo",
                table: "Institutions");

            migrationBuilder.DropForeignKey(
                name: "FK_FileNumbers_Files_FileDbId",
                schema: "dbo",
                table: "FileNumbers");

            migrationBuilder.DropTable(
                name: "AssetsFiles",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AssetsStorageSpaces",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "DefendantsFiles",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "HistoricalStages",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "StagesForDecisions",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "StorageSpaces",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Persons",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Assets",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Stages",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Decisions",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Counties",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Addresses",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Categories",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Files",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "FileNumbers",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Institutions",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "dbo");
        }
    }
}
