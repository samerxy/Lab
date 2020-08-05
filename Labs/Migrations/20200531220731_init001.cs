using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Labs.Migrations
{
    public partial class init001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "emails",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    From = table.Column<string>(nullable: false),
                    To = table.Column<string>(nullable: false),
                    pass = table.Column<string>(nullable: false),
                    path = table.Column<string>(nullable: true),
                    supj = table.Column<string>(nullable: false),
                    body = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_emails", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Labs",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LabName = table.Column<string>(nullable: false),
                    isDeleted = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Labs", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleType = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "dates",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LabID = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    isBooked = table.Column<bool>(nullable: false, defaultValue: false),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dates", x => x.ID);
                    table.ForeignKey(
                        name: "FK_dates_Labs_LabID",
                        column: x => x.LabID,
                        principalTable: "Labs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tests",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LabID = table.Column<int>(nullable: false),
                    TestName = table.Column<string>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tests", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tests_Labs_LabID",
                        column: x => x.LabID,
                        principalTable: "Labs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: false),
                    LabID = table.Column<int>(nullable: true),
                    RoleID = table.Column<int>(nullable: false),
                    isDeleted = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.ID);
                    table.ForeignKey(
                        name: "FK_users_Labs_LabID",
                        column: x => x.LabID,
                        principalTable: "Labs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_users_roles_RoleID",
                        column: x => x.RoleID,
                        principalTable: "roles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ldts",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FullName = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    age = table.Column<int>(nullable: false),
                    LabID = table.Column<int>(nullable: false),
                    DateID = table.Column<int>(nullable: false),
                    datesID = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ldts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Ldts_Labs_LabID",
                        column: x => x.LabID,
                        principalTable: "Labs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ldts_dates_datesID",
                        column: x => x.datesID,
                        principalTable: "dates",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "lt",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TestID = table.Column<int>(nullable: false),
                    LabID = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lt", x => x.ID);
                    table.ForeignKey(
                        name: "FK_lt_Labs_LabID",
                        column: x => x.LabID,
                        principalTable: "Labs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_lt_tests_TestID",
                        column: x => x.TestID,
                        principalTable: "tests",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "ID", "RoleType" },
                values: new object[,]
                {
                    { 1, "ADMIN" },
                    { 2, "USER" }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "ID", "Email", "Name", "Password", "Phone", "RoleID", "UserName" },
                values: new object[,]
                {
                    { 1, "testxy.mailxy@gmail.com", "Samer Saad", "Admin123", "07712365899", 1, "Admin" },
                    { 2, "testxy.mailxy@gmail.com", "Mohammed Ali", "User123", "07712365899", 2, "User" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_dates_LabID",
                table: "dates",
                column: "LabID");

            migrationBuilder.CreateIndex(
                name: "IX_Ldts_LabID",
                table: "Ldts",
                column: "LabID");

            migrationBuilder.CreateIndex(
                name: "IX_Ldts_datesID",
                table: "Ldts",
                column: "datesID");

            migrationBuilder.CreateIndex(
                name: "IX_lt_LabID",
                table: "lt",
                column: "LabID");

            migrationBuilder.CreateIndex(
                name: "IX_lt_TestID",
                table: "lt",
                column: "TestID");

            migrationBuilder.CreateIndex(
                name: "IX_tests_LabID",
                table: "tests",
                column: "LabID");

            migrationBuilder.CreateIndex(
                name: "IX_users_LabID",
                table: "users",
                column: "LabID");

            migrationBuilder.CreateIndex(
                name: "IX_users_RoleID",
                table: "users",
                column: "RoleID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "emails");

            migrationBuilder.DropTable(
                name: "Ldts");

            migrationBuilder.DropTable(
                name: "lt");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "dates");

            migrationBuilder.DropTable(
                name: "tests");

            migrationBuilder.DropTable(
                name: "roles");

            migrationBuilder.DropTable(
                name: "Labs");
        }
    }
}
