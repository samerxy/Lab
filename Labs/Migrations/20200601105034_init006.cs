using Microsoft.EntityFrameworkCore.Migrations;

namespace Labs.Migrations
{
    public partial class init006 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ldts_times_TimeID",
                table: "Ldts");

            migrationBuilder.AddForeignKey(
                name: "FK_Ldts_times_TimeID",
                table: "Ldts",
                column: "TimeID",
                principalTable: "times",
                principalColumn: "TimeID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ldts_times_TimeID",
                table: "Ldts");

            migrationBuilder.AddForeignKey(
                name: "FK_Ldts_times_TimeID",
                table: "Ldts",
                column: "TimeID",
                principalTable: "times",
                principalColumn: "TimeID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
