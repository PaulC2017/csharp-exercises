using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RemindMe.Migrations
{
    public partial class changeddatatypesinmodelsandviewmodels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RecuringReminderAlertFrequency",
                table: "RecurringReminders");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RecurringReminderStartAlertDate",
                table: "RecurringReminders",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "RecurringReminderLastAlertDate",
                table: "RecurringReminders",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "RecurringEventDate",
                table: "RecurringReminders",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "RecurringEventDate",
                table: "RecurringEvents",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "NonRecurringReminderStartAlertDate",
                table: "NonRecurringReminders",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "NonRecurringReminderLastAlertDate",
                table: "NonRecurringReminders",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NonRecurringEventDate",
                table: "NonRecurringReminders",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "NonRecurringEventTime",
                table: "NonRecurringReminders",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NonRecurringEventDate",
                table: "NonRecurringReminders");

            migrationBuilder.DropColumn(
                name: "NonRecurringEventTime",
                table: "NonRecurringReminders");

            migrationBuilder.AlterColumn<string>(
                name: "RecurringReminderStartAlertDate",
                table: "RecurringReminders",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<string>(
                name: "RecurringReminderLastAlertDate",
                table: "RecurringReminders",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<string>(
                name: "RecurringEventDate",
                table: "RecurringReminders",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddColumn<string>(
                name: "RecuringReminderAlertFrequency",
                table: "RecurringReminders",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RecurringEventDate",
                table: "RecurringEvents",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<string>(
                name: "NonRecurringReminderStartAlertDate",
                table: "NonRecurringReminders",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<string>(
                name: "NonRecurringReminderLastAlertDate",
                table: "NonRecurringReminders",
                nullable: true,
                oldClrType: typeof(DateTime));
        }
    }
}
