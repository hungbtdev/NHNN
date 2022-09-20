using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Vinorsoft.Core.VDbContext.Migrations.CoreUploadDb
{
    public partial class CoreUploadDbContextV7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sys_CoreUploadFiles",
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
                    FileContent = table.Column<byte[]>(nullable: true),
                    FileExtension = table.Column<string>(nullable: true),
                    MimeType = table.Column<string>(nullable: true),
                    Link = table.Column<string>(nullable: true),
                    RefId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sys_CoreUploadFiles", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sys_CoreUploadFiles");
        }
    }
}
