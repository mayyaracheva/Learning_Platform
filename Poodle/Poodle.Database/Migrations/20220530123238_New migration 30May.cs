using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Poodle.Data.Migrations
{
    public partial class Newmigration30May : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Sections");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Courses");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 5, 30, 12, 32, 36, 756, DateTimeKind.Utc).AddTicks(8860), new DateTime(2022, 5, 30, 12, 32, 36, 756, DateTimeKind.Utc).AddTicks(9821) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 5, 30, 12, 32, 36, 757, DateTimeKind.Utc).AddTicks(1631), new DateTime(2022, 5, 30, 12, 32, 36, 757, DateTimeKind.Utc).AddTicks(1639) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 5, 30, 12, 32, 36, 757, DateTimeKind.Utc).AddTicks(1647), new DateTime(2022, 5, 30, 12, 32, 36, 757, DateTimeKind.Utc).AddTicks(1649) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 5, 30, 12, 32, 36, 757, DateTimeKind.Utc).AddTicks(1654), new DateTime(2022, 5, 30, 12, 32, 36, 757, DateTimeKind.Utc).AddTicks(1656) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 5, 30, 12, 32, 36, 757, DateTimeKind.Utc).AddTicks(1661), new DateTime(2022, 5, 30, 12, 32, 36, 757, DateTimeKind.Utc).AddTicks(1664) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 5, 30, 12, 32, 36, 757, DateTimeKind.Utc).AddTicks(1684), new DateTime(2022, 5, 30, 12, 32, 36, 757, DateTimeKind.Utc).AddTicks(1686) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 5, 30, 12, 32, 36, 757, DateTimeKind.Utc).AddTicks(1691), new DateTime(2022, 5, 30, 12, 32, 36, 757, DateTimeKind.Utc).AddTicks(1693) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 5, 30, 12, 32, 36, 757, DateTimeKind.Utc).AddTicks(1699), new DateTime(2022, 5, 30, 12, 32, 36, 757, DateTimeKind.Utc).AddTicks(1702) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 5, 30, 12, 32, 36, 757, DateTimeKind.Utc).AddTicks(1708), new DateTime(2022, 5, 30, 12, 32, 36, 757, DateTimeKind.Utc).AddTicks(1710) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 5, 30, 12, 32, 36, 757, DateTimeKind.Utc).AddTicks(1719), new DateTime(2022, 5, 30, 12, 32, 36, 757, DateTimeKind.Utc).AddTicks(1721) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Sections",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Courses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 5, 28, 13, 30, 37, 654, DateTimeKind.Utc).AddTicks(375), new DateTime(2022, 5, 28, 13, 30, 37, 654, DateTimeKind.Utc).AddTicks(1200) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 5, 28, 13, 30, 37, 654, DateTimeKind.Utc).AddTicks(1918), new DateTime(2022, 5, 28, 13, 30, 37, 654, DateTimeKind.Utc).AddTicks(1923) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 5, 28, 13, 30, 37, 654, DateTimeKind.Utc).AddTicks(1929), new DateTime(2022, 5, 28, 13, 30, 37, 654, DateTimeKind.Utc).AddTicks(1931) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 5, 28, 13, 30, 37, 654, DateTimeKind.Utc).AddTicks(1935), new DateTime(2022, 5, 28, 13, 30, 37, 654, DateTimeKind.Utc).AddTicks(1936) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 5, 28, 13, 30, 37, 654, DateTimeKind.Utc).AddTicks(1940), new DateTime(2022, 5, 28, 13, 30, 37, 654, DateTimeKind.Utc).AddTicks(1942) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 5, 28, 13, 30, 37, 654, DateTimeKind.Utc).AddTicks(1952), new DateTime(2022, 5, 28, 13, 30, 37, 654, DateTimeKind.Utc).AddTicks(1954) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 5, 28, 13, 30, 37, 654, DateTimeKind.Utc).AddTicks(1957), new DateTime(2022, 5, 28, 13, 30, 37, 654, DateTimeKind.Utc).AddTicks(1959) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 5, 28, 13, 30, 37, 654, DateTimeKind.Utc).AddTicks(1963), new DateTime(2022, 5, 28, 13, 30, 37, 654, DateTimeKind.Utc).AddTicks(1965) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 5, 28, 13, 30, 37, 654, DateTimeKind.Utc).AddTicks(1968), new DateTime(2022, 5, 28, 13, 30, 37, 654, DateTimeKind.Utc).AddTicks(1970) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 5, 28, 13, 30, 37, 654, DateTimeKind.Utc).AddTicks(1976), new DateTime(2022, 5, 28, 13, 30, 37, 654, DateTimeKind.Utc).AddTicks(1977) });
        }
    }
}
