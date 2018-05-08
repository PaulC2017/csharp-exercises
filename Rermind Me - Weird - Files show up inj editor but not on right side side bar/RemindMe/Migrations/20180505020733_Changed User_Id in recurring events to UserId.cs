using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RemindMe.Migrations
{
    public partial class ChangedUser_IdinrecurringeventstoUserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecurringEvents_User_UserID",
                table: "RecurringEvents");

            migrationBuilder.DropColumn(
                name: "User_Id",
                table: "RecurringEvents");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "RecurringEvents",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_RecurringEvents_UserID",
                table: "RecurringEvents",
                newName: "IX_RecurringEvents_UserId");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "RecurringEvents",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RecurringEvents_User_UserId",
                table: "RecurringEvents",
                column: "UserId",
                principalTable: "User",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecurringEvents_User_UserId",
                table: "RecurringEvents");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "RecurringEvents",
                newName: "UserID");

            migrationBuilder.RenameIndex(
                name: "IX_RecurringEvents_UserId",
                table: "RecurringEvents",
                newName: "IX_RecurringEvents_UserID");

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "RecurringEvents",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "User_Id",
                table: "RecurringEvents",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_RecurringEvents_User_UserID",
                table: "RecurringEvents",
                column: "UserID",
                principalTable: "User",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
