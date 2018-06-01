using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RemindMe.Migrations
{
    public partial class addedDateAndTimeLAstAlertSenttoremindertables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "RecurringReminderDateAndTimeLastAlertSent",
                table: "RecurringReminders",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NonRecurringReminderDateAndTimeLastAlertSent",
                table: "NonRecurringReminders",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RecurringReminderDateAndTimeLastAlertSent",
                table: "RecurringReminders");

            migrationBuilder.DropColumn(
                name: "NonRecurringReminderDateAndTimeLastAlertSent",
                table: "NonRecurringReminders");
        }
    }
}
