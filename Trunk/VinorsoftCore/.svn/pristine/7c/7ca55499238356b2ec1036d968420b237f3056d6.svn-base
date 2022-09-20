using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Vinorsoft.Core.VDbContext.Migrations.VEventDb
{
    public partial class VEventDbContextV7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sys_VEvents",
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
                    Type = table.Column<string>(nullable: false),
                    DataJson = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    RefId = table.Column<Guid>(nullable: true),
                    RefId1 = table.Column<Guid>(nullable: true),
                    RefId2 = table.Column<Guid>(nullable: true),
                    RefId3 = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sys_VEvents", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sys_VEvents");
        }
    }
}
