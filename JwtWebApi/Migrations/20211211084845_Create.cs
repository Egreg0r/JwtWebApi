using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace JwtWebApi.Migrations
{
    public partial class Create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "loginModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserName = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_loginModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tickets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    message = table.Column<string>(type: "text", nullable: false),
                    loginModelId = table.Column<int>(type: "integer", nullable: false),
                    createDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tickets_loginModels_loginModelId",
                        column: x => x.loginModelId,
                        principalTable: "loginModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "loginModels",
                columns: new[] { "Id", "Password", "UserName" },
                values: new object[,]
                {
                    { 1, "PasswordFistUser", "FirstUser" },
                    { 2, "PasswordSecond", "SecondUser" }
                });

            migrationBuilder.InsertData(
                table: "tickets",
                columns: new[] { "Id", "createDate", "loginModelId", "message" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 12, 11, 18, 48, 45, 88, DateTimeKind.Local).AddTicks(4910), 1, "some text from fist User" },
                    { 2, new DateTime(2021, 12, 11, 18, 48, 45, 90, DateTimeKind.Local).AddTicks(4787), 1, "some text 2 from fist User" },
                    { 3, new DateTime(2021, 12, 11, 18, 48, 45, 90, DateTimeKind.Local).AddTicks(5228), 2, "some text from second User" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_loginModels_UserName",
                table: "loginModels",
                column: "UserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tickets_loginModelId",
                table: "tickets",
                column: "loginModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tickets");

            migrationBuilder.DropTable(
                name: "loginModels");
        }
    }
}
