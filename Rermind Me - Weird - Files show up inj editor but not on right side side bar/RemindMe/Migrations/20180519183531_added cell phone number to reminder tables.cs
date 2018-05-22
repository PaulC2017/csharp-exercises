using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RemindMe.Migrations
{
    public partial class addedcellphonenumbertoremindertables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserCellPhoneNumber",
                table: "RecurringReminders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserCellPhoneNumber",
                table: "NonRecurringReminders",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserCellPhoneNumber",
                table: "RecurringReminders");

            migrationBuilder.DropColumn(
                name: "UserCellPhoneNumber",
                table: "NonRecurringReminders");
        }
    }
}
