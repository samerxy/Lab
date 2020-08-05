using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Labs.Migrations
{
    public partial class init004 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TimeID",
                table: "dates",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Time",
                columns: table => new
                {
                    TimeID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    time = table.Column<string>(nullable: false),
                    isBooked = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Time", x => x.TimeID);
                });

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_dates_Time_TimeID",
                table: "dates");

            migrationBuilder.DropTable(
                name: "Time");

            migrationBuilder.DropIndex(
                name: "IX_dates_TimeID",
                table: "dates");

            migrationBuilder.DropColumn(
                name: "TimeID",
                table: "dates");
        }
    }
}
