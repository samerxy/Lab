using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Labs.Migrations
{
    public partial class init005 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_dates_Time_TimeID",
                table: "dates");

            migrationBuilder.DropForeignKey(
                name: "FK_Ldts_dates_datesID",
                table: "Ldts");

            migrationBuilder.DropIndex(
                name: "IX_Ldts_datesID",
                table: "Ldts");

            migrationBuilder.DropIndex(
                name: "IX_dates_TimeID",
                table: "dates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Time",
                table: "Time");

            migrationBuilder.DropColumn(
                name: "DateID",
                table: "Ldts");

            migrationBuilder.DropColumn(
                name: "datesID",
                table: "Ldts");

            migrationBuilder.DropColumn(
                name: "TimeID",
                table: "dates");

            migrationBuilder.DropColumn(
                name: "isBooked",
                table: "Time");

            migrationBuilder.RenameTable(
                name: "Time",
                newName: "times");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Ldts",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "TimeID",
                table: "Ldts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DateID",
                table: "times",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "datesID",
                table: "times",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isAvailable",
                table: "times",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_times",
                table: "times",
                column: "TimeID");

            migrationBuilder.InsertData(
                table: "times",
                columns: new[] { "TimeID", "DateID", "datesID", "time" },
                values: new object[,]
                {
                    { 1, 1, null, "10:00am" },
                    { 2, 1, null, "11:00am" },
                    { 3, 1, null, "12:00pm" },
                    { 4, 1, null, "01:00pm" },
                    { 5, 1, null, "02:00pm" },
                    { 6, 1, null, "03:00pm" },
                    { 7, 1, null, "04:00pm" },
                    { 8, 1, null, "05:00pm" },
                    { 9, 1, null, "06:00pm" },
                    { 10, 1, null, "07:00pm" },
                    { 11, 1, null, "08:00pm" },
                    { 12, 1, null, "09:00pm" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ldts_TimeID",
                table: "Ldts",
                column: "TimeID");

            migrationBuilder.CreateIndex(
                name: "IX_times_datesID",
                table: "times",
                column: "datesID");

            migrationBuilder.AddForeignKey(
                name: "FK_Ldts_times_TimeID",
                table: "Ldts",
                column: "TimeID",
                principalTable: "times",
                principalColumn: "TimeID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_times_dates_datesID",
                table: "times",
                column: "datesID",
                principalTable: "dates",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ldts_times_TimeID",
                table: "Ldts");

            migrationBuilder.DropForeignKey(
                name: "FK_times_dates_datesID",
                table: "times");

            migrationBuilder.DropIndex(
                name: "IX_Ldts_TimeID",
                table: "Ldts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_times",
                table: "times");

            migrationBuilder.DropIndex(
                name: "IX_times_datesID",
                table: "times");

            migrationBuilder.DeleteData(
                table: "times",
                keyColumn: "TimeID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "times",
                keyColumn: "TimeID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "times",
                keyColumn: "TimeID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "times",
                keyColumn: "TimeID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "times",
                keyColumn: "TimeID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "times",
                keyColumn: "TimeID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "times",
                keyColumn: "TimeID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "times",
                keyColumn: "TimeID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "times",
                keyColumn: "TimeID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "times",
                keyColumn: "TimeID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "times",
                keyColumn: "TimeID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "times",
                keyColumn: "TimeID",
                keyValue: 12);

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Ldts");

            migrationBuilder.DropColumn(
                name: "TimeID",
                table: "Ldts");

            migrationBuilder.DropColumn(
                name: "DateID",
                table: "times");

            migrationBuilder.DropColumn(
                name: "datesID",
                table: "times");

            migrationBuilder.DropColumn(
                name: "isAvailable",
                table: "times");

            migrationBuilder.RenameTable(
                name: "times",
                newName: "Time");

            migrationBuilder.AddColumn<int>(
                name: "DateID",
                table: "Ldts",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "datesID",
                table: "Ldts",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TimeID",
                table: "dates",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isBooked",
                table: "Time",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Time",
                table: "Time",
                column: "TimeID");

            migrationBuilder.CreateIndex(
                name: "IX_Ldts_datesID",
                table: "Ldts",
                column: "datesID");

            migrationBuilder.CreateIndex(
                name: "IX_dates_TimeID",
                table: "dates",
                column: "TimeID");

            migrationBuilder.AddForeignKey(
                name: "FK_dates_Time_TimeID",
                table: "dates",
                column: "TimeID",
                principalTable: "Time",
                principalColumn: "TimeID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ldts_dates_datesID",
                table: "Ldts",
                column: "datesID",
                principalTable: "dates",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
