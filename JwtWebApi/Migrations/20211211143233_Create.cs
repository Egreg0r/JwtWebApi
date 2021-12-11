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
                    UserName = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_loginModels", x => x.UserName);
                });

            migrationBuilder.CreateTable(
                name: "tickets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Message = table.Column<string>(type: "text", nullable: false),
                    LoginModelUserName = table.Column<string>(type: "text", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tickets_loginModels_LoginModelUserName",
                        column: x => x.LoginModelUserName,
                        principalTable: "loginModels",
                        principalColumn: "UserName",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "loginModels",
                columns: new[] { "UserName", "Password" },
                values: new object[,]
                {
                    { "FirstUser", "PasswordFistUser" },
                    { "SecondUser", "PasswordSecond" }
                });

            migrationBuilder.InsertData(
                table: "tickets",
                columns: new[] { "Id", "CreateDate", "LoginModelUserName", "Message" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 12, 12, 0, 32, 33, 237, DateTimeKind.Local).AddTicks(4592), "FirstUser", "some text №1 from fist User" },
                    { 2, new DateTime(2021, 12, 12, 0, 32, 33, 239, DateTimeKind.Local).AddTicks(1017), "FirstUser", "some text №2 from fist User" },
                    { 3, new DateTime(2021, 12, 12, 0, 32, 33, 239, DateTimeKind.Local).AddTicks(1577), "FirstUser", "some text №3 from fist User" },
                    { 4, new DateTime(2021, 12, 12, 0, 32, 33, 239, DateTimeKind.Local).AddTicks(2106), "FirstUser", "some text №4 from fist User" },
                    { 5, new DateTime(2021, 12, 12, 0, 32, 33, 239, DateTimeKind.Local).AddTicks(2625), "SecondUser", "some text №1 from second User" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_tickets_LoginModelUserName",
                table: "tickets",
                column: "LoginModelUserName");
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
