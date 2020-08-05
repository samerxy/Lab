using Microsoft.EntityFrameworkCore.Migrations;

namespace Labs.Migrations
{
    public partial class init009 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_times_dates_datesID",
                table: "times");

            migrationBuilder.DropColumn(
                name: "DateID",
                table: "times");

            migrationBuilder.RenameColumn(
                name: "datesID",
                table: "times",
                newName: "DatesID");

            migrationBuilder.RenameIndex(
                name: "IX_times_datesID",
                table: "times",
                newName: "IX_times_DatesID");

            migrationBuilder.AddColumn<int>(
                name: "LabID",
                table: "times",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "times",
                keyColumn: "TimeID",
                keyValue: 1,
                column: "LabID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "times",
                keyColumn: "TimeID",
                keyValue: 2,
                column: "LabID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "times",
                keyColumn: "TimeID",
                keyValue: 3,
                column: "LabID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "times",
                keyColumn: "TimeID",
                keyValue: 4,
                column: "LabID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "times",
                keyColumn: "TimeID",
                keyValue: 5,
                column: "LabID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "times",
                keyColumn: "TimeID",
                keyValue: 6,
                column: "LabID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "times",
                keyColumn: "TimeID",
                keyValue: 7,
                column: "LabID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "times",
                keyColumn: "TimeID",
                keyValue: 8,
                column: "LabID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "times",
                keyColumn: "TimeID",
                keyValue: 9,
                column: "LabID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "times",
                keyColumn: "TimeID",
                keyValue: 10,
                column: "LabID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "times",
                keyColumn: "TimeID",
                keyValue: 11,
                column: "LabID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "times",
                keyColumn: "TimeID",
                keyValue: 12,
                column: "LabID",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_times_LabID",
                table: "times",
                column: "LabID");

            migrationBuilder.AddForeignKey(
                name: "FK_times_dates_DatesID",
                table: "times",
                column: "DatesID",
                principalTable: "dates",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_times_Labs_LabID",
                table: "times",
                column: "LabID",
                principalTable: "Labs",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_times_dates_DatesID",
                table: "times");

            migrationBuilder.DropForeignKey(
                name: "FK_times_Labs_LabID",
                table: "times");

            migrationBuilder.DropIndex(
                name: "IX_times_LabID",
                table: "times");

            migrationBuilder.DropColumn(
                name: "LabID",
                table: "times");

            migrationBuilder.RenameColumn(
                name: "DatesID",
                table: "times",
                newName: "datesID");

            migrationBuilder.RenameIndex(
                name: "IX_times_DatesID",
                table: "times",
                newName: "IX_times_datesID");

            migrationBuilder.AddColumn<int>(
                name: "DateID",
                table: "times",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "times",
                keyColumn: "TimeID",
                keyValue: 1,
                column: "DateID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "times",
                keyColumn: "TimeID",
                keyValue: 2,
                column: "DateID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "times",
                keyColumn: "TimeID",
                keyValue: 3,
                column: "DateID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "times",
                keyColumn: "TimeID",
                keyValue: 4,
                column: "DateID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "times",
                keyColumn: "TimeID",
                keyValue: 5,
                column: "DateID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "times",
                keyColumn: "TimeID",
                keyValue: 6,
                column: "DateID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "times",
                keyColumn: "TimeID",
                keyValue: 7,
                column: "DateID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "times",
                keyColumn: "TimeID",
                keyValue: 8,
                column: "DateID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "times",
                keyColumn: "TimeID",
                keyValue: 9,
                column: "DateID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "times",
                keyColumn: "TimeID",
                keyValue: 10,
                column: "DateID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "times",
                keyColumn: "TimeID",
                keyValue: 11,
                column: "DateID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "times",
                keyColumn: "TimeID",
                keyValue: 12,
                column: "DateID",
                value: 1);

            migrationBuilder.AddForeignKey(
                name: "FK_times_dates_datesID",
                table: "times",
                column: "datesID",
                principalTable: "dates",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
