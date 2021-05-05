using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class UserUpdateDateName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("2ad549d7-d501-4ed0-be30-b2a4256c5509"));

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "User");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateAt",
                table: "User",
                nullable: true);

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CreateAt", "Email", "Name", "UpdateAt" },
                values: new object[] { new Guid("e98cc0e9-f44c-40b3-b040-47391df97443"), new DateTime(2021, 5, 4, 20, 41, 21, 740, DateTimeKind.Local).AddTicks(4643), "julio@admin.com", "Julio", new DateTime(2021, 5, 4, 20, 41, 21, 742, DateTimeKind.Local).AddTicks(1798) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("e98cc0e9-f44c-40b3-b040-47391df97443"));

            migrationBuilder.DropColumn(
                name: "CreateAt",
                table: "User");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "User",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CreatedAt", "Email", "Name", "UpdateAt" },
                values: new object[] { new Guid("2ad549d7-d501-4ed0-be30-b2a4256c5509"), new DateTime(2021, 4, 29, 22, 25, 36, 984, DateTimeKind.Local).AddTicks(1376), "julio@admin.com", "Julio", new DateTime(2021, 4, 29, 22, 25, 36, 985, DateTimeKind.Local).AddTicks(8862) });
        }
    }
}
