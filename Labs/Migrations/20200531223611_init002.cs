using Microsoft.EntityFrameworkCore.Migrations;

namespace Labs.Migrations
{
    public partial class init002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Labs",
                columns: new[] { "ID", "LabName" },
                values: new object[] { 1, "Pure" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Labs",
                keyColumn: "ID",
                keyValue: 1);
        }
    }
}
