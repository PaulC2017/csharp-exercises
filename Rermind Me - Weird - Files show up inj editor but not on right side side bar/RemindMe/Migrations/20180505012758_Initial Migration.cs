using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RemindMe.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(nullable: true),
                    GCalEmail = table.Column<string>(nullable: true),
                    GCalEmailPassword = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    UserCreateDate = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "NonRecurringEvents",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NonRecuringEventCreateDate = table.Column<string>(nullable: true),
                    NonRecurringEventDescription = table.Column<string>(nullable: true),
                    NonRecurringEventName = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NonRecurringEvents", x => x.ID);
                    table.ForeignKey(
                        name: "FK_NonRecurringEvents_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NonRecurringReminders",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NonRecuringReminderAlertFrequency = table.Column<string>(nullable: true),
                    NonRecuringReminderCreateDate = table.Column<string>(nullable: true),
                    NonRecurringReminderDescription = table.Column<string>(nullable: true),
                    NonRecurringReminderFirstAlertTime = table.Column<string>(nullable: true),
                    NonRecurringReminderLastAlertDate = table.Column<string>(nullable: true),
                    NonRecurringReminderName = table.Column<string>(nullable: true),
                    NonRecurringReminderSecondAlertTime = table.Column<string>(nullable: true),
                    NonRecurringReminderStartAlertDate = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NonRecurringReminders", x => x.ID);
                    table.ForeignKey(
                        name: "FK_NonRecurringReminders_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecurringEvents",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RecuringEventCreateDate = table.Column<string>(nullable: true),
                    RecurringEventDescription = table.Column<string>(nullable: true),
                    RecurringEventName = table.Column<string>(nullable: true),
                    UserID = table.Column<int>(nullable: true),
                    User_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecurringEvents", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RecurringEvents_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RecurringReminders",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RecuringReminderAlertFrequency = table.Column<string>(nullable: true),
                    RecuringReminderCreateDate = table.Column<string>(nullable: true),
                    RecurringReminderDescription = table.Column<string>(nullable: true),
                    RecurringReminderFirstAlertTime = table.Column<string>(nullable: true),
                    RecurringReminderLastAlertDate = table.Column<string>(nullable: true),
                    RecurringReminderName = table.Column<string>(nullable: true),
                    RecurringReminderRepeatFrequency = table.Column<string>(nullable: true),
                    RecurringReminderSecondAlertTime = table.Column<string>(nullable: true),
                    RecurringReminderStartAlertDate = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecurringReminders", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RecurringReminders_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NonRecurringEvents_UserId",
                table: "NonRecurringEvents",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_NonRecurringReminders_UserId",
                table: "NonRecurringReminders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RecurringEvents_UserID",
                table: "RecurringEvents",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_RecurringReminders_UserId",
                table: "RecurringReminders",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NonRecurringEvents");

            migrationBuilder.DropTable(
                name: "NonRecurringReminders");

            migrationBuilder.DropTable(
                name: "RecurringEvents");

            migrationBuilder.DropTable(
                name: "RecurringReminders");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
