using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Vinorsoft.Core.VDbContext.Migrations.NotificationDb
{
    public partial class NotificationDbContextV7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Noti_BaseTemplates",
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
                    Code = table.Column<string>(nullable: true),
                    Subject = table.Column<string>(nullable: true),
                    Body = table.Column<string>(nullable: true),
                    AppName = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Noti_BaseTemplates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Noti_DeviceTokens",
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
                    IsDevice = table.Column<bool>(nullable: false),
                    Brand = table.Column<string>(nullable: true),
                    Manufacturer = table.Column<string>(nullable: true),
                    ModelName = table.Column<string>(nullable: true),
                    OsName = table.Column<string>(nullable: true),
                    OsVersion = table.Column<string>(nullable: true),
                    DeviceName = table.Column<string>(nullable: true),
                    RefId = table.Column<Guid>(nullable: true),
                    ExpoPushToken = table.Column<string>(nullable: true),
                    FCMToken = table.Column<string>(nullable: true),
                    AppName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Noti_DeviceTokens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Noti_NotificationMessages",
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
                    Subject = table.Column<string>(nullable: true),
                    Body = table.Column<string>(nullable: true),
                    AppName = table.Column<string>(nullable: true),
                    ReadStatus = table.Column<int>(nullable: false),
                    SendStatus = table.Column<int>(nullable: false),
                    NotificationType = table.Column<int>(nullable: false),
                    Recipient = table.Column<string>(nullable: true),
                    JsonData = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Noti_NotificationMessages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Noti_SendLogs",
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
                    NotificationMessageId = table.Column<Guid>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: true),
                    EndDate = table.Column<DateTime>(nullable: true),
                    Success = table.Column<bool>(nullable: false),
                    Error = table.Column<string>(nullable: true),
                    From = table.Column<string>(nullable: true),
                    To = table.Column<string>(nullable: true),
                    NotificationMessagesId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Noti_SendLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Noti_SendLogs_Noti_NotificationMessages_NotificationMessagesId",
                        column: x => x.NotificationMessagesId,
                        principalTable: "Noti_NotificationMessages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Noti_SendLogs_NotificationMessagesId",
                table: "Noti_SendLogs",
                column: "NotificationMessagesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Noti_BaseTemplates");

            migrationBuilder.DropTable(
                name: "Noti_DeviceTokens");

            migrationBuilder.DropTable(
                name: "Noti_SendLogs");

            migrationBuilder.DropTable(
                name: "Noti_NotificationMessages");
        }
    }
}
