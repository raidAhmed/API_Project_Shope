using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agricultural.Infrastructure.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "ActivityType",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActivityName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByUser = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<int>(type: "int", nullable: true),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityType", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    UserType = table.Column<byte>(type: "tinyint", nullable: false),
                    State = table.Column<byte>(type: "tinyint", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Banks",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByUser = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<int>(type: "int", nullable: true),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banks", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                });

            migrationBuilder.CreateTable(
                name: "CheckOut",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckOut", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                });

            migrationBuilder.CreateTable(
                name: "City",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                });

            migrationBuilder.CreateTable(
                name: "Color",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    code = table.Column<string>(type: "nvarchar(15)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Color", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                });

            migrationBuilder.CreateTable(
                name: "ComplainantToParty",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Topic = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    TypeofMesseage = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    SenderId = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    ReciverId = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    requestState = table.Column<bool>(type: "bit", nullable: false),
                    ServiceType = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComplainantToParty", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                });

            migrationBuilder.CreateTable(
                name: "Currency",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByUser = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<int>(type: "int", nullable: true),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currency", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                });

            migrationBuilder.CreateTable(
                name: "ManufactureCompany",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CompanyInfo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManufactureCompany", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                });

            migrationBuilder.CreateTable(
                name: "Markets",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DescriptionAddress = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    CityId = table.Column<int>(type: "int", nullable: true),
                    DirectorateId = table.Column<int>(type: "int", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Markets", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                });

            migrationBuilder.CreateTable(
                name: "Product_Attribute",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Pk_Product_Attribute", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                });

            migrationBuilder.CreateTable(
                name: "ProFeatures",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProFeatures", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                });

            migrationBuilder.CreateTable(
                name: "ServicesType",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicesType", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                });

            migrationBuilder.CreateTable(
                name: "Unit",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    value = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unit", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                });

            migrationBuilder.CreateTable(
                name: "Weekdays",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weekdays", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkinPoeriods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkinPoeriods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MainClassification",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MainClassificationName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ActivityTypeId = table.Column<int>(type: "int", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainClassification", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_MainClassifications_ActivityType",
                        column: x => x.ActivityTypeId,
                        principalSchema: "dbo",
                        principalTable: "ActivityType",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "dbo",
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                schema: "dbo",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "dbo",
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User_Bank",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BanksAccountNum = table.Column<int>(type: "int", nullable: false),
                    BanksId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Bank", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Bank_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_Bank_Banks_BanksId",
                        column: x => x.BanksId,
                        principalSchema: "dbo",
                        principalTable: "Banks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Directorate",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Directorate", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_Directorates_City",
                        column: x => x.CityId,
                        principalSchema: "dbo",
                        principalTable: "City",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ComplainantPic",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ComplainantToPartyId = table.Column<int>(type: "int", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComplainantPic", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComplainantPic_ComplainantToParty_ComplainantToPartyId",
                        column: x => x.ComplainantToPartyId,
                        principalSchema: "dbo",
                        principalTable: "ComplainantToParty",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Brand",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ManufactureCompanyId = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_Brand_ManufactureCompany",
                        column: x => x.ManufactureCompanyId,
                        principalSchema: "dbo",
                        principalTable: "ManufactureCompany",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "News",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Topic = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "Date", nullable: true),
                    DeleteAt = table.Column<DateTime>(type: "Date", nullable: true),
                    MarketsId = table.Column<int>(type: "int", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    State = table.Column<int>(type: "int", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_Newss_Markets",
                        column: x => x.MarketsId,
                        principalSchema: "dbo",
                        principalTable: "Markets",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ServiceProvider",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TradeName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Logo = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    NatId = table.Column<int>(type: "int", nullable: true, defaultValue: 111111),
                    Type = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ActivityTypeId = table.Column<int>(type: "int", nullable: false),
                    ViewPlace = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    ServiceTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceProvider", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_ServiceProvider_ActivityType_ActivityTypeId",
                        column: x => x.ActivityTypeId,
                        principalSchema: "dbo",
                        principalTable: "ActivityType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceProvIder_ServiceType",
                        column: x => x.ServiceTypeId,
                        principalSchema: "dbo",
                        principalTable: "ServicesType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ServiceProvIder_User",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AdditionalSections",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdditionalSectionsName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Rank = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ParnetSectionId = table.Column<int>(type: "int", nullable: true),
                    MainClassificationId = table.Column<int>(type: "int", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdditionalSections", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_AdditionalSections_AdditionalSections_ParnetSectionId",
                        column: x => x.ParnetSectionId,
                        principalSchema: "dbo",
                        principalTable: "AdditionalSections",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AdditionalSections_MainClassification",
                        column: x => x.MainClassificationId,
                        principalSchema: "dbo",
                        principalTable: "MainClassification",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Address",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DirectorateId = table.Column<int>(type: "int", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    State = table.Column<bool>(type: "bit", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                   
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_SP_Address_Directorate",
                        column: x => x.DirectorateId,
                        principalSchema: "dbo",
                        principalTable: "Directorate",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SP_Address_User",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BusinessCommercial",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BankAccount = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TradeRecord = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ServiceProviderId = table.Column<int>(type: "int", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessCommercial", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_BusinessCommercials_ServiceProvider",
                        column: x => x.ServiceProviderId,
                        principalSchema: "dbo",
                        principalTable: "ServiceProvider",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Cart",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sku = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Total = table.Column<decimal>(type: "decimal", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    ServiceProviderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_Cart_ServiceProvider",
                        column: x => x.ServiceProviderId,
                        principalSchema: "dbo",
                        principalTable: "ServiceProvider",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Cart_User",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Farmer",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EarthLength = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EarthInfo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EarthWidth = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ServiceProviderId = table.Column<int>(type: "int", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Farmer", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_Farmers_ServiceProvider",
                        column: x => x.ServiceProviderId,
                        principalSchema: "dbo",
                        principalTable: "ServiceProvider",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OfficialParty",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganisationType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ServiceProviderId = table.Column<int>(type: "int", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfficialParty", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_OfficialPartys_ServiceProvider",
                        column: x => x.ServiceProviderId,
                        principalSchema: "dbo",
                        principalTable: "ServiceProvider",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProviderEvaluation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    value = table.Column<int>(type: "int", nullable: false),
                    ServiceProviderId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProviderEvaluation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProviderEvaluation_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProviderEvaluation_ServiceProvider_ServiceProviderId",
                        column: x => x.ServiceProviderId,
                        principalSchema: "dbo",
                        principalTable: "ServiceProvider",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Slider",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Details = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StartDate = table.Column<DateTime>(type: "DateTime", nullable: false, defaultValue: new DateTime(2023, 3, 28, 0, 57, 23, 762, DateTimeKind.Local).AddTicks(344)),
                    EndDate = table.Column<DateTime>(type: "DateTime", nullable: false),
                    ServiceProviderId = table.Column<int>(type: "int", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slider", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_Slider_ServiceProvider",
                        column: x => x.ServiceProviderId,
                        principalSchema: "dbo",
                        principalTable: "ServiceProvider",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SP_MainClassification",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MainClassificationId = table.Column<int>(type: "int", nullable: true),
                    ServiceProviderId = table.Column<int>(type: "int", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SP_MainClassification", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_SP_MainClassificationsm_MainClassification",
                        column: x => x.MainClassificationId,
                        principalSchema: "dbo",
                        principalTable: "MainClassification",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SP_MainClassificationsm_ServiceProvider",
                        column: x => x.ServiceProviderId,
                        principalSchema: "dbo",
                        principalTable: "ServiceProvider",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SP_ProFeatures",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceProviderId = table.Column<int>(type: "int", nullable: true),
                    ProFeaturesId = table.Column<int>(type: "int", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SP_ProFeatures", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_SP_ProFeatures_ProFeature",
                        column: x => x.ProFeaturesId,
                        principalSchema: "dbo",
                        principalTable: "ProFeatures",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SP_ProFeatures_ServiceProvider",
                        column: x => x.ServiceProviderId,
                        principalSchema: "dbo",
                        principalTable: "ServiceProvider",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SP_User_Favourites",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ServiceProviderId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SP_User_Favourites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SP_User_Favourites_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SP_User_Favourites_ServiceProvider_ServiceProviderId",
                        column: x => x.ServiceProviderId,
                        principalSchema: "dbo",
                        principalTable: "ServiceProvider",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "WorkingHours",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FromTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ToTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WeekdaysId = table.Column<int>(type: "int", nullable: false),
                    WorkinPoeriodsId = table.Column<int>(type: "int", nullable: false),
                    ServiceProviderId = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkingHours", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkingHours_ServiceProvIder",
                        column: x => x.ServiceProviderId,
                        principalSchema: "dbo",
                        principalTable: "ServiceProvider",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WorkingHours_weekdays",
                        column: x => x.WeekdaysId,
                        principalTable: "Weekdays",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WorkingHours_WorkinPoeriods",
                        column: x => x.WorkinPoeriodsId,
                        principalTable: "WorkinPoeriods",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SP_AdditionalSections",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdditionalSectionsId = table.Column<int>(type: "int", nullable: true),
                    ServiceProviderId = table.Column<int>(type: "int", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SP_AdditionalSections", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_SP_AdditionalSections_AdditionalSections",
                        column: x => x.AdditionalSectionsId,
                        principalSchema: "dbo",
                        principalTable: "AdditionalSections",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SP_AdditionalSections_ServiceProvider",
                        column: x => x.ServiceProviderId,
                        principalSchema: "dbo",
                        principalTable: "ServiceProvider",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SpecialSections",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpecialSectionName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    MainClassificationId = table.Column<int>(type: "int", nullable: true),
                    AdditionalSectionsId = table.Column<int>(type: "int", nullable: true),
                    ParnetSectionId = table.Column<int>(type: "int", nullable: true),
                    Rank = table.Column<int>(type: "int", nullable: false),
                    ServiceProviderId = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialSections", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_SpecialSections_AdditionalSections",
                        column: x => x.AdditionalSectionsId,
                        principalSchema: "dbo",
                        principalTable: "AdditionalSections",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SpecialSections_MainClassification",
                        column: x => x.MainClassificationId,
                        principalSchema: "dbo",
                        principalTable: "MainClassification",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SpecialSections_ServiceProvider",
                        column: x => x.ServiceProviderId,
                        principalSchema: "dbo",
                        principalTable: "ServiceProvider",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SpecialSections_SpecialSections",
                        column: x => x.ParnetSectionId,
                        principalSchema: "dbo",
                        principalTable: "SpecialSections",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Order",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderID = table.Column<int>(type: "int", nullable: true),
                    Total = table.Column<decimal>(type: "decimal", nullable: false),
                    Quntity = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CartId = table.Column<int>(type: "int", nullable: true),
                    State = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    ServiceProviderId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_Order_Cart",
                        column: x => x.CartId,
                        principalSchema: "dbo",
                        principalTable: "Cart",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_ServiceProvider",
                        column: x => x.ServiceProviderId,
                        principalSchema: "dbo",
                        principalTable: "ServiceProvider",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_User",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ConsultationRequest",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Topic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServiceProviderId = table.Column<int>(type: "int", nullable: true),
                    FarmerId = table.Column<int>(type: "int", nullable: true),
                    RequestState = table.Column<bool>(type: "bit", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsultationRequest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConsultationRequest_Farmer_FarmerId",
                        column: x => x.FarmerId,
                        principalSchema: "dbo",
                        principalTable: "Farmer",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ConsultationRequest_ServiceProvider_ServiceProviderId",
                        column: x => x.ServiceProviderId,
                        principalSchema: "dbo",
                        principalTable: "ServiceProvider",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SupportRequest",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Topic = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    OfficialPartyId = table.Column<int>(type: "int", nullable: true),
                    FarmerId = table.Column<int>(type: "int", nullable: true),
                    requestState = table.Column<bool>(type: "bit", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupportRequest", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_SP_SupportRequests_OfficialParty",
                        column: x => x.OfficialPartyId,
                        principalSchema: "dbo",
                        principalTable: "OfficialParty",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SupportRequests_Farmer",
                        column: x => x.FarmerId,
                        principalSchema: "dbo",
                        principalTable: "Farmer",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SliderImages",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Details = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Url = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    SliderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SliderImages", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_SliderImage_Slider",
                        column: x => x.SliderId,
                        principalSchema: "dbo",
                        principalTable: "Slider",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Product",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Thumbnail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitId = table.Column<int>(type: "int", nullable: true),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PurchasePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Current_Stock = table.Column<int>(type: "int", nullable: true),
                    Min_qty = table.Column<int>(type: "int", nullable: true),
                    Minimum_Order_Qty = table.Column<int>(type: "int", nullable: true),
                    Negotiation = table.Column<bool>(type: "bit", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Free_Shipping = table.Column<bool>(type: "bit", nullable: false),
                    Refundable = table.Column<bool>(type: "bit", nullable: false),
                    Multiply_Qty = table.Column<bool>(type: "bit", nullable: false),
                    Video_Provider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Video_Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discount = table.Column<int>(type: "int", nullable: true),
                    DiscountType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VideoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductStates = table.Column<bool>(type: "bit", nullable: false),
                    Add_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrandId = table.Column<int>(type: "int", nullable: true),
                    ActivityTypeId = table.Column<int>(type: "int", nullable: true),
                    MainClassificationId = table.Column<int>(type: "int", nullable: true),
                    AdditionalSectionsId = table.Column<int>(type: "int", nullable: true),
                    SpecialSectionsId = table.Column<int>(type: "int", nullable: true),
                    ServiceProviderId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_ActivityType_ActivityTypeId",
                        column: x => x.ActivityTypeId,
                        principalSchema: "dbo",
                        principalTable: "ActivityType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Product_AdditionalSections_AdditionalSectionsId",
                        column: x => x.AdditionalSectionsId,
                        principalSchema: "dbo",
                        principalTable: "AdditionalSections",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Product_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Product_Brand_BrandId",
                        column: x => x.BrandId,
                        principalSchema: "dbo",
                        principalTable: "Brand",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Product_MainClassification_MainClassificationId",
                        column: x => x.MainClassificationId,
                        principalSchema: "dbo",
                        principalTable: "MainClassification",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Product_ServiceProvider_ServiceProviderId",
                        column: x => x.ServiceProviderId,
                        principalSchema: "dbo",
                        principalTable: "ServiceProvider",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Product_SpecialSections_SpecialSectionsId",
                        column: x => x.SpecialSectionsId,
                        principalSchema: "dbo",
                        principalTable: "SpecialSections",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ConsultationRequestPic",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConsultationRequestId = table.Column<int>(type: "int", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsultationRequestPic", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConsultationRequestPic_ConsultationRequest_ConsultationRequestId",
                        column: x => x.ConsultationRequestId,
                        principalTable: "ConsultationRequest",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Offer",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "char(1)", nullable: false),
                    ApplyTo = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal", nullable: false),
                    QtRequire = table.Column<int>(type: "int", nullable: false),
                    PriceRequire = table.Column<decimal>(type: "decimal", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    serviceProviderId = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<string>(type: "char(1)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offer", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_Offers_Product",
                        column: x => x.ProductId,
                        principalSchema: "dbo",
                        principalTable: "Product",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Offers_ServiceProvider",
                        column: x => x.serviceProviderId,
                        principalSchema: "dbo",
                        principalTable: "ServiceProvider",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Product_AdditionalDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product_AdditionalDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_AdditionalDetails_Product_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "dbo",
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product_Colors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ColorId = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product_Colors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Colors_Color_ColorId",
                        column: x => x.ColorId,
                        principalSchema: "dbo",
                        principalTable: "Color",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Product_Colors_Product_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "dbo",
                        principalTable: "Product",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Product_Image",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product_Image", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Image_Product_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "dbo",
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product_Unit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    UnitId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    qty = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product_Unit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Unit_Product_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "dbo",
                        principalTable: "Product",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Product_Unit_Unit_UnitId",
                        column: x => x.UnitId,
                        principalSchema: "dbo",
                        principalTable: "Unit",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Product_User_Favourites",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product_User_Favourites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_User_Favourites_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Product_User_Favourites_Product_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "dbo",
                        principalTable: "Product",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Product_Variant_Attribute",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Product_AttributeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product_Variant_Attribute", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Variant_Attribute_Product_Attribute_Product_AttributeId",
                        column: x => x.Product_AttributeId,
                        principalSchema: "dbo",
                        principalTable: "Product_Attribute",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Product_Variant_Attribute_Product_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "dbo",
                        principalTable: "Product",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Product_variantion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SKU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    qty = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product_variantion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_variantion_Product_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "dbo",
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductEvaluaton",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductEvaluaton", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductEvaluaton_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProductEvaluaton_Product_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "dbo",
                        principalTable: "Product",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CartDetails",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sku = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<decimal>(type: "decimal", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Product_variantionId = table.Column<int>(type: "int", nullable: true),
                    CartId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ServiceProviderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartDetails", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_CartDetails_Cart",
                        column: x => x.CartId,
                        principalSchema: "dbo",
                        principalTable: "Cart",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CartDetails_Product",
                        column: x => x.ProductId,
                        principalSchema: "dbo",
                        principalTable: "Product",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CartDetails_ProductVariation",
                        column: x => x.Product_variantionId,
                        principalTable: "Product_variantion",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CartDetiles_ServiceProvider",
                        column: x => x.ServiceProviderId,
                        principalSchema: "dbo",
                        principalTable: "ServiceProvider",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CartDetiles_User",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sku = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<decimal>(type: "decimal", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Product_variantionId = table.Column<int>(type: "int", nullable: true),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ServiceProviderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Order",
                        column: x => x.OrderId,
                        principalSchema: "dbo",
                        principalTable: "Order",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderDetails_Product",
                        column: x => x.ProductId,
                        principalSchema: "dbo",
                        principalTable: "Product",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderDetails_ProductVariation",
                        column: x => x.Product_variantionId,
                        principalTable: "Product_variantion",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderDetails_ServiceProvider",
                        column: x => x.ServiceProviderId,
                        principalSchema: "dbo",
                        principalTable: "ServiceProvider",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderDetails_User",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "ActivityType",
                columns: new[] { "Id", "Active", "ActivityName", "CreatedAt", "CreatedByUser", "DeletedAt", "DeletedBy", "IsDeleted", "LastModifiedAt", "LastModifiedBy" },
                values: new object[,]
                {
                    { 1, true, "خدمي", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, null, false, null, null },
                    { 2, true, "تجاري", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, null, false, null, null }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8c1f7d67-0b9e-44ef-83d4-6e4ef72d3b6f", "ca3b3647-fb97-40a0-ad64-8a3d645cdc03", "Owner", "OWNER" },
                    { "ca34737e-e863-40aa-a82f-adbd3207988a", "b9fce677-ff9b-4d55-93b0-dcb97d12b11c", "Admin", "ADMIN" },
                    { "cb512048-1ad1-437b-8930-1b70a31e4d5c", "de8c59e2-0bf9-451e-8c0f-672e0335fbf2", "ServiceProvider", "SERVICEPROVIDER" },
                    { "eedae456-fa3a-47a0-9764-c634214bbe42", "a8333576-d0ec-4caa-925c-cf7113f8df7d", "User", "USER" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Active", "ConcurrencyStamp", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "Email", "EmailConfirmed", "FirstName", "Image", "IsDeleted", "LastModifiedAt", "LastModifiedBy", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "State", "Status", "TwoFactorEnabled", "UserName", "UserType" },
                values: new object[] { "4a2e1650-21bd-4e67-832e-2e99c267a2e4", 0, true, "c270bb22-b4d9-4abf-8d06-942d4b633836", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "Agricultural@Gmail.com", false, "شركة", "Upload/Users/d765abae-79c2-4ff8-975e-fb9e5578aa5c.jpg", false, null, null, "كوانتم", false, null, "AGRICULTURAL@GMAIL.COM", "QUANTUM", "AQAAAAEAACcQAAAAENJa4jon8qZGz5PQxo/UyKb5CkZZpIjFPSt7pxtp2qdddM9X7So5M5+XQqzrKKxWsA==", null, false, "c72cd74c-33c9-4e61-87fa-a2e640740365", null, true, false, "Quantum", (byte)0 });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Product_Attribute",
                columns: new[] { "Id", "Active", "Name" },
                values: new object[,]
                {
                    { 1, true, "الحجم" },
                    { 2, true, "النوع" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "ServicesType",
                columns: new[] { "Id", "Active", "Name" },
                values: new object[,]
                {
                    { 1, true, "خدمة" },
                    { 2, true, "تاجر" }
                });

            migrationBuilder.InsertData(
                table: "Weekdays",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "السبت" },
                    { 2, "الاحد" },
                    { 3, "الاثنين" },
                    { 4, "الثلاثاء" },
                    { 5, "الاربعاء" },
                    { 6, "الخميس" },
                    { 7, "الجمعة" }
                });

            migrationBuilder.InsertData(
                table: "WorkinPoeriods",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "فترة" },
                    { 2, "فترتين" },
                    { 3, "ساعه24" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "ca34737e-e863-40aa-a82f-adbd3207988a", "4a2e1650-21bd-4e67-832e-2e99c267a2e4" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "ServiceProvider",
                columns: new[] { "Id", "Active", "ActivityTypeId", "Description", "Email", "Logo", "NatId", "PhoneNumber", "ServiceTypeId", "TradeName", "Type", "UserId", "ViewPlace" },
                values: new object[] { 1, true, 1, "الافضل", "m@g", "Upload/ServiceProvider/8d168bb7-7e70-48c1-9ea9-74f63ed8eb75.jpg", 1, "775752111", 1, "متجري", "جواز", "4a2e1650-21bd-4e67-832e-2e99c267a2e4", 0 });

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalSections_MainClassificationId",
                schema: "dbo",
                table: "AdditionalSections",
                column: "MainClassificationId");

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalSections_ParnetSectionId",
                schema: "dbo",
                table: "AdditionalSections",
                column: "ParnetSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_DirectorateId",
                schema: "dbo",
                table: "Address",
                column: "DirectorateId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_ServiceProviderId",
                schema: "dbo",
                table: "Address",
                column: "ServiceProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_UserId",
                schema: "dbo",
                table: "Address",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "dbo",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                schema: "dbo",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "dbo",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "dbo",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Brand_ManufactureCompanyId",
                schema: "dbo",
                table: "Brand",
                column: "ManufactureCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessCommercial_ServiceProviderId",
                schema: "dbo",
                table: "BusinessCommercial",
                column: "ServiceProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_ServiceProviderId",
                schema: "dbo",
                table: "Cart",
                column: "ServiceProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_UserId",
                schema: "dbo",
                table: "Cart",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CartDetails_CartId",
                schema: "dbo",
                table: "CartDetails",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_CartDetails_Product_variantionId",
                schema: "dbo",
                table: "CartDetails",
                column: "Product_variantionId");

            migrationBuilder.CreateIndex(
                name: "IX_CartDetails_ProductId",
                schema: "dbo",
                table: "CartDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_CartDetails_ServiceProviderId",
                schema: "dbo",
                table: "CartDetails",
                column: "ServiceProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_CartDetails_UserId",
                schema: "dbo",
                table: "CartDetails",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ComplainantPic_ComplainantToPartyId",
                table: "ComplainantPic",
                column: "ComplainantToPartyId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsultationRequest_FarmerId",
                table: "ConsultationRequest",
                column: "FarmerId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsultationRequest_ServiceProviderId",
                table: "ConsultationRequest",
                column: "ServiceProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsultationRequestPic_ConsultationRequestId",
                table: "ConsultationRequestPic",
                column: "ConsultationRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Directorate_CityId",
                schema: "dbo",
                table: "Directorate",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Farmer_ServiceProviderId",
                schema: "dbo",
                table: "Farmer",
                column: "ServiceProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_MainClassification_ActivityTypeId",
                schema: "dbo",
                table: "MainClassification",
                column: "ActivityTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_News_MarketsId",
                schema: "dbo",
                table: "News",
                column: "MarketsId");

            migrationBuilder.CreateIndex(
                name: "IX_Offer_ProductId",
                schema: "dbo",
                table: "Offer",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Offer_serviceProviderId",
                schema: "dbo",
                table: "Offer",
                column: "serviceProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_OfficialParty_ServiceProviderId",
                schema: "dbo",
                table: "OfficialParty",
                column: "ServiceProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_CartId",
                schema: "dbo",
                table: "Order",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_ServiceProviderId",
                schema: "dbo",
                table: "Order",
                column: "ServiceProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_UserId",
                schema: "dbo",
                table: "Order",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                schema: "dbo",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_Product_variantionId",
                schema: "dbo",
                table: "OrderDetails",
                column: "Product_variantionId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductId",
                schema: "dbo",
                table: "OrderDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ServiceProviderId",
                schema: "dbo",
                table: "OrderDetails",
                column: "ServiceProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_UserId",
                schema: "dbo",
                table: "OrderDetails",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ActivityTypeId",
                schema: "dbo",
                table: "Product",
                column: "ActivityTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_AdditionalSectionsId",
                schema: "dbo",
                table: "Product",
                column: "AdditionalSectionsId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_BrandId",
                schema: "dbo",
                table: "Product",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_MainClassificationId",
                schema: "dbo",
                table: "Product",
                column: "MainClassificationId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ServiceProviderId",
                schema: "dbo",
                table: "Product",
                column: "ServiceProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_SpecialSectionsId",
                schema: "dbo",
                table: "Product",
                column: "SpecialSectionsId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_UserId",
                schema: "dbo",
                table: "Product",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_AdditionalDetails_ProductId",
                table: "Product_AdditionalDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Colors_ColorId",
                table: "Product_Colors",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Colors_ProductId",
                table: "Product_Colors",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Image_ProductId",
                table: "Product_Image",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Unit_ProductId",
                table: "Product_Unit",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Unit_UnitId",
                table: "Product_Unit",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_User_Favourites_ProductId",
                table: "Product_User_Favourites",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_User_Favourites_UserId",
                table: "Product_User_Favourites",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Variant_Attribute_Product_AttributeId",
                table: "Product_Variant_Attribute",
                column: "Product_AttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Variant_Attribute_ProductId",
                table: "Product_Variant_Attribute",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_variantion_ProductId",
                table: "Product_variantion",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductEvaluaton_ProductId",
                table: "ProductEvaluaton",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductEvaluaton_UserId",
                table: "ProductEvaluaton",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProviderEvaluation_ServiceProviderId",
                table: "ProviderEvaluation",
                column: "ServiceProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_ProviderEvaluation_UserId",
                table: "ProviderEvaluation",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceProvider_ActivityTypeId",
                schema: "dbo",
                table: "ServiceProvider",
                column: "ActivityTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceProvider_ServiceTypeId",
                schema: "dbo",
                table: "ServiceProvider",
                column: "ServiceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceProvider_UserId",
                schema: "dbo",
                table: "ServiceProvider",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "Uq_PhoneNumberServiceProvIder",
                schema: "dbo",
                table: "ServiceProvider",
                column: "PhoneNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Uq_TradeNameServiceProvIder",
                schema: "dbo",
                table: "ServiceProvider",
                column: "TradeName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Slider_ServiceProviderId",
                schema: "dbo",
                table: "Slider",
                column: "ServiceProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_SliderImages_SliderId",
                schema: "dbo",
                table: "SliderImages",
                column: "SliderId");

            migrationBuilder.CreateIndex(
                name: "IX_SP_AdditionalSections_AdditionalSectionsId",
                schema: "dbo",
                table: "SP_AdditionalSections",
                column: "AdditionalSectionsId");

            migrationBuilder.CreateIndex(
                name: "IX_SP_AdditionalSections_ServiceProviderId",
                schema: "dbo",
                table: "SP_AdditionalSections",
                column: "ServiceProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_SP_MainClassification_MainClassificationId",
                schema: "dbo",
                table: "SP_MainClassification",
                column: "MainClassificationId");

            migrationBuilder.CreateIndex(
                name: "IX_SP_MainClassification_ServiceProviderId",
                schema: "dbo",
                table: "SP_MainClassification",
                column: "ServiceProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_SP_ProFeatures_ProFeaturesId",
                schema: "dbo",
                table: "SP_ProFeatures",
                column: "ProFeaturesId");

            migrationBuilder.CreateIndex(
                name: "IX_SP_ProFeatures_ServiceProviderId",
                schema: "dbo",
                table: "SP_ProFeatures",
                column: "ServiceProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_SP_User_Favourites_ServiceProviderId",
                table: "SP_User_Favourites",
                column: "ServiceProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_SP_User_Favourites_UserId",
                table: "SP_User_Favourites",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialSections_AdditionalSectionsId",
                schema: "dbo",
                table: "SpecialSections",
                column: "AdditionalSectionsId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialSections_MainClassificationId",
                schema: "dbo",
                table: "SpecialSections",
                column: "MainClassificationId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialSections_ParnetSectionId",
                schema: "dbo",
                table: "SpecialSections",
                column: "ParnetSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialSections_ServiceProviderId",
                schema: "dbo",
                table: "SpecialSections",
                column: "ServiceProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_SupportRequest_FarmerId",
                schema: "dbo",
                table: "SupportRequest",
                column: "FarmerId");

            migrationBuilder.CreateIndex(
                name: "IX_SupportRequest_OfficialPartyId",
                schema: "dbo",
                table: "SupportRequest",
                column: "OfficialPartyId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Bank_BanksId",
                table: "User_Bank",
                column: "BanksId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Bank_UserId",
                table: "User_Bank",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkingHours_ServiceProviderId",
                table: "WorkingHours",
                column: "ServiceProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkingHours_WeekdaysId",
                table: "WorkingHours",
                column: "WeekdaysId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkingHours_WorkinPoeriodsId",
                table: "WorkingHours",
                column: "WorkinPoeriodsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BusinessCommercial",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CartDetails",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CheckOut",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ComplainantPic");

            migrationBuilder.DropTable(
                name: "ConsultationRequestPic");

            migrationBuilder.DropTable(
                name: "Currency",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "News",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Offer",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "OrderDetails",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Product_AdditionalDetails");

            migrationBuilder.DropTable(
                name: "Product_Colors");

            migrationBuilder.DropTable(
                name: "Product_Image");

            migrationBuilder.DropTable(
                name: "Product_Unit");

            migrationBuilder.DropTable(
                name: "Product_User_Favourites");

            migrationBuilder.DropTable(
                name: "Product_Variant_Attribute");

            migrationBuilder.DropTable(
                name: "ProductEvaluaton");

            migrationBuilder.DropTable(
                name: "ProviderEvaluation");

            migrationBuilder.DropTable(
                name: "SliderImages",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "SP_AdditionalSections",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "SP_MainClassification",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "SP_ProFeatures",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "SP_User_Favourites");

            migrationBuilder.DropTable(
                name: "SupportRequest",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "User_Bank");

            migrationBuilder.DropTable(
                name: "WorkingHours");

            migrationBuilder.DropTable(
                name: "Directorate",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AspNetRoles",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ComplainantToParty",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ConsultationRequest");

            migrationBuilder.DropTable(
                name: "Markets",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Order",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Product_variantion");

            migrationBuilder.DropTable(
                name: "Color",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Unit",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Product_Attribute",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Slider",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ProFeatures",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "OfficialParty",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Banks",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Weekdays");

            migrationBuilder.DropTable(
                name: "WorkinPoeriods");

            migrationBuilder.DropTable(
                name: "City",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Farmer",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Cart",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Product",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Brand",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "SpecialSections",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ManufactureCompany",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AdditionalSections",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ServiceProvider",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "MainClassification",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ServicesType",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AspNetUsers",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ActivityType",
                schema: "dbo");
        }
    }
}
