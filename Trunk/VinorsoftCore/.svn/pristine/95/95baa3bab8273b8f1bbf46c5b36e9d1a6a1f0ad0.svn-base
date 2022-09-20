using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Vinorsoft.Core.VDbContext.Migrations.CoreConfigDb
{
    public partial class CoreConfigDbContextV7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Conf_CoreModules",
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
                    Position = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conf_CoreModules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Conf_CorePageTitles",
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
                    table.PrimaryKey("PK_Conf_CorePageTitles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Conf_CoreSystemConfigs",
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
                    Value = table.Column<string>(maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conf_CoreSystemConfigs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Conf_CoreSlidebarItems",
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
                    Position = table.Column<int>(nullable: true),
                    ParentId = table.Column<Guid>(nullable: true),
                    ModuleId = table.Column<Guid>(nullable: true),
                    Icon = table.Column<string>(maxLength: 255, nullable: true),
                    Url = table.Column<string>(maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conf_CoreSlidebarItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Conf_CoreSlidebarItems_Conf_CoreModules_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "Conf_CoreModules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Conf_CoreSlidebarItems_ModuleId",
                table: "Conf_CoreSlidebarItems",
                column: "ModuleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Conf_CorePageTitles");

            migrationBuilder.DropTable(
                name: "Conf_CoreSlidebarItems");

            migrationBuilder.DropTable(
                name: "Conf_CoreSystemConfigs");

            migrationBuilder.DropTable(
                name: "Conf_CoreModules");
        }
    }
}
