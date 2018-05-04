using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RemindMe.Migrations
{
    public partial class Afterremovingonetomany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_RecurringReminders_RecurringReminderNameID",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_RecurringReminderNameID",
                table: "User");

            migrationBuilder.DropColumn(
                name: "RecurringReminderNameID",
                table: "User");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "RecurringReminders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "EventTypesRecurring",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_RecurringReminders_UserId",
                table: "RecurringReminders",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EventTypesRecurring_UserId",
                table: "EventTypesRecurring",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventTypesRecurring_User_UserId",
                table: "EventTypesRecurring",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecurringReminders_User_UserId",
                table: "RecurringReminders",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventTypesRecurring_User_UserId",
                table: "EventTypesRecurring");

            migrationBuilder.DropForeignKey(
                name: "FK_RecurringReminders_User_UserId",
                table: "RecurringReminders");

            migrationBuilder.DropIndex(
                name: "IX_RecurringReminders_UserId",
                table: "RecurringReminders");

            migrationBuilder.DropIndex(
                name: "IX_EventTypesRecurring_UserId",
                table: "EventTypesRecurring");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "RecurringReminders");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "EventTypesRecurring");

            migrationBuilder.AddColumn<int>(
                name: "RecurringReminderNameID",
                table: "User",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_RecurringReminderNameID",
                table: "User",
                column: "RecurringReminderNameID");

            migrationBuilder.AddForeignKey(
                name: "FK_User_RecurringReminders_RecurringReminderNameID",
                table: "User",
                column: "RecurringReminderNameID",
                principalTable: "RecurringReminders",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
