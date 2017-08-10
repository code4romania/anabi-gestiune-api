using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Anabi.DataAccess.Ef;

namespace Anabi.DataAccess.Ef.Migrations
{
    [DbContext(typeof(AnabiContext))]
    [Migration("20170809191649_migration")]
    partial class migration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasDefaultSchema("dbo")
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Anabi.DataAccess.Ef.DbModels.AddressDb", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Building")
                        .HasMaxLength(10);

                    b.Property<string>("City")
                        .HasMaxLength(30);

                    b.Property<int>("CountyId");

                    b.Property<string>("FlatNo")
                        .HasMaxLength(5);

                    b.Property<string>("Floor")
                        .HasMaxLength(5);

                    b.Property<string>("Stair")
                        .HasMaxLength(5);

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("CountyId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("Anabi.DataAccess.Ef.DbModels.AssetDb", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("DateTime");

                    b.Property<int>("AddressId");

                    b.Property<int>("CategoryId");

                    b.Property<int>("CurrentStageId");

                    b.Property<int>("DecisionId");

                    b.Property<int?>("FileDbId");

                    b.Property<string>("Identifier")
                        .HasMaxLength(100);

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("LastChangeDate")
                        .HasColumnType("Datetime");

                    b.Property<decimal?>("NecessaryVolume")
                        .HasColumnType("Decimal(20, 2)");

                    b.Property<string>("UserCodeAdd")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("UserCodeLastChange")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("CurrentStageId");

                    b.HasIndex("DecisionId");

                    b.HasIndex("FileDbId");

                    b.HasIndex("UserCodeAdd");

                    b.HasIndex("UserCodeLastChange");

                    b.ToTable("Assets");
                });

            modelBuilder.Entity("Anabi.DataAccess.Ef.DbModels.AssetsFileDb", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("DateTime");

                    b.Property<int>("AssetId");

                    b.Property<int>("FileId");

                    b.Property<DateTime?>("LastChangeDate")
                        .HasColumnType("Datetime");

                    b.Property<string>("UserCodeAdd")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("UserCodeLastChange")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.HasIndex("AssetId");

                    b.HasIndex("FileId");

                    b.HasIndex("UserCodeAdd");

                    b.HasIndex("UserCodeLastChange");

                    b.ToTable("AssetsFiles");
                });

            modelBuilder.Entity("Anabi.DataAccess.Ef.DbModels.AssetStorageSpaceDb", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("DateTime");

                    b.Property<int>("AssetId");

                    b.Property<DateTime>("EntryDate")
                        .HasColumnType("DateTime");

                    b.Property<DateTime?>("ExitDate")
                        .HasColumnType("Datetime");

                    b.Property<DateTime?>("LastChangeDate")
                        .HasColumnType("Datetime");

                    b.Property<int>("StorageSpaceId");

                    b.Property<string>("UserCodeAdd")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("UserCodeLastChange")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.HasIndex("AssetId");

                    b.HasIndex("StorageSpaceId");

                    b.HasIndex("UserCodeAdd");

                    b.HasIndex("UserCodeLastChange");

                    b.ToTable("AssetsStorageSpaces");
                });

            modelBuilder.Entity("Anabi.DataAccess.Ef.DbModels.CategoryDb", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Description")
                        .HasMaxLength(2000);

                    b.Property<string>("ForEntity")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<int?>("ParentId");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.HasIndex("Code", "ForEntity")
                        .IsUnique()
                        .HasName("indx_code_forentity");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Anabi.DataAccess.Ef.DbModels.CountyDb", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Abreviation")
                        .IsRequired()
                        .HasMaxLength(2);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("Abreviation")
                        .IsUnique();

                    b.ToTable("Counties");
                });

            modelBuilder.Entity("Anabi.DataAccess.Ef.DbModels.DecisionDb", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasName("indx_uq_Decision");

                    b.ToTable("Decisions");
                });

            modelBuilder.Entity("Anabi.DataAccess.Ef.DbModels.DefendantsFileDb", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("DateTime");

                    b.Property<int>("FileId");

                    b.Property<DateTime?>("LastChangeDate")
                        .HasColumnType("Datetime");

                    b.Property<int>("PersonId");

                    b.Property<string>("UserCodeAdd")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("UserCodeLastChange")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.HasIndex("FileId");

                    b.HasIndex("UserCodeAdd");

                    b.HasIndex("UserCodeLastChange");

                    b.HasIndex("PersonId", "FileId")
                        .IsUnique()
                        .HasName("indx_uq_DefendantsFile");

                    b.ToTable("DefendantsFiles");
                });

            modelBuilder.Entity("Anabi.DataAccess.Ef.DbModels.FileDb", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("DateTime");

                    b.Property<string>("CriminalField")
                        .IsRequired();

                    b.Property<string>("CurrentFileNumber")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("CurrentFileNumberId");

                    b.Property<int?>("CurrentNumberId");

                    b.Property<decimal>("DamageAmount");

                    b.Property<string>("DamageCurrency")
                        .IsRequired();

                    b.Property<int>("InitialFileId");

                    b.Property<string>("InitialFileNumber")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int?>("InitialNumberId");

                    b.Property<DateTime?>("LastChangeDate")
                        .HasColumnType("Datetime");

                    b.Property<string>("LegalClassification")
                        .IsRequired();

                    b.Property<string>("UserCodeAdd")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("UserCodeLastChange")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.HasIndex("CurrentNumberId");

                    b.HasIndex("InitialNumberId");

                    b.HasIndex("UserCodeAdd");

                    b.HasIndex("UserCodeLastChange");

                    b.ToTable("Files");
                });

            modelBuilder.Entity("Anabi.DataAccess.Ef.DbModels.FileNumberDb", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("DateTime");

                    b.Property<int?>("FileDbId");

                    b.Property<string>("FileNumber")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("InstitutionId");

                    b.Property<DateTime?>("LastChangeDate")
                        .HasColumnType("Datetime");

                    b.Property<DateTime>("NumberDate")
                        .HasColumnType("Datetime");

                    b.Property<string>("UserCodeAdd")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("UserCodeLastChange")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.HasIndex("FileDbId");

                    b.HasIndex("InstitutionId");

                    b.HasIndex("UserCodeAdd");

                    b.HasIndex("UserCodeLastChange");

                    b.ToTable("FileNumbers");
                });

            modelBuilder.Entity("Anabi.DataAccess.Ef.DbModels.HistoricalStageDb", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal?>("ActualValue")
                        .HasColumnType("Decimal(20, 2)");

                    b.Property<string>("ActualValueCurrency")
                        .IsRequired()
                        .HasMaxLength(3);

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("DateTime");

                    b.Property<int>("AssetId");

                    b.Property<string>("AssetState")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<DateTime>("DecisionDate")
                        .HasColumnType("Date");

                    b.Property<string>("DecisionNumber")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("DecizieId");

                    b.Property<decimal>("EstimatedAmount")
                        .HasColumnType("Decimal(20,2)");

                    b.Property<string>("EstimatedAmountCurrency")
                        .IsRequired()
                        .HasMaxLength(3);

                    b.Property<int>("InstitutionId");

                    b.Property<DateTime?>("LastChangeDate")
                        .HasColumnType("Datetime");

                    b.Property<string>("LegalBasis")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<int?>("OwnerId")
                        .HasColumnType("Int");

                    b.Property<int>("StageId");

                    b.Property<string>("UserCodeAdd")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("UserCodeLastChange")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.HasIndex("AssetId");

                    b.HasIndex("DecizieId");

                    b.HasIndex("InstitutionId");

                    b.HasIndex("OwnerId");

                    b.HasIndex("StageId");

                    b.HasIndex("UserCodeAdd");

                    b.HasIndex("UserCodeLastChange");

                    b.ToTable("HistoricalStages");
                });

            modelBuilder.Entity("Anabi.DataAccess.Ef.DbModels.InstitutionDb", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("DateTime");

                    b.Property<int?>("AddressId");

                    b.Property<int>("CategoryId");

                    b.Property<DateTime?>("LastChangeDate")
                        .HasColumnType("Datetime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("UserCodeAdd")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("UserCodeLastChange")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("UserCodeAdd");

                    b.HasIndex("UserCodeLastChange");

                    b.ToTable("Institutions");
                });

            modelBuilder.Entity("Anabi.DataAccess.Ef.DbModels.PersonDb", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("DateTime");

                    b.Property<int>("AddressId");

                    b.Property<string>("IdNumber")
                        .HasMaxLength(6);

                    b.Property<string>("IdSerie")
                        .HasMaxLength(2);

                    b.Property<string>("Identification")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<bool>("IsPerson");

                    b.Property<DateTime?>("LastChangeDate")
                        .HasColumnType("Datetime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("UserCodeAdd")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("UserCodeLastChange")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("Identification")
                        .IsUnique()
                        .HasName("indx_uq_Persons");

                    b.HasIndex("UserCodeAdd");

                    b.HasIndex("UserCodeLastChange");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("Anabi.DataAccess.Ef.DbModels.RecoveryBeneficiaryDb", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("RecoveryBeneficiaries");
                });

            modelBuilder.Entity("Anabi.DataAccess.Ef.DbModels.StageDb", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsFinal");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasName("indx_uq_stagename");

                    b.ToTable("Stages");
                });

            modelBuilder.Entity("Anabi.DataAccess.Ef.DbModels.StagesForDecisionDb", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DecisionId");

                    b.Property<int>("StageId");

                    b.HasKey("Id");

                    b.HasIndex("DecisionId");

                    b.HasIndex("StageId", "DecisionId")
                        .IsUnique()
                        .HasName("indx_Stage_Decision");

                    b.ToTable("StagesForDecisions");
                });

            modelBuilder.Entity("Anabi.DataAccess.Ef.DbModels.StorageSpaceDb", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AddressId");

                    b.Property<decimal?>("AsphaltedArea")
                        .HasColumnType("Decimal(20, 2)");

                    b.Property<decimal?>("AvailableVolume")
                        .HasColumnType("Decimal(20, 2)");

                    b.Property<int>("CategoryId");

                    b.Property<string>("ContactData")
                        .HasMaxLength(1000);

                    b.Property<string>("Description")
                        .HasMaxLength(2000);

                    b.Property<decimal?>("Length")
                        .HasColumnType("Decimal(20, 2)");

                    b.Property<string>("MaintenanceMentions")
                        .HasColumnType("Decimal(20, 2)");

                    b.Property<decimal?>("MonthlyMaintenanceCost")
                        .HasColumnType("Decimal(20, 2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<decimal?>("TotalVolume")
                        .HasColumnType("Decimal(20, 2)");

                    b.Property<decimal?>("UndevelopedArea")
                        .HasColumnType("Decimal(20, 2)");

                    b.Property<decimal?>("Width")
                        .HasColumnType("Decimal(20, 2)");

                    b.HasKey("Id");

                    b.HasIndex("AddressId")
                        .IsUnique();

                    b.HasIndex("CategoryId")
                        .IsUnique();

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("StorageSpaces");
                });

            modelBuilder.Entity("Anabi.DataAccess.Ef.DbModels.UserDb", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(true);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(5000);

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasColumnType("varchar(max)");

                    b.Property<string>("UserCode")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("UserCode")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Anabi.DataAccess.Ef.DbModels.AddressDb", b =>
                {
                    b.HasOne("Anabi.DataAccess.Ef.DbModels.CountyDb", "County")
                        .WithMany("Addresses")
                        .HasForeignKey("CountyId")
                        .HasConstraintName("FK_Addresses_Counties");
                });

            modelBuilder.Entity("Anabi.DataAccess.Ef.DbModels.AssetDb", b =>
                {
                    b.HasOne("Anabi.DataAccess.Ef.DbModels.AddressDb", "Address")
                        .WithMany("Assets")
                        .HasForeignKey("AddressId")
                        .HasConstraintName("FK_Assets_Addresses");

                    b.HasOne("Anabi.DataAccess.Ef.DbModels.CategoryDb", "Category")
                        .WithMany("Assets")
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("FK_Assets_Categories");

                    b.HasOne("Anabi.DataAccess.Ef.DbModels.StageDb", "CurrentStage")
                        .WithMany("Assets")
                        .HasForeignKey("CurrentStageId")
                        .HasConstraintName("FK_Assets_Stages");

                    b.HasOne("Anabi.DataAccess.Ef.DbModels.DecisionDb", "CurrentDecision")
                        .WithMany("Assets")
                        .HasForeignKey("DecisionId")
                        .HasConstraintName("FK_Assets_Decisions");

                    b.HasOne("Anabi.DataAccess.Ef.DbModels.FileDb")
                        .WithMany("Assets")
                        .HasForeignKey("FileDbId");

                    b.HasOne("Anabi.DataAccess.Ef.DbModels.UserDb", "UserAdd")
                        .WithMany("AssetsAdded")
                        .HasForeignKey("UserCodeAdd")
                        .HasPrincipalKey("UserCode");

                    b.HasOne("Anabi.DataAccess.Ef.DbModels.UserDb", "UserLastChange")
                        .WithMany("AssetsChanged")
                        .HasForeignKey("UserCodeLastChange")
                        .HasPrincipalKey("UserCode");
                });

            modelBuilder.Entity("Anabi.DataAccess.Ef.DbModels.AssetsFileDb", b =>
                {
                    b.HasOne("Anabi.DataAccess.Ef.DbModels.AssetDb", "Asset")
                        .WithMany("FilesForAsset")
                        .HasForeignKey("AssetId")
                        .HasConstraintName("FK_AssetsFiles_Assets");

                    b.HasOne("Anabi.DataAccess.Ef.DbModels.FileDb", "File")
                        .WithMany("AssetsFile")
                        .HasForeignKey("FileId")
                        .HasConstraintName("FK_AssetsFiles_Files");

                    b.HasOne("Anabi.DataAccess.Ef.DbModels.UserDb", "UserAdd")
                        .WithMany("AssetsFileAdded")
                        .HasForeignKey("UserCodeAdd")
                        .HasPrincipalKey("UserCode");

                    b.HasOne("Anabi.DataAccess.Ef.DbModels.UserDb", "UserLastChange")
                        .WithMany("AssetsFileChange")
                        .HasForeignKey("UserCodeLastChange")
                        .HasPrincipalKey("UserCode");
                });

            modelBuilder.Entity("Anabi.DataAccess.Ef.DbModels.AssetStorageSpaceDb", b =>
                {
                    b.HasOne("Anabi.DataAccess.Ef.DbModels.AssetDb", "Asset")
                        .WithMany("AssetsStorageSpaces")
                        .HasForeignKey("AssetId")
                        .HasConstraintName("FK_AssetsStorageSpaces_Assets");

                    b.HasOne("Anabi.DataAccess.Ef.DbModels.StorageSpaceDb", "StorageSpace")
                        .WithMany("AssetsStorageSpaces")
                        .HasForeignKey("StorageSpaceId")
                        .HasConstraintName("FK_AssetsStorageSpaces_StorageSpaces");

                    b.HasOne("Anabi.DataAccess.Ef.DbModels.UserDb", "UserAdd")
                        .WithMany("AssetsStorageSpacesAdded")
                        .HasForeignKey("UserCodeAdd")
                        .HasPrincipalKey("UserCode");

                    b.HasOne("Anabi.DataAccess.Ef.DbModels.UserDb", "UserLastChange")
                        .WithMany("AssetsStorageSpacesChanged")
                        .HasForeignKey("UserCodeLastChange")
                        .HasPrincipalKey("UserCode");
                });

            modelBuilder.Entity("Anabi.DataAccess.Ef.DbModels.CategoryDb", b =>
                {
                    b.HasOne("Anabi.DataAccess.Ef.DbModels.CategoryDb", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId")
                        .HasConstraintName("FK_Categories_Parent");
                });

            modelBuilder.Entity("Anabi.DataAccess.Ef.DbModels.DefendantsFileDb", b =>
                {
                    b.HasOne("Anabi.DataAccess.Ef.DbModels.FileDb", "File")
                        .WithMany("Defendants")
                        .HasForeignKey("FileId")
                        .HasConstraintName("FK_DefendantsFile_Dosare");

                    b.HasOne("Anabi.DataAccess.Ef.DbModels.PersonDb", "Defendant")
                        .WithMany("Files")
                        .HasForeignKey("PersonId")
                        .HasConstraintName("FK_DefendantsFile_Persoane");

                    b.HasOne("Anabi.DataAccess.Ef.DbModels.UserDb", "UserAdd")
                        .WithMany("DefendantFilesAdded")
                        .HasForeignKey("UserCodeAdd")
                        .HasPrincipalKey("UserCode");

                    b.HasOne("Anabi.DataAccess.Ef.DbModels.UserDb", "UserLastChange")
                        .WithMany("DefendantFilesChanged")
                        .HasForeignKey("UserCodeLastChange")
                        .HasPrincipalKey("UserCode");
                });

            modelBuilder.Entity("Anabi.DataAccess.Ef.DbModels.FileDb", b =>
                {
                    b.HasOne("Anabi.DataAccess.Ef.DbModels.FileNumberDb", "CurrentNumber")
                        .WithMany()
                        .HasForeignKey("CurrentNumberId");

                    b.HasOne("Anabi.DataAccess.Ef.DbModels.FileNumberDb", "InitialNumber")
                        .WithMany()
                        .HasForeignKey("InitialNumberId");

                    b.HasOne("Anabi.DataAccess.Ef.DbModels.UserDb", "UserAdd")
                        .WithMany("FilesAdded")
                        .HasForeignKey("UserCodeAdd")
                        .HasPrincipalKey("UserCode");

                    b.HasOne("Anabi.DataAccess.Ef.DbModels.UserDb", "UserLastChange")
                        .WithMany("FilesChanged")
                        .HasForeignKey("UserCodeLastChange")
                        .HasPrincipalKey("UserCode");
                });

            modelBuilder.Entity("Anabi.DataAccess.Ef.DbModels.FileNumberDb", b =>
                {
                    b.HasOne("Anabi.DataAccess.Ef.DbModels.FileDb")
                        .WithMany("Numbers")
                        .HasForeignKey("FileDbId");

                    b.HasOne("Anabi.DataAccess.Ef.DbModels.InstitutionDb", "Institution")
                        .WithMany("FileNumbers")
                        .HasForeignKey("InstitutionId")
                        .HasConstraintName("FK_NumereDosare_Institutii");

                    b.HasOne("Anabi.DataAccess.Ef.DbModels.UserDb", "UserAdd")
                        .WithMany("FilesNumbersAdded")
                        .HasForeignKey("UserCodeAdd")
                        .HasPrincipalKey("UserCode");

                    b.HasOne("Anabi.DataAccess.Ef.DbModels.UserDb", "UserLastChange")
                        .WithMany("FilesNumbersChanged")
                        .HasForeignKey("UserCodeLastChange")
                        .HasPrincipalKey("UserCode");
                });

            modelBuilder.Entity("Anabi.DataAccess.Ef.DbModels.HistoricalStageDb", b =>
                {
                    b.HasOne("Anabi.DataAccess.Ef.DbModels.AssetDb", "Asset")
                        .WithMany("HistoricalStages")
                        .HasForeignKey("AssetId")
                        .HasConstraintName("FK_HistoricalStages_Assets");

                    b.HasOne("Anabi.DataAccess.Ef.DbModels.DecisionDb", "Decision")
                        .WithMany("HistoricalStages")
                        .HasForeignKey("DecizieId")
                        .HasConstraintName("FK_HistoricalStages_Decisions");

                    b.HasOne("Anabi.DataAccess.Ef.DbModels.InstitutionDb", "IssuingInstitution")
                        .WithMany("HistoricalStages")
                        .HasForeignKey("InstitutionId")
                        .HasConstraintName("FK_HistoricalStages_Institutions");

                    b.HasOne("Anabi.DataAccess.Ef.DbModels.PersonDb", "Person")
                        .WithMany("HistoricalStages")
                        .HasForeignKey("OwnerId")
                        .HasConstraintName("FK_OwnerId");

                    b.HasOne("Anabi.DataAccess.Ef.DbModels.StageDb", "Stage")
                        .WithMany("HistoricalStages")
                        .HasForeignKey("StageId")
                        .HasConstraintName("FK_HistoricalStages_Stages");

                    b.HasOne("Anabi.DataAccess.Ef.DbModels.UserDb", "UserAdd")
                        .WithMany("HistoricalStagesAdded")
                        .HasForeignKey("UserCodeAdd")
                        .HasPrincipalKey("UserCode");

                    b.HasOne("Anabi.DataAccess.Ef.DbModels.UserDb", "UserLastChange")
                        .WithMany("HistoricalStagesChanged")
                        .HasForeignKey("UserCodeLastChange")
                        .HasPrincipalKey("UserCode");
                });

            modelBuilder.Entity("Anabi.DataAccess.Ef.DbModels.InstitutionDb", b =>
                {
                    b.HasOne("Anabi.DataAccess.Ef.DbModels.AddressDb", "Address")
                        .WithMany("Institutions")
                        .HasForeignKey("AddressId");

                    b.HasOne("Anabi.DataAccess.Ef.DbModels.CategoryDb", "Category")
                        .WithMany("Institutions")
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("FK_Institutions_Categories");

                    b.HasOne("Anabi.DataAccess.Ef.DbModels.UserDb", "UserAdd")
                        .WithMany("InstitutionsAdded")
                        .HasForeignKey("UserCodeAdd")
                        .HasPrincipalKey("UserCode");

                    b.HasOne("Anabi.DataAccess.Ef.DbModels.UserDb", "UserLastChange")
                        .WithMany("InstitutionsChanged")
                        .HasForeignKey("UserCodeLastChange")
                        .HasPrincipalKey("UserCode");
                });

            modelBuilder.Entity("Anabi.DataAccess.Ef.DbModels.PersonDb", b =>
                {
                    b.HasOne("Anabi.DataAccess.Ef.DbModels.AddressDb", "Address")
                        .WithMany("Persons")
                        .HasForeignKey("AddressId")
                        .HasConstraintName("FK_Persons_Addresses");

                    b.HasOne("Anabi.DataAccess.Ef.DbModels.UserDb", "UserAdd")
                        .WithMany("PersonsAdded")
                        .HasForeignKey("UserCodeAdd")
                        .HasPrincipalKey("UserCode");

                    b.HasOne("Anabi.DataAccess.Ef.DbModels.UserDb", "UserLastChange")
                        .WithMany("PersonsChanged")
                        .HasForeignKey("UserCodeLastChange")
                        .HasPrincipalKey("UserCode");
                });

            modelBuilder.Entity("Anabi.DataAccess.Ef.DbModels.StagesForDecisionDb", b =>
                {
                    b.HasOne("Anabi.DataAccess.Ef.DbModels.DecisionDb", "Decision")
                        .WithMany("PossibleStages")
                        .HasForeignKey("DecisionId")
                        .HasConstraintName("FK_StagesForDecision_Decision");

                    b.HasOne("Anabi.DataAccess.Ef.DbModels.StageDb", "Stage")
                        .WithMany("PossibleDecisions")
                        .HasForeignKey("StageId")
                        .HasConstraintName("FK_StagesForDecision_Stage");
                });

            modelBuilder.Entity("Anabi.DataAccess.Ef.DbModels.StorageSpaceDb", b =>
                {
                    b.HasOne("Anabi.DataAccess.Ef.DbModels.AddressDb", "Address")
                        .WithOne("StorageRoom")
                        .HasForeignKey("Anabi.DataAccess.Ef.DbModels.StorageSpaceDb", "AddressId")
                        .HasConstraintName("FK_StorageSpaces_Addresses");

                    b.HasOne("Anabi.DataAccess.Ef.DbModels.CategoryDb", "Category")
                        .WithOne("StorageSpace")
                        .HasForeignKey("Anabi.DataAccess.Ef.DbModels.StorageSpaceDb", "CategoryId")
                        .HasConstraintName("FK_StorageSpaces_Category");
                });
        }
    }
}
