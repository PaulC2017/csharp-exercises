using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RemindMe.Migrations
{
    public partial class _512018Versionofdatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NonRecurringEvents",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NonRecuringEventCreateDate = table.Column<string>(nullable: true),
                    NonRecurringEventDescription = table.Column<string>(nullable: true),
                    NonRecurringEventName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NonRecurringEvents", x => x.ID);
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
                    NonRecurringReminderStartAlertDate = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NonRecurringReminders", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "RecurringEvents",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RecuringEventCreateDate = table.Column<string>(nullable: true),
                    RecurringEventDescription = table.Column<string>(nullable: true),
                    RecurringEventName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecurringEvents", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(nullable: true),
                    GCalEmail = table.Column<string>(nullable: true),
                    GCalEmailPassword = table.Column<string>(nullable: true),
                    NonRecurringEventsId = table.Column<int>(nullable: false),
                    NonRecurringReminderId = table.Column<int>(nullable: false),
                    NonRecurringReminderNameID = table.Column<int>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    RecurringEventsId = table.Column<int>(nullable: false),
                    RecurringReminderId = table.Column<int>(nullable: false),
                    UserCreateDate = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.ID);
                    table.ForeignKey(
                        name: "FK_User_NonRecurringEvents_NonRecurringEventsId",
                        column: x => x.NonRecurringEventsId,
                        principalTable: "NonRecurringEvents",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_NonRecurringReminders_NonRecurringReminderNameID",
                        column: x => x.NonRecurringReminderNameID,
                        principalTable: "NonRecurringReminders",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_RecurringEvents_RecurringEventsId",
                        column: x => x.RecurringEventsId,
                        principalTable: "RecurringEvents",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.CreateTable(
                name: "UserNonRecurringEvents",
                columns: table => new
                {
                    NonRecurringEventsID = table.Column<int>(nullable: false),
                    UserID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserNonRecurringEvents", x => new { x.NonRecurringEventsID, x.UserID });
                    table.ForeignKey(
                        name: "FK_UserNonRecurringEvents_NonRecurringEvents_NonRecurringEventsID",
                        column: x => x.NonRecurringEventsID,
                        principalTable: "NonRecurringEvents",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserNonRecurringEvents_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserNonRecurringReminders",
                columns: table => new
                {
                    NonRecurringRemindersID = table.Column<int>(nullable: false),
                    UserID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserNonRecurringReminders", x => new { x.NonRecurringRemindersID, x.UserID });
                    table.ForeignKey(
                        name: "FK_UserNonRecurringReminders_NonRecurringReminders_NonRecurringRemindersID",
                        column: x => x.NonRecurringRemindersID,
                        principalTable: "NonRecurringReminders",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserNonRecurringReminders_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRecurringEvents",
                columns: table => new
                {
                    RecurringEventsID = table.Column<int>(nullable: false),
                    UserID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRecurringEvents", x => new { x.RecurringEventsID, x.UserID });
                    table.ForeignKey(
                        name: "FK_UserRecurringEvents_RecurringEvents_RecurringEventsID",
                        column: x => x.RecurringEventsID,
                        principalTable: "RecurringEvents",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRecurringEvents_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRecurringReminders",
                columns: table => new
                {
                    RecurringRemindersID = table.Column<int>(nullable: false),
                    UserID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRecurringReminders", x => new { x.RecurringRemindersID, x.UserID });
                    table.ForeignKey(
                        name: "FK_UserRecurringReminders_RecurringReminders_RecurringRemindersID",
                        column: x => x.RecurringRemindersID,
                        principalTable: "RecurringReminders",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRecurringReminders_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RecurringReminders_UserId",
                table: "RecurringReminders",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_NonRecurringEventsId",
                table: "User",
                column: "NonRecurringEventsId");

            migrationBuilder.CreateIndex(
                name: "IX_User_NonRecurringReminderNameID",
                table: "User",
                column: "NonRecurringReminderNameID");

            migrationBuilder.CreateIndex(
                name: "IX_User_RecurringEventsId",
                table: "User",
                column: "RecurringEventsId");

            migrationBuilder.CreateIndex(
                name: "IX_UserNonRecurringEvents_UserID",
                table: "UserNonRecurringEvents",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_UserNonRecurringReminders_UserID",
                table: "UserNonRecurringReminders",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_UserRecurringEvents_UserID",
                table: "UserRecurringEvents",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_UserRecurringReminders_UserID",
                table: "UserRecurringReminders",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserNonRecurringEvents");

            migrationBuilder.DropTable(
                name: "UserNonRecurringReminders");

            migrationBuilder.DropTable(
                name: "UserRecurringEvents");

            migrationBuilder.DropTable(
                name: "UserRecurringReminders");

            migrationBuilder.DropTable(
                name: "RecurringReminders");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "NonRecurringEvents");

            migrationBuilder.DropTable(
                name: "NonRecurringReminders");

            migrationBuilder.DropTable(
                name: "RecurringEvents");
        }
    }
}
