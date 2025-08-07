using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class IntialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BreedGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BreedGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompetitionLevels",
                columns: table => new
                {
                    LevelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MinHorseAge = table.Column<int>(type: "int", nullable: false),
                    MinPointRequirement = table.Column<int>(type: "int", nullable: false),
                    PointType = table.Column<int>(type: "int", nullable: false),
                    EntryFee = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompetitionLevels", x => x.LevelId);
                });

            migrationBuilder.CreateTable(
                name: "CompetitionTypes",
                columns: table => new
                {
                    TypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegistrationFee = table.Column<int>(type: "int", nullable: false),
                    RequiredPointType = table.Column<int>(type: "int", nullable: false),
                    RecoveryRequired = table.Column<int>(type: "int", nullable: false),
                    RequiredPoints = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompetitionTypes", x => x.TypeId);
                });

            migrationBuilder.CreateTable(
                name: "DisciplineGroups",
                columns: table => new
                {
                    DisciplineGroupId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AllowedGroundTypes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsIndoorDiscipline = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisciplineGroups", x => x.DisciplineGroupId);
                });

            migrationBuilder.CreateTable(
                name: "EquineEstates",
                columns: table => new
                {
                    EquineEstateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HorseAmount = table.Column<int>(type: "int", nullable: false),
                    CurrentBalance = table.Column<int>(type: "int", nullable: false),
                    ProfileEdit = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquineEstates", x => x.EquineEstateId);
                });

            migrationBuilder.CreateTable(
                name: "HorseArtistSApprovals",
                columns: table => new
                {
                    SubmissionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GuidUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PortfolioLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdditionalInfo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    MaturityStage = table.Column<int>(type: "int", nullable: false),
                    SubmittedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HorseArtistSApprovals", x => x.SubmissionId);
                });

            migrationBuilder.CreateTable(
                name: "HorsePurposeStats",
                columns: table => new
                {
                    PurposeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurposeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PurposeType = table.Column<int>(type: "int", nullable: false),
                    BaseStatInheritanceMultiplier = table.Column<double>(type: "float", nullable: false),
                    TrainingPointInheritanceMultiplier = table.Column<double>(type: "float", nullable: false),
                    MaxFoals = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HorsePurposeStats", x => x.PurposeId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "SaleEventTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Season = table.Column<int>(type: "int", nullable: false),
                    IsInviteOnly = table.Column<bool>(type: "bit", nullable: false),
                    RequiresApproval = table.Column<bool>(type: "bit", nullable: false),
                    ConditionIdentifiers = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleEventTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Seasons",
                columns: table => new
                {
                    SeasonsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    SeasonType = table.Column<int>(type: "int", nullable: false),
                    PossibleWeathers = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seasons", x => x.SeasonsId);
                });

            migrationBuilder.CreateTable(
                name: "TestEntities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestEntities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vendors",
                columns: table => new
                {
                    VendorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendors", x => x.VendorId);
                });

            migrationBuilder.CreateTable(
                name: "Venues",
                columns: table => new
                {
                    VenueId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VenueName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArenaType = table.Column<int>(type: "int", nullable: false),
                    GroundType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venues", x => x.VenueId);
                });

            migrationBuilder.CreateTable(
                name: "CrossGroups",
                columns: table => new
                {
                    CrossGroupId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BreedGroupId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrossGroups", x => x.CrossGroupId);
                    table.ForeignKey(
                        name: "FK_CrossGroups_BreedGroups_BreedGroupId",
                        column: x => x.BreedGroupId,
                        principalTable: "BreedGroups",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CompetitionLevelCompetitionType",
                columns: table => new
                {
                    AllowedLevelsLevelId = table.Column<int>(type: "int", nullable: false),
                    AllowedTypesTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompetitionLevelCompetitionType", x => new { x.AllowedLevelsLevelId, x.AllowedTypesTypeId });
                    table.ForeignKey(
                        name: "FK_CompetitionLevelCompetitionType_CompetitionLevels_AllowedLevelsLevelId",
                        column: x => x.AllowedLevelsLevelId,
                        principalTable: "CompetitionLevels",
                        principalColumn: "LevelId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompetitionLevelCompetitionType_CompetitionTypes_AllowedTypesTypeId",
                        column: x => x.AllowedTypesTypeId,
                        principalTable: "CompetitionTypes",
                        principalColumn: "TypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DisciplineGroupAllowedDiscipline",
                columns: table => new
                {
                    DisciplineGroupId = table.Column<int>(type: "int", nullable: false),
                    Discipline = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisciplineGroupAllowedDiscipline", x => new { x.DisciplineGroupId, x.Discipline });
                    table.ForeignKey(
                        name: "FK_DisciplineGroupAllowedDiscipline_DisciplineGroups_DisciplineGroupId",
                        column: x => x.DisciplineGroupId,
                        principalTable: "DisciplineGroups",
                        principalColumn: "DisciplineGroupId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EquineEstateMergeRequests",
                columns: table => new
                {
                    EEMergeRequestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EquineEstateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ToEquineEstateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProposedName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    RequestedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RespondedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquineEstateMergeRequests", x => x.EEMergeRequestId);
                    table.ForeignKey(
                        name: "FK_EquineEstateMergeRequests_EquineEstates_EquineEstateId",
                        column: x => x.EquineEstateId,
                        principalTable: "EquineEstates",
                        principalColumn: "EquineEstateId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EquineEstateMergeRequests_EquineEstates_ToEquineEstateId",
                        column: x => x.ToEquineEstateId,
                        principalTable: "EquineEstates",
                        principalColumn: "EquineEstateId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Facilities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HorseCapacity = table.Column<int>(type: "int", nullable: false),
                    PersonnelCapacity = table.Column<int>(type: "int", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EquineEstateId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FacilityType = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    SurfaceType = table.Column<int>(type: "int", nullable: true),
                    IsIndoor = table.Column<bool>(type: "bit", nullable: true),
                    Acreage = table.Column<int>(type: "int", nullable: true),
                    HasShelter = table.Column<bool>(type: "bit", nullable: true),
                    StaffCount = table.Column<int>(type: "int", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Facilities_EquineEstates_EquineEstateId",
                        column: x => x.EquineEstateId,
                        principalTable: "EquineEstates",
                        principalColumn: "EquineEstateId");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastLogin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId");
                });

            migrationBuilder.CreateTable(
                name: "Breeds",
                columns: table => new
                {
                    BreedId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BreedName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MinHeight = table.Column<int>(type: "int", nullable: false),
                    MaxHeight = table.Column<int>(type: "int", nullable: false),
                    DisciplinAffinity = table.Column<double>(type: "float", nullable: false),
                    IsFoundationBred = table.Column<bool>(type: "bit", nullable: false),
                    Rarity = table.Column<int>(type: "int", nullable: false),
                    Acquisition = table.Column<int>(type: "int", nullable: false),
                    LaunchSalePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    LaunchQuantity = table.Column<int>(type: "int", nullable: true),
                    CanMix = table.Column<bool>(type: "bit", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BreedGroupId = table.Column<int>(type: "int", nullable: true),
                    SaleEventTypeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Breeds", x => x.BreedId);
                    table.ForeignKey(
                        name: "FK_Breeds_BreedGroups_BreedGroupId",
                        column: x => x.BreedGroupId,
                        principalTable: "BreedGroups",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Breeds_SaleEventTypes_SaleEventTypeId",
                        column: x => x.SaleEventTypeId,
                        principalTable: "SaleEventTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SeasonWeatherAlloweds",
                columns: table => new
                {
                    SeasonsId = table.Column<int>(type: "int", nullable: false),
                    WeatherId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeasonWeatherAlloweds", x => new { x.SeasonsId, x.WeatherId });
                    table.ForeignKey(
                        name: "FK_SeasonWeatherAlloweds_Seasons_SeasonsId",
                        column: x => x.SeasonsId,
                        principalTable: "Seasons",
                        principalColumn: "SeasonsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Competitions",
                columns: table => new
                {
                    CompetitionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompetitionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EntryOpenAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EntryCloseAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ResultsAvailableAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DisciplineGroupId = table.Column<int>(type: "int", nullable: false),
                    CompetitionLevelId = table.Column<int>(type: "int", nullable: false),
                    CompetitionTypeId = table.Column<int>(type: "int", nullable: false),
                    DisciplineId = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    SeasonId = table.Column<int>(type: "int", nullable: false),
                    VenueId = table.Column<int>(type: "int", nullable: false),
                    ActualWeather = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competitions", x => x.CompetitionId);
                    table.ForeignKey(
                        name: "FK_Competitions_CompetitionLevels_CompetitionLevelId",
                        column: x => x.CompetitionLevelId,
                        principalTable: "CompetitionLevels",
                        principalColumn: "LevelId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Competitions_CompetitionTypes_CompetitionTypeId",
                        column: x => x.CompetitionTypeId,
                        principalTable: "CompetitionTypes",
                        principalColumn: "TypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Competitions_DisciplineGroups_DisciplineGroupId",
                        column: x => x.DisciplineGroupId,
                        principalTable: "DisciplineGroups",
                        principalColumn: "DisciplineGroupId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Competitions_Seasons_SeasonId",
                        column: x => x.SeasonId,
                        principalTable: "Seasons",
                        principalColumn: "SeasonsId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Competitions_Venues_VenueId",
                        column: x => x.VenueId,
                        principalTable: "Venues",
                        principalColumn: "VenueId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EquineEstatesOwners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EquineEstateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsPrimaryOwner = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquineEstatesOwners", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EquineEstatesOwners_EquineEstates_EquineEstateId",
                        column: x => x.EquineEstateId,
                        principalTable: "EquineEstates",
                        principalColumn: "EquineEstateId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EquineEstatesOwners_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BreedCrossGroup",
                columns: table => new
                {
                    BreedId = table.Column<int>(type: "int", nullable: false),
                    CrossGroupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BreedCrossGroup", x => new { x.BreedId, x.CrossGroupId });
                    table.ForeignKey(
                        name: "FK_BreedCrossGroup_Breeds_BreedId",
                        column: x => x.BreedId,
                        principalTable: "Breeds",
                        principalColumn: "BreedId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BreedCrossGroup_CrossGroups_CrossGroupId",
                        column: x => x.CrossGroupId,
                        principalTable: "CrossGroups",
                        principalColumn: "CrossGroupId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FoundationPairs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentBreedDamId = table.Column<int>(type: "int", nullable: false),
                    ParentBreedSireId = table.Column<int>(type: "int", nullable: false),
                    ResultBreedId = table.Column<int>(type: "int", nullable: false),
                    IsOrderSensitive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoundationPairs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FoundationPairs_Breeds_ParentBreedDamId",
                        column: x => x.ParentBreedDamId,
                        principalTable: "Breeds",
                        principalColumn: "BreedId");
                    table.ForeignKey(
                        name: "FK_FoundationPairs_Breeds_ParentBreedSireId",
                        column: x => x.ParentBreedSireId,
                        principalTable: "Breeds",
                        principalColumn: "BreedId");
                    table.ForeignKey(
                        name: "FK_FoundationPairs_Breeds_ResultBreedId",
                        column: x => x.ResultBreedId,
                        principalTable: "Breeds",
                        principalColumn: "BreedId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HorseTypeSubmissions",
                columns: table => new
                {
                    HorseTypeSubmissionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubmittedByUserId = table.Column<int>(type: "int", nullable: false),
                    SubmittedByUserUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MaturityStage = table.Column<int>(type: "int", nullable: false),
                    BreedID = table.Column<int>(type: "int", nullable: false),
                    SubmissionType = table.Column<int>(type: "int", nullable: false),
                    IsAdult = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Occasion = table.Column<int>(type: "int", nullable: false),
                    SubmittedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsHorse = table.Column<bool>(type: "bit", nullable: false),
                    PictureRef = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HorseTypeSubmissions", x => x.HorseTypeSubmissionID);
                    table.ForeignKey(
                        name: "FK_HorseTypeSubmissions_Breeds_BreedID",
                        column: x => x.BreedID,
                        principalTable: "Breeds",
                        principalColumn: "BreedId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HorseTypeSubmissions_Users_SubmittedByUserUserId",
                        column: x => x.SubmittedByUserUserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "HorseTypes",
                columns: table => new
                {
                    HorseTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HorseTypeSubmissionId = table.Column<int>(type: "int", nullable: false),
                    BreedId = table.Column<int>(type: "int", nullable: false),
                    TypeCategory = table.Column<int>(type: "int", nullable: false),
                    TypeHorsesAlive = table.Column<int>(type: "int", nullable: false),
                    MaturityStage = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HorseTypes", x => x.HorseTypeId);
                    table.ForeignKey(
                        name: "FK_HorseTypes_Breeds_BreedId",
                        column: x => x.BreedId,
                        principalTable: "Breeds",
                        principalColumn: "BreedId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HorseTypes_HorseTypeSubmissions_HorseTypeSubmissionId",
                        column: x => x.HorseTypeSubmissionId,
                        principalTable: "HorseTypeSubmissions",
                        principalColumn: "HorseTypeSubmissionID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HorseArtists",
                columns: table => new
                {
                    HorseArtistId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubmissionsAwaiting = table.Column<int>(type: "int", nullable: false),
                    SubmissionAccepted = table.Column<int>(type: "int", nullable: false),
                    HorseTypeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HorseArtists", x => x.HorseArtistId);
                    table.ForeignKey(
                        name: "FK_HorseArtists_HorseTypes_HorseTypeId",
                        column: x => x.HorseTypeId,
                        principalTable: "HorseTypes",
                        principalColumn: "HorseTypeId");
                    table.ForeignKey(
                        name: "FK_HorseArtists_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HorseTypeSubmissionArtists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HorseTypeSubmissionId = table.Column<int>(type: "int", nullable: false),
                    HorseArtistId = table.Column<int>(type: "int", nullable: false),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    ApprovedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HorseTypeSubmissionArtists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HorseTypeSubmissionArtists_HorseArtists_HorseArtistId",
                        column: x => x.HorseArtistId,
                        principalTable: "HorseArtists",
                        principalColumn: "HorseArtistId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HorseTypeSubmissionArtists_HorseTypeSubmissions_HorseTypeSubmissionId",
                        column: x => x.HorseTypeSubmissionId,
                        principalTable: "HorseTypeSubmissions",
                        principalColumn: "HorseTypeSubmissionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AuctionBids",
                columns: table => new
                {
                    AuctionBidId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuctionSaleId = table.Column<int>(type: "int", nullable: false),
                    BidderEquineEstateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BidAmount = table.Column<int>(type: "int", nullable: false),
                    TimeBidPlaced = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuctionBids", x => x.AuctionBidId);
                    table.ForeignKey(
                        name: "FK_AuctionBids_EquineEstates_BidderEquineEstateId",
                        column: x => x.BidderEquineEstateId,
                        principalTable: "EquineEstates",
                        principalColumn: "EquineEstateId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BreedQualityScores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Score = table.Column<double>(type: "float", nullable: false),
                    LastEvaluatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EvaluationNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HorseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BreedQualityScores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompetitionEntries",
                columns: table => new
                {
                    EntryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompetitionId = table.Column<int>(type: "int", nullable: false),
                    GuidHorseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EntryTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompetitionEntries", x => x.EntryId);
                    table.ForeignKey(
                        name: "FK_CompetitionEntries_Competitions_CompetitionId",
                        column: x => x.CompetitionId,
                        principalTable: "Competitions",
                        principalColumn: "CompetitionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompetitionProgressions",
                columns: table => new
                {
                    GuidHorseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompetitionLevel = table.Column<int>(type: "int", nullable: false),
                    CompetitionPoints = table.Column<double>(type: "float", nullable: false),
                    DateLastCompetition = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TotalCompetitions = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompetitionProgressions", x => x.GuidHorseId);
                });

            migrationBuilder.CreateTable(
                name: "Horses",
                columns: table => new
                {
                    GuidHorseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HorseRegistryId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HorseName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Sex = table.Column<int>(type: "int", nullable: false),
                    BirthDate = table.Column<DateOnly>(type: "date", nullable: false),
                    AgingDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Temperament = table.Column<int>(type: "int", nullable: false),
                    HorseTypeId = table.Column<int>(type: "int", nullable: false),
                    HorsePurposeType = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<double>(type: "float", nullable: false),
                    DisciplineGroupId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsInPasture = table.Column<bool>(type: "bit", nullable: false),
                    IsFoal = table.Column<bool>(type: "bit", nullable: false),
                    IsVaulted = table.Column<bool>(type: "bit", nullable: false),
                    IsShared = table.Column<bool>(type: "bit", nullable: false),
                    LegacyHorseId = table.Column<int>(type: "int", nullable: true),
                    ProgressionGuidHorseId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Archetype = table.Column<int>(type: "int", nullable: false),
                    CachedBQS = table.Column<double>(type: "float", nullable: true),
                    ChachedPQS = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Horses", x => x.GuidHorseId);
                    table.ForeignKey(
                        name: "FK_Horses_CompetitionProgressions_ProgressionGuidHorseId",
                        column: x => x.ProgressionGuidHorseId,
                        principalTable: "CompetitionProgressions",
                        principalColumn: "GuidHorseId");
                    table.ForeignKey(
                        name: "FK_Horses_HorseTypes_HorseTypeId",
                        column: x => x.HorseTypeId,
                        principalTable: "HorseTypes",
                        principalColumn: "HorseTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompetitionResults",
                columns: table => new
                {
                    ResultId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompetitionId = table.Column<int>(type: "int", nullable: false),
                    GuidHorseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Placement = table.Column<int>(type: "int", nullable: false),
                    PointType = table.Column<int>(type: "int", nullable: false),
                    PointsEarned = table.Column<int>(type: "int", nullable: false),
                    PlacementPrice = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompetitionResults", x => x.ResultId);
                    table.ForeignKey(
                        name: "FK_CompetitionResults_Competitions_CompetitionId",
                        column: x => x.CompetitionId,
                        principalTable: "Competitions",
                        principalColumn: "CompetitionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompetitionResults_Horses_GuidHorseId",
                        column: x => x.GuidHorseId,
                        principalTable: "Horses",
                        principalColumn: "GuidHorseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Foalings",
                columns: table => new
                {
                    FoalingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EquineEstateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SireId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FoalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FoalingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EstimatedValueIncrease = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foalings", x => x.FoalingId);
                    table.ForeignKey(
                        name: "FK_Foalings_EquineEstates_EquineEstateId",
                        column: x => x.EquineEstateId,
                        principalTable: "EquineEstates",
                        principalColumn: "EquineEstateId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Foalings_Horses_DamId",
                        column: x => x.DamId,
                        principalTable: "Horses",
                        principalColumn: "GuidHorseId");
                    table.ForeignKey(
                        name: "FK_Foalings_Horses_FoalId",
                        column: x => x.FoalId,
                        principalTable: "Horses",
                        principalColumn: "GuidHorseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Foalings_Horses_SireId",
                        column: x => x.SireId,
                        principalTable: "Horses",
                        principalColumn: "GuidHorseId");
                });

            migrationBuilder.CreateTable(
                name: "HorseBoardings",
                columns: table => new
                {
                    HorseBoardingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GuidHorseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HorseGuidHorseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BoardingEstateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EquineEstateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BoarderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: true),
                    IsPermanentResidence = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HorseBoardings", x => x.HorseBoardingId);
                    table.ForeignKey(
                        name: "FK_HorseBoardings_EquineEstates_EquineEstateId",
                        column: x => x.EquineEstateId,
                        principalTable: "EquineEstates",
                        principalColumn: "EquineEstateId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HorseBoardings_Horses_HorseGuidHorseId",
                        column: x => x.HorseGuidHorseId,
                        principalTable: "Horses",
                        principalColumn: "GuidHorseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HorseBoardings_Users_BoarderId",
                        column: x => x.BoarderId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HorseOwnerships",
                columns: table => new
                {
                    HorseOwnershipId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HorseGuidId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HorseOwnerships", x => x.HorseOwnershipId);
                    table.ForeignKey(
                        name: "FK_HorseOwnerships_Horses_HorseGuidId",
                        column: x => x.HorseGuidId,
                        principalTable: "Horses",
                        principalColumn: "GuidHorseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HorseOwnerships_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HorseSaleBase",
                columns: table => new
                {
                    HorseSaleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HorseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EquineEstateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VendorId = table.Column<int>(type: "int", nullable: false),
                    DateOfSale = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SaleEventId = table.Column<int>(type: "int", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    StartBid = table.Column<int>(type: "int", nullable: true),
                    BuyNowPrice = table.Column<int>(type: "int", nullable: true),
                    AuctionStartTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AuctionEndTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    WinningBidId = table.Column<int>(type: "int", nullable: true),
                    BuyerEquineEstateId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SalesPrice = table.Column<int>(type: "int", nullable: true),
                    Approved = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HorseSaleBase", x => x.HorseSaleId);
                    table.ForeignKey(
                        name: "FK_HorseSaleBase_AuctionBids_WinningBidId",
                        column: x => x.WinningBidId,
                        principalTable: "AuctionBids",
                        principalColumn: "AuctionBidId");
                    table.ForeignKey(
                        name: "FK_HorseSaleBase_EquineEstates_BuyerEquineEstateId",
                        column: x => x.BuyerEquineEstateId,
                        principalTable: "EquineEstates",
                        principalColumn: "EquineEstateId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HorseSaleBase_EquineEstates_EquineEstateId",
                        column: x => x.EquineEstateId,
                        principalTable: "EquineEstates",
                        principalColumn: "EquineEstateId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HorseSaleBase_Horses_HorseId",
                        column: x => x.HorseId,
                        principalTable: "Horses",
                        principalColumn: "GuidHorseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HorseSaleBase_Vendors_VendorId",
                        column: x => x.VendorId,
                        principalTable: "Vendors",
                        principalColumn: "VendorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PerformanceQualityScores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HorseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Score = table.Column<double>(type: "float", nullable: false),
                    TotalCompetitions = table.Column<int>(type: "int", nullable: false),
                    Wins = table.Column<int>(type: "int", nullable: false),
                    AveragePlacement = table.Column<double>(type: "float", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerformanceQualityScores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PerformanceQualityScores_Horses_HorseId",
                        column: x => x.HorseId,
                        principalTable: "Horses",
                        principalColumn: "GuidHorseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScorePotentials",
                columns: table => new
                {
                    HorseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CPSMin = table.Column<double>(type: "float", nullable: false),
                    CPSMax = table.Column<double>(type: "float", nullable: false),
                    BQSMin = table.Column<double>(type: "float", nullable: false),
                    BQSMax = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScorePotentials", x => x.HorseId);
                    table.ForeignKey(
                        name: "FK_ScorePotentials_Horses_HorseId",
                        column: x => x.HorseId,
                        principalTable: "Horses",
                        principalColumn: "GuidHorseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrophyBase",
                columns: table => new
                {
                    TrophyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrophyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateAwarded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HorseGuidHorseId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TrophyType = table.Column<string>(type: "nvarchar(21)", maxLength: 21, nullable: false),
                    HorseId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NumberOfFoals = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FoalsBred = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrophyBase", x => x.TrophyId);
                    table.ForeignKey(
                        name: "FK_TrophyBase_Horses_HorseGuidHorseId",
                        column: x => x.HorseGuidHorseId,
                        principalTable: "Horses",
                        principalColumn: "GuidHorseId");
                    table.ForeignKey(
                        name: "FK_TrophyBase_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConformationAttributes",
                columns: table => new
                {
                    ConfPerfTempAttributesCPTId = table.Column<int>(type: "int", nullable: false),
                    ConfId = table.Column<int>(type: "int", nullable: false),
                    Legs = table.Column<double>(type: "float", nullable: false),
                    Shoulders = table.Column<double>(type: "float", nullable: false),
                    Hindquarters = table.Column<double>(type: "float", nullable: false),
                    Pasterns = table.Column<double>(type: "float", nullable: false),
                    BackAndLoin = table.Column<double>(type: "float", nullable: false),
                    Head = table.Column<double>(type: "float", nullable: false),
                    Neck = table.Column<double>(type: "float", nullable: false),
                    ChestAndBarrel = table.Column<double>(type: "float", nullable: false),
                    BackAndTopline = table.Column<double>(type: "float", nullable: false),
                    OverallProportions = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConformationAttributes", x => x.ConfPerfTempAttributesCPTId);
                });

            migrationBuilder.CreateTable(
                name: "ConfPerfTempAttributes",
                columns: table => new
                {
                    CPTId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TemperamentInformationTemperamentId = table.Column<int>(type: "int", nullable: true),
                    GuidHorseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfPerfTempAttributes", x => x.CPTId);
                    table.ForeignKey(
                        name: "FK_ConfPerfTempAttributes_Horses_GuidHorseId",
                        column: x => x.GuidHorseId,
                        principalTable: "Horses",
                        principalColumn: "GuidHorseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PerformanceAttributes",
                columns: table => new
                {
                    ConfPerfTempAttributesCPTId = table.Column<int>(type: "int", nullable: false),
                    PerfId = table.Column<int>(type: "int", nullable: false),
                    Gaits = table.Column<double>(type: "float", nullable: false),
                    Jumping = table.Column<double>(type: "float", nullable: false),
                    Speed = table.Column<double>(type: "float", nullable: false),
                    Agility = table.Column<double>(type: "float", nullable: false),
                    Endurance = table.Column<double>(type: "float", nullable: false),
                    Stride = table.Column<double>(type: "float", nullable: false),
                    Rideability = table.Column<double>(type: "float", nullable: false),
                    Temperament = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerformanceAttributes", x => x.ConfPerfTempAttributesCPTId);
                    table.ForeignKey(
                        name: "FK_PerformanceAttributes_ConfPerfTempAttributes_ConfPerfTempAttributesCPTId",
                        column: x => x.ConfPerfTempAttributesCPTId,
                        principalTable: "ConfPerfTempAttributes",
                        principalColumn: "CPTId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TemperamentInformation",
                columns: table => new
                {
                    TemperamentId = table.Column<int>(type: "int", nullable: false),
                    Temperament = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AffectedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EffectOnPerformance = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PerformsWellIn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PerformsPoorlyIn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PreferredGroundTypes = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemperamentInformation", x => x.TemperamentId);
                    table.ForeignKey(
                        name: "FK_TemperamentInformation_ConfPerfTempAttributes_TemperamentId",
                        column: x => x.TemperamentId,
                        principalTable: "ConfPerfTempAttributes",
                        principalColumn: "CPTId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuctionBids_AuctionSaleId",
                table: "AuctionBids",
                column: "AuctionSaleId");

            migrationBuilder.CreateIndex(
                name: "IX_AuctionBids_BidderEquineEstateId",
                table: "AuctionBids",
                column: "BidderEquineEstateId");

            migrationBuilder.CreateIndex(
                name: "IX_BreedCrossGroup_CrossGroupId",
                table: "BreedCrossGroup",
                column: "CrossGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_BreedQualityScores_HorseId",
                table: "BreedQualityScores",
                column: "HorseId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Breeds_BreedGroupId",
                table: "Breeds",
                column: "BreedGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Breeds_SaleEventTypeId",
                table: "Breeds",
                column: "SaleEventTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CompetitionEntries_CompetitionId",
                table: "CompetitionEntries",
                column: "CompetitionId");

            migrationBuilder.CreateIndex(
                name: "IX_CompetitionEntries_GuidHorseId",
                table: "CompetitionEntries",
                column: "GuidHorseId");

            migrationBuilder.CreateIndex(
                name: "IX_CompetitionLevelCompetitionType_AllowedTypesTypeId",
                table: "CompetitionLevelCompetitionType",
                column: "AllowedTypesTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CompetitionResults_CompetitionId",
                table: "CompetitionResults",
                column: "CompetitionId");

            migrationBuilder.CreateIndex(
                name: "IX_CompetitionResults_GuidHorseId",
                table: "CompetitionResults",
                column: "GuidHorseId");

            migrationBuilder.CreateIndex(
                name: "IX_Competitions_CompetitionLevelId",
                table: "Competitions",
                column: "CompetitionLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Competitions_CompetitionTypeId",
                table: "Competitions",
                column: "CompetitionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Competitions_DisciplineGroupId",
                table: "Competitions",
                column: "DisciplineGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Competitions_SeasonId",
                table: "Competitions",
                column: "SeasonId");

            migrationBuilder.CreateIndex(
                name: "IX_Competitions_VenueId",
                table: "Competitions",
                column: "VenueId");

            migrationBuilder.CreateIndex(
                name: "IX_ConfPerfTempAttributes_GuidHorseId",
                table: "ConfPerfTempAttributes",
                column: "GuidHorseId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ConfPerfTempAttributes_TemperamentInformationTemperamentId",
                table: "ConfPerfTempAttributes",
                column: "TemperamentInformationTemperamentId");

            migrationBuilder.CreateIndex(
                name: "IX_CrossGroups_BreedGroupId",
                table: "CrossGroups",
                column: "BreedGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_EquineEstateMergeRequests_EquineEstateId",
                table: "EquineEstateMergeRequests",
                column: "EquineEstateId");

            migrationBuilder.CreateIndex(
                name: "IX_EquineEstateMergeRequests_ToEquineEstateId",
                table: "EquineEstateMergeRequests",
                column: "ToEquineEstateId");

            migrationBuilder.CreateIndex(
                name: "IX_EquineEstatesOwners_EquineEstateId",
                table: "EquineEstatesOwners",
                column: "EquineEstateId");

            migrationBuilder.CreateIndex(
                name: "IX_EquineEstatesOwners_UserId",
                table: "EquineEstatesOwners",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Facilities_EquineEstateId",
                table: "Facilities",
                column: "EquineEstateId");

            migrationBuilder.CreateIndex(
                name: "IX_Foalings_DamId",
                table: "Foalings",
                column: "DamId");

            migrationBuilder.CreateIndex(
                name: "IX_Foalings_EquineEstateId",
                table: "Foalings",
                column: "EquineEstateId");

            migrationBuilder.CreateIndex(
                name: "IX_Foalings_FoalId",
                table: "Foalings",
                column: "FoalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Foalings_SireId",
                table: "Foalings",
                column: "SireId");

            migrationBuilder.CreateIndex(
                name: "IX_FoundationPairs_ParentBreedDamId",
                table: "FoundationPairs",
                column: "ParentBreedDamId");

            migrationBuilder.CreateIndex(
                name: "IX_FoundationPairs_ParentBreedSireId",
                table: "FoundationPairs",
                column: "ParentBreedSireId");

            migrationBuilder.CreateIndex(
                name: "IX_FoundationPairs_ResultBreedId",
                table: "FoundationPairs",
                column: "ResultBreedId");

            migrationBuilder.CreateIndex(
                name: "IX_HorseArtists_HorseTypeId",
                table: "HorseArtists",
                column: "HorseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_HorseArtists_UserId",
                table: "HorseArtists",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_HorseBoardings_BoarderId",
                table: "HorseBoardings",
                column: "BoarderId");

            migrationBuilder.CreateIndex(
                name: "IX_HorseBoardings_EquineEstateId",
                table: "HorseBoardings",
                column: "EquineEstateId");

            migrationBuilder.CreateIndex(
                name: "IX_HorseBoardings_HorseGuidHorseId",
                table: "HorseBoardings",
                column: "HorseGuidHorseId");

            migrationBuilder.CreateIndex(
                name: "IX_HorseOwnerships_HorseGuidId",
                table: "HorseOwnerships",
                column: "HorseGuidId");

            migrationBuilder.CreateIndex(
                name: "IX_HorseOwnerships_UserId",
                table: "HorseOwnerships",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Horses_HorseTypeId",
                table: "Horses",
                column: "HorseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Horses_ProgressionGuidHorseId",
                table: "Horses",
                column: "ProgressionGuidHorseId");

            migrationBuilder.CreateIndex(
                name: "IX_HorseSaleBase_BuyerEquineEstateId",
                table: "HorseSaleBase",
                column: "BuyerEquineEstateId");

            migrationBuilder.CreateIndex(
                name: "IX_HorseSaleBase_EquineEstateId",
                table: "HorseSaleBase",
                column: "EquineEstateId");

            migrationBuilder.CreateIndex(
                name: "IX_HorseSaleBase_HorseId",
                table: "HorseSaleBase",
                column: "HorseId");

            migrationBuilder.CreateIndex(
                name: "IX_HorseSaleBase_VendorId",
                table: "HorseSaleBase",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_HorseSaleBase_WinningBidId",
                table: "HorseSaleBase",
                column: "WinningBidId");

            migrationBuilder.CreateIndex(
                name: "IX_HorseTypes_BreedId",
                table: "HorseTypes",
                column: "BreedId");

            migrationBuilder.CreateIndex(
                name: "IX_HorseTypes_HorseTypeSubmissionId",
                table: "HorseTypes",
                column: "HorseTypeSubmissionId");

            migrationBuilder.CreateIndex(
                name: "IX_HorseTypeSubmissionArtists_HorseArtistId",
                table: "HorseTypeSubmissionArtists",
                column: "HorseArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_HorseTypeSubmissionArtists_HorseTypeSubmissionId",
                table: "HorseTypeSubmissionArtists",
                column: "HorseTypeSubmissionId");

            migrationBuilder.CreateIndex(
                name: "IX_HorseTypeSubmissions_BreedID",
                table: "HorseTypeSubmissions",
                column: "BreedID");

            migrationBuilder.CreateIndex(
                name: "IX_HorseTypeSubmissions_SubmittedByUserUserId",
                table: "HorseTypeSubmissions",
                column: "SubmittedByUserUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PerformanceQualityScores_HorseId",
                table: "PerformanceQualityScores",
                column: "HorseId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrophyBase_HorseGuidHorseId",
                table: "TrophyBase",
                column: "HorseGuidHorseId");

            migrationBuilder.CreateIndex(
                name: "IX_TrophyBase_UserId",
                table: "TrophyBase",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_AuctionBids_HorseSaleBase_AuctionSaleId",
                table: "AuctionBids",
                column: "AuctionSaleId",
                principalTable: "HorseSaleBase",
                principalColumn: "HorseSaleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BreedQualityScores_Horses_HorseId",
                table: "BreedQualityScores",
                column: "HorseId",
                principalTable: "Horses",
                principalColumn: "GuidHorseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompetitionEntries_Horses_GuidHorseId",
                table: "CompetitionEntries",
                column: "GuidHorseId",
                principalTable: "Horses",
                principalColumn: "GuidHorseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompetitionProgressions_Horses_GuidHorseId",
                table: "CompetitionProgressions",
                column: "GuidHorseId",
                principalTable: "Horses",
                principalColumn: "GuidHorseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ConformationAttributes_ConfPerfTempAttributes_ConfPerfTempAttributesCPTId",
                table: "ConformationAttributes",
                column: "ConfPerfTempAttributesCPTId",
                principalTable: "ConfPerfTempAttributes",
                principalColumn: "CPTId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ConfPerfTempAttributes_TemperamentInformation_TemperamentInformationTemperamentId",
                table: "ConfPerfTempAttributes",
                column: "TemperamentInformationTemperamentId",
                principalTable: "TemperamentInformation",
                principalColumn: "TemperamentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuctionBids_EquineEstates_BidderEquineEstateId",
                table: "AuctionBids");

            migrationBuilder.DropForeignKey(
                name: "FK_HorseSaleBase_EquineEstates_BuyerEquineEstateId",
                table: "HorseSaleBase");

            migrationBuilder.DropForeignKey(
                name: "FK_HorseSaleBase_EquineEstates_EquineEstateId",
                table: "HorseSaleBase");

            migrationBuilder.DropForeignKey(
                name: "FK_AuctionBids_HorseSaleBase_AuctionSaleId",
                table: "AuctionBids");

            migrationBuilder.DropForeignKey(
                name: "FK_HorseTypes_Breeds_BreedId",
                table: "HorseTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_HorseTypeSubmissions_Breeds_BreedID",
                table: "HorseTypeSubmissions");

            migrationBuilder.DropForeignKey(
                name: "FK_CompetitionProgressions_Horses_GuidHorseId",
                table: "CompetitionProgressions");

            migrationBuilder.DropForeignKey(
                name: "FK_ConfPerfTempAttributes_Horses_GuidHorseId",
                table: "ConfPerfTempAttributes");

            migrationBuilder.DropForeignKey(
                name: "FK_TemperamentInformation_ConfPerfTempAttributes_TemperamentId",
                table: "TemperamentInformation");

            migrationBuilder.DropTable(
                name: "BreedCrossGroup");

            migrationBuilder.DropTable(
                name: "BreedQualityScores");

            migrationBuilder.DropTable(
                name: "CompetitionEntries");

            migrationBuilder.DropTable(
                name: "CompetitionLevelCompetitionType");

            migrationBuilder.DropTable(
                name: "CompetitionResults");

            migrationBuilder.DropTable(
                name: "ConformationAttributes");

            migrationBuilder.DropTable(
                name: "DisciplineGroupAllowedDiscipline");

            migrationBuilder.DropTable(
                name: "EquineEstateMergeRequests");

            migrationBuilder.DropTable(
                name: "EquineEstatesOwners");

            migrationBuilder.DropTable(
                name: "Facilities");

            migrationBuilder.DropTable(
                name: "Foalings");

            migrationBuilder.DropTable(
                name: "FoundationPairs");

            migrationBuilder.DropTable(
                name: "HorseArtistSApprovals");

            migrationBuilder.DropTable(
                name: "HorseBoardings");

            migrationBuilder.DropTable(
                name: "HorseOwnerships");

            migrationBuilder.DropTable(
                name: "HorsePurposeStats");

            migrationBuilder.DropTable(
                name: "HorseTypeSubmissionArtists");

            migrationBuilder.DropTable(
                name: "PerformanceAttributes");

            migrationBuilder.DropTable(
                name: "PerformanceQualityScores");

            migrationBuilder.DropTable(
                name: "ScorePotentials");

            migrationBuilder.DropTable(
                name: "SeasonWeatherAlloweds");

            migrationBuilder.DropTable(
                name: "TestEntities");

            migrationBuilder.DropTable(
                name: "TrophyBase");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "CrossGroups");

            migrationBuilder.DropTable(
                name: "Competitions");

            migrationBuilder.DropTable(
                name: "HorseArtists");

            migrationBuilder.DropTable(
                name: "CompetitionLevels");

            migrationBuilder.DropTable(
                name: "CompetitionTypes");

            migrationBuilder.DropTable(
                name: "DisciplineGroups");

            migrationBuilder.DropTable(
                name: "Seasons");

            migrationBuilder.DropTable(
                name: "Venues");

            migrationBuilder.DropTable(
                name: "EquineEstates");

            migrationBuilder.DropTable(
                name: "HorseSaleBase");

            migrationBuilder.DropTable(
                name: "AuctionBids");

            migrationBuilder.DropTable(
                name: "Vendors");

            migrationBuilder.DropTable(
                name: "Breeds");

            migrationBuilder.DropTable(
                name: "BreedGroups");

            migrationBuilder.DropTable(
                name: "SaleEventTypes");

            migrationBuilder.DropTable(
                name: "Horses");

            migrationBuilder.DropTable(
                name: "CompetitionProgressions");

            migrationBuilder.DropTable(
                name: "HorseTypes");

            migrationBuilder.DropTable(
                name: "HorseTypeSubmissions");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "ConfPerfTempAttributes");

            migrationBuilder.DropTable(
                name: "TemperamentInformation");
        }
    }
}
