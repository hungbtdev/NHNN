using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Vinorsoft.Core.VDbContext.Migrations.ProfileDb
{
    public partial class ProfileDbContextV7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Prf_Countries",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 255, nullable: true),
                    UpdatedBy = table.Column<string>(maxLength: 255, nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    TenantId = table.Column<Guid>(nullable: true),
                    Code = table.Column<string>(maxLength: 255, nullable: false),
                    Name = table.Column<string>(maxLength: 4000, nullable: false),
                    Description = table.Column<string>(maxLength: 4000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prf_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Prf_GeoAreas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 255, nullable: true),
                    UpdatedBy = table.Column<string>(maxLength: 255, nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    TenantId = table.Column<Guid>(nullable: true),
                    Code = table.Column<string>(maxLength: 255, nullable: false),
                    Name = table.Column<string>(maxLength: 4000, nullable: false),
                    Description = table.Column<string>(maxLength: 4000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prf_GeoAreas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Prf_Cities",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 255, nullable: true),
                    UpdatedBy = table.Column<string>(maxLength: 255, nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    TenantId = table.Column<Guid>(nullable: true),
                    Code = table.Column<string>(maxLength: 255, nullable: false),
                    Name = table.Column<string>(maxLength: 4000, nullable: false),
                    Description = table.Column<string>(maxLength: 4000, nullable: true),
                    CountryId = table.Column<Guid>(nullable: false),
                    GeoAreaId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prf_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prf_Cities_Prf_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Prf_Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prf_Cities_Prf_GeoAreas_GeoAreaId",
                        column: x => x.GeoAreaId,
                        principalTable: "Prf_GeoAreas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Prf_Districts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 255, nullable: true),
                    UpdatedBy = table.Column<string>(maxLength: 255, nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    TenantId = table.Column<Guid>(nullable: true),
                    Code = table.Column<string>(maxLength: 255, nullable: false),
                    Name = table.Column<string>(maxLength: 4000, nullable: false),
                    Description = table.Column<string>(maxLength: 4000, nullable: true),
                    CityId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prf_Districts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prf_Districts_Prf_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Prf_Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prf_Wards",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 255, nullable: true),
                    UpdatedBy = table.Column<string>(maxLength: 255, nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    TenantId = table.Column<Guid>(nullable: true),
                    Code = table.Column<string>(maxLength: 255, nullable: false),
                    Name = table.Column<string>(maxLength: 4000, nullable: false),
                    Description = table.Column<string>(maxLength: 4000, nullable: true),
                    DistrictId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prf_Wards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prf_Wards_Prf_Districts_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "Prf_Districts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prf_Profiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 255, nullable: true),
                    UpdatedBy = table.Column<string>(maxLength: 255, nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    TenantId = table.Column<Guid>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    WardId = table.Column<Guid>(nullable: true),
                    DistrictId = table.Column<Guid>(nullable: true),
                    CityId = table.Column<Guid>(nullable: true),
                    CountryId = table.Column<Guid>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    GeoAreaId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prf_Profiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prf_Profiles_Prf_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Prf_Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Prf_Profiles_Prf_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Prf_Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Prf_Profiles_Prf_Districts_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "Prf_Districts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Prf_Profiles_Prf_GeoAreas_GeoAreaId",
                        column: x => x.GeoAreaId,
                        principalTable: "Prf_GeoAreas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Prf_Profiles_Prf_Wards_WardId",
                        column: x => x.WardId,
                        principalTable: "Prf_Wards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prf_Cities_CountryId",
                table: "Prf_Cities",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Prf_Cities_GeoAreaId",
                table: "Prf_Cities",
                column: "GeoAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Prf_Districts_CityId",
                table: "Prf_Districts",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Prf_Profiles_CityId",
                table: "Prf_Profiles",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Prf_Profiles_CountryId",
                table: "Prf_Profiles",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Prf_Profiles_DistrictId",
                table: "Prf_Profiles",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Prf_Profiles_GeoAreaId",
                table: "Prf_Profiles",
                column: "GeoAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Prf_Profiles_WardId",
                table: "Prf_Profiles",
                column: "WardId");

            migrationBuilder.CreateIndex(
                name: "IX_Prf_Wards_DistrictId",
                table: "Prf_Wards",
                column: "DistrictId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prf_Profiles");

            migrationBuilder.DropTable(
                name: "Prf_Wards");

            migrationBuilder.DropTable(
                name: "Prf_Districts");

            migrationBuilder.DropTable(
                name: "Prf_Cities");

            migrationBuilder.DropTable(
                name: "Prf_Countries");

            migrationBuilder.DropTable(
                name: "Prf_GeoAreas");
        }
    }
}
