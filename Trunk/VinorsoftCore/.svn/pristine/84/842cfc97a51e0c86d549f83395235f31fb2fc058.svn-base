using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Vinorsoft.Core.VDbContext.Migrations
{
    public partial class AuthDbContextV7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sys_Permissions",
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
                    table.PrimaryKey("PK_Sys_Permissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sys_PermitObjects",
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
                    ControllerNames = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sys_PermitObjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sys_UserGroups",
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
                    table.PrimaryKey("PK_Sys_UserGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sys_Users",
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
                    Username = table.Column<string>(maxLength: 128, nullable: false),
                    Password = table.Column<string>(maxLength: 4000, nullable: false),
                    Locked = table.Column<bool>(nullable: false),
                    FailedCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 1000, nullable: true),
                    LastName = table.Column<string>(maxLength: 1000, nullable: true),
                    Phone = table.Column<string>(maxLength: 1000, nullable: true),
                    Email = table.Column<string>(maxLength: 1000, nullable: true),
                    LockedEnd = table.Column<DateTime>(nullable: true),
                    ProfileId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sys_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sys_PermitObjectSidebars",
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
                    PermitObjectId = table.Column<Guid>(nullable: false),
                    SidebarMenuIds = table.Column<string>(nullable: true),
                    ModuleId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sys_PermitObjectSidebars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sys_PermitObjectSidebars_Sys_PermitObjects_PermitObjectId",
                        column: x => x.PermitObjectId,
                        principalTable: "Sys_PermitObjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sys_PermitObjectPermissions",
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
                    PermitObjectId = table.Column<Guid>(nullable: false),
                    PermissionId = table.Column<Guid>(nullable: false),
                    GroupId = table.Column<Guid>(nullable: true),
                    UserId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sys_PermitObjectPermissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sys_PermitObjectPermissions_Sys_UserGroups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Sys_UserGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sys_PermitObjectPermissions_Sys_Permissions_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Sys_Permissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sys_PermitObjectPermissions_Sys_PermitObjects_PermitObjectId",
                        column: x => x.PermitObjectId,
                        principalTable: "Sys_PermitObjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sys_PermitObjectPermissions_Sys_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Sys_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sys_UserInGroups",
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
                    UserId = table.Column<Guid>(nullable: false),
                    GroupId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sys_UserInGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sys_UserInGroups_Sys_UserGroups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Sys_UserGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sys_UserInGroups_Sys_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Sys_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sys_PermitObjectPermissions_GroupId",
                table: "Sys_PermitObjectPermissions",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Sys_PermitObjectPermissions_PermissionId",
                table: "Sys_PermitObjectPermissions",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_Sys_PermitObjectPermissions_PermitObjectId",
                table: "Sys_PermitObjectPermissions",
                column: "PermitObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Sys_PermitObjectPermissions_UserId",
                table: "Sys_PermitObjectPermissions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Sys_PermitObjectSidebars_PermitObjectId",
                table: "Sys_PermitObjectSidebars",
                column: "PermitObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Sys_UserInGroups_GroupId",
                table: "Sys_UserInGroups",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Sys_UserInGroups_UserId",
                table: "Sys_UserInGroups",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sys_PermitObjectPermissions");

            migrationBuilder.DropTable(
                name: "Sys_PermitObjectSidebars");

            migrationBuilder.DropTable(
                name: "Sys_UserInGroups");

            migrationBuilder.DropTable(
                name: "Sys_Permissions");

            migrationBuilder.DropTable(
                name: "Sys_PermitObjects");

            migrationBuilder.DropTable(
                name: "Sys_UserGroups");

            migrationBuilder.DropTable(
                name: "Sys_Users");
        }
    }
}
