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
                name: "EventTypesNonRecurring",
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
                    table.PrimaryKey("PK_EventTypesNonRecurring", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "EventTypesRecurring",
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
                    table.PrimaryKey("PK_EventTypesRecurring", x => x.ID);
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
                    RecurringReminderStartAlertDate = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecurringReminders", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(nullable: true),
                    EventTypesNonRecurringID = table.Column<int>(nullable: true),
                    EventTypesRecurringID = table.Column<int>(nullable: true),
                    GCalEmail = table.Column<string>(nullable: true),
                    GCalEmailPassword = table.Column<string>(nullable: true),
                    NonRecurringReminderId = table.Column<int>(nullable: false),
                    NonRecurringReminderNameID = table.Column<int>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    RecurringReminderId = table.Column<int>(nullable: false),
                    RecurringReminderNameID = table.Column<int>(nullable: true),
                    UserCreateDate = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_User_EventTypesNonRecurring_EventTypesNonRecurringID",
                        column: x => x.EventTypesNonRecurringID,
                        principalTable: "EventTypesNonRecurring",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_EventTypesRecurring_EventTypesRecurringID",
                        column: x => x.EventTypesRecurringID,
                        principalTable: "EventTypesRecurring",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_NonRecurringReminders_NonRecurringReminderNameID",
                        column: x => x.NonRecurringReminderNameID,
                        principalTable: "NonRecurringReminders",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_RecurringReminders_RecurringReminderNameID",
                        column: x => x.RecurringReminderNameID,
                        principalTable: "RecurringReminders",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserEventTypesNonRecurring",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    NonRecurringEventId = table.Column<int>(nullable: false),
                    EventTypesNonRecurringID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEventTypesNonRecurring", x => new { x.UserId, x.NonRecurringEventId });
                    table.ForeignKey(
                        name: "FK_UserEventTypesNonRecurring_EventTypesNonRecurring_EventTypesNonRecurringID",
                        column: x => x.EventTypesNonRecurringID,
                        principalTable: "EventTypesNonRecurring",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserEventTypesNonRecurring_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserEventTypesRecurring",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    RecurringEventId = table.Column<int>(nullable: false),
                    EventTypesRecurringID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEventTypesRecurring", x => new { x.UserId, x.RecurringEventId });
                    table.ForeignKey(
                        name: "FK_UserEventTypesRecurring_EventTypesNonRecurring_EventTypesRecurringID",
                        column: x => x.EventTypesRecurringID,
                        principalTable: "EventTypesNonRecurring",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserEventTypesRecurring_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_EventTypesNonRecurringID",
                table: "User",
                column: "EventTypesNonRecurringID");

            migrationBuilder.CreateIndex(
                name: "IX_User_EventTypesRecurringID",
                table: "User",
                column: "EventTypesRecurringID");

            migrationBuilder.CreateIndex(
                name: "IX_User_NonRecurringReminderNameID",
                table: "User",
                column: "NonRecurringReminderNameID");

            migrationBuilder.CreateIndex(
                name: "IX_User_RecurringReminderNameID",
                table: "User",
                column: "RecurringReminderNameID");

            migrationBuilder.CreateIndex(
                name: "IX_UserEventTypesNonRecurring_EventTypesNonRecurringID",
                table: "UserEventTypesNonRecurring",
                column: "EventTypesNonRecurringID");

            migrationBuilder.CreateIndex(
                name: "IX_UserEventTypesRecurring_EventTypesRecurringID",
                table: "UserEventTypesRecurring",
                column: "EventTypesRecurringID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserEventTypesNonRecurring");

            migrationBuilder.DropTable(
                name: "UserEventTypesRecurring");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "EventTypesNonRecurring");

            migrationBuilder.DropTable(
                name: "EventTypesRecurring");

            migrationBuilder.DropTable(
                name: "NonRecurringReminders");

            migrationBuilder.DropTable(
                name: "RecurringReminders");
        }
    }
}
