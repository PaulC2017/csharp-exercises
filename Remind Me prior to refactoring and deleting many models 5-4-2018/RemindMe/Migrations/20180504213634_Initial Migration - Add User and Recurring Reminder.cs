using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RemindMe.Migrations
{
    public partial class InitialMigrationAddUserandRecurringReminder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_NonRecurringEvents_NonRecurringEventsId",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_NonRecurringReminders_NonRecurringReminderNameID",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_RecurringEvents_RecurringEventsId",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_UserNonRecurringEvents_NonRecurringEvents_NonRecurringEventsID",
                table: "UserNonRecurringEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_UserNonRecurringEvents_User_UserID",
                table: "UserNonRecurringEvents");

            migrationBuilder.DropTable(
                name: "UserNonRecurringReminders");

            migrationBuilder.DropTable(
                name: "UserRecurringEvents");

            migrationBuilder.DropTable(
                name: "UserRecurringReminders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserNonRecurringEvents",
                table: "UserNonRecurringEvents");

            migrationBuilder.DropIndex(
                name: "IX_User_NonRecurringEventsId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_RecurringReminders_UserId",
                table: "RecurringReminders");

            migrationBuilder.DropColumn(
                name: "NonRecurringEventsId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "NonRecurringReminderId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "RecurringReminderId",
                table: "User");

            migrationBuilder.RenameColumn(
                name: "RecurringEventsId",
                table: "User",
                newName: "RecurringEventsID");

            migrationBuilder.RenameColumn(
                name: "NonRecurringReminderNameID",
                table: "User",
                newName: "NonRecurringRemindersID");

            migrationBuilder.RenameIndex(
                name: "IX_User_RecurringEventsId",
                table: "User",
                newName: "IX_User_RecurringEventsID");

            migrationBuilder.RenameIndex(
                name: "IX_User_NonRecurringReminderNameID",
                table: "User",
                newName: "IX_User_NonRecurringRemindersID");

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "UserNonRecurringEvents",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "NonRecurringEventsID",
                table: "UserNonRecurringEvents",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "UserNonRecurringEvents",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<int>(
                name: "RecurringEventsID",
                table: "User",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserNonRecurringEvents",
                table: "UserNonRecurringEvents",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_UserNonRecurringEvents_NonRecurringEventsID",
                table: "UserNonRecurringEvents",
                column: "NonRecurringEventsID");

            migrationBuilder.CreateIndex(
                name: "IX_RecurringReminders_UserId",
                table: "RecurringReminders",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_NonRecurringReminders_NonRecurringRemindersID",
                table: "User",
                column: "NonRecurringRemindersID",
                principalTable: "NonRecurringReminders",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_RecurringEvents_RecurringEventsID",
                table: "User",
                column: "RecurringEventsID",
                principalTable: "RecurringEvents",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserNonRecurringEvents_NonRecurringEvents_NonRecurringEventsID",
                table: "UserNonRecurringEvents",
                column: "NonRecurringEventsID",
                principalTable: "NonRecurringEvents",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserNonRecurringEvents_User_UserID",
                table: "UserNonRecurringEvents",
                column: "UserID",
                principalTable: "User",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_NonRecurringReminders_NonRecurringRemindersID",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_RecurringEvents_RecurringEventsID",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_UserNonRecurringEvents_NonRecurringEvents_NonRecurringEventsID",
                table: "UserNonRecurringEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_UserNonRecurringEvents_User_UserID",
                table: "UserNonRecurringEvents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserNonRecurringEvents",
                table: "UserNonRecurringEvents");

            migrationBuilder.DropIndex(
                name: "IX_UserNonRecurringEvents_NonRecurringEventsID",
                table: "UserNonRecurringEvents");

            migrationBuilder.DropIndex(
                name: "IX_RecurringReminders_UserId",
                table: "RecurringReminders");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "UserNonRecurringEvents");

            migrationBuilder.RenameColumn(
                name: "RecurringEventsID",
                table: "User",
                newName: "RecurringEventsId");

            migrationBuilder.RenameColumn(
                name: "NonRecurringRemindersID",
                table: "User",
                newName: "NonRecurringReminderNameID");

            migrationBuilder.RenameIndex(
                name: "IX_User_RecurringEventsID",
                table: "User",
                newName: "IX_User_RecurringEventsId");

            migrationBuilder.RenameIndex(
                name: "IX_User_NonRecurringRemindersID",
                table: "User",
                newName: "IX_User_NonRecurringReminderNameID");

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "UserNonRecurringEvents",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "NonRecurringEventsID",
                table: "UserNonRecurringEvents",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RecurringEventsId",
                table: "User",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NonRecurringEventsId",
                table: "User",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NonRecurringReminderId",
                table: "User",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RecurringReminderId",
                table: "User",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserNonRecurringEvents",
                table: "UserNonRecurringEvents",
                columns: new[] { "NonRecurringEventsID", "UserID" });

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
                name: "IX_User_NonRecurringEventsId",
                table: "User",
                column: "NonRecurringEventsId");

            migrationBuilder.CreateIndex(
                name: "IX_RecurringReminders_UserId",
                table: "RecurringReminders",
                column: "UserId",
                unique: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_User_NonRecurringEvents_NonRecurringEventsId",
                table: "User",
                column: "NonRecurringEventsId",
                principalTable: "NonRecurringEvents",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_NonRecurringReminders_NonRecurringReminderNameID",
                table: "User",
                column: "NonRecurringReminderNameID",
                principalTable: "NonRecurringReminders",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_RecurringEvents_RecurringEventsId",
                table: "User",
                column: "RecurringEventsId",
                principalTable: "RecurringEvents",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserNonRecurringEvents_NonRecurringEvents_NonRecurringEventsID",
                table: "UserNonRecurringEvents",
                column: "NonRecurringEventsID",
                principalTable: "NonRecurringEvents",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserNonRecurringEvents_User_UserID",
                table: "UserNonRecurringEvents",
                column: "UserID",
                principalTable: "User",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
