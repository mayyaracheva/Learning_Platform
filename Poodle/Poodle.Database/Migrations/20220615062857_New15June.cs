using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Poodle.Data.Migrations
{
    public partial class New15June : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsEmbeded",
                table: "Sections",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 15, 6, 28, 56, 580, DateTimeKind.Utc).AddTicks(3924), new DateTime(2022, 6, 15, 6, 28, 56, 580, DateTimeKind.Utc).AddTicks(3930) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 15, 6, 28, 56, 580, DateTimeKind.Utc).AddTicks(3969), new DateTime(2022, 6, 15, 6, 28, 56, 580, DateTimeKind.Utc).AddTicks(3971) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 15, 6, 28, 56, 580, DateTimeKind.Utc).AddTicks(3974), new DateTime(2022, 6, 15, 6, 28, 56, 580, DateTimeKind.Utc).AddTicks(3976) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 15, 6, 28, 56, 580, DateTimeKind.Utc).AddTicks(3979), new DateTime(2022, 6, 15, 6, 28, 56, 580, DateTimeKind.Utc).AddTicks(3980) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 15, 6, 28, 56, 580, DateTimeKind.Utc).AddTicks(3983), new DateTime(2022, 6, 15, 6, 28, 56, 580, DateTimeKind.Utc).AddTicks(3984) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 15, 6, 28, 56, 580, DateTimeKind.Utc).AddTicks(3991), new DateTime(2022, 6, 15, 6, 28, 56, 580, DateTimeKind.Utc).AddTicks(3993) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 15, 6, 28, 56, 580, DateTimeKind.Utc).AddTicks(3996), new DateTime(2022, 6, 15, 6, 28, 56, 580, DateTimeKind.Utc).AddTicks(3997) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 15, 6, 28, 56, 580, DateTimeKind.Utc).AddTicks(4000), new DateTime(2022, 6, 15, 6, 28, 56, 580, DateTimeKind.Utc).AddTicks(4001) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 15, 6, 28, 56, 580, DateTimeKind.Utc).AddTicks(4004), new DateTime(2022, 6, 15, 6, 28, 56, 580, DateTimeKind.Utc).AddTicks(4005) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 15, 6, 28, 56, 580, DateTimeKind.Utc).AddTicks(4010), new DateTime(2022, 6, 15, 6, 28, 56, 580, DateTimeKind.Utc).AddTicks(4012) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 15, 6, 28, 56, 578, DateTimeKind.Utc).AddTicks(7167), new DateTime(2022, 6, 15, 6, 28, 56, 578, DateTimeKind.Utc).AddTicks(7690) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 15, 6, 28, 56, 578, DateTimeKind.Utc).AddTicks(8814), new DateTime(2022, 6, 15, 6, 28, 56, 578, DateTimeKind.Utc).AddTicks(8819) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 15, 6, 28, 56, 578, DateTimeKind.Utc).AddTicks(8823), new DateTime(2022, 6, 15, 6, 28, 56, 578, DateTimeKind.Utc).AddTicks(8824) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 15, 6, 28, 56, 578, DateTimeKind.Utc).AddTicks(8828), new DateTime(2022, 6, 15, 6, 28, 56, 578, DateTimeKind.Utc).AddTicks(8830) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 15, 6, 28, 56, 578, DateTimeKind.Utc).AddTicks(8832), new DateTime(2022, 6, 15, 6, 28, 56, 578, DateTimeKind.Utc).AddTicks(8834) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 15, 6, 28, 56, 578, DateTimeKind.Utc).AddTicks(8844), new DateTime(2022, 6, 15, 6, 28, 56, 578, DateTimeKind.Utc).AddTicks(8845) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 15, 6, 28, 56, 578, DateTimeKind.Utc).AddTicks(8848), new DateTime(2022, 6, 15, 6, 28, 56, 578, DateTimeKind.Utc).AddTicks(8849) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 15, 6, 28, 56, 578, DateTimeKind.Utc).AddTicks(8852), new DateTime(2022, 6, 15, 6, 28, 56, 578, DateTimeKind.Utc).AddTicks(8854) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 15, 6, 28, 56, 578, DateTimeKind.Utc).AddTicks(8857), new DateTime(2022, 6, 15, 6, 28, 56, 578, DateTimeKind.Utc).AddTicks(8858) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 15, 6, 28, 56, 578, DateTimeKind.Utc).AddTicks(8863), new DateTime(2022, 6, 15, 6, 28, 56, 578, DateTimeKind.Utc).AddTicks(8864) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsEmbeded",
                table: "Sections");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 13, 16, 40, 50, 440, DateTimeKind.Utc).AddTicks(9354), new DateTime(2022, 6, 13, 16, 40, 50, 440, DateTimeKind.Utc).AddTicks(9360) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 13, 16, 40, 50, 440, DateTimeKind.Utc).AddTicks(9378), new DateTime(2022, 6, 13, 16, 40, 50, 440, DateTimeKind.Utc).AddTicks(9379) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 13, 16, 40, 50, 440, DateTimeKind.Utc).AddTicks(9381), new DateTime(2022, 6, 13, 16, 40, 50, 440, DateTimeKind.Utc).AddTicks(9382) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 13, 16, 40, 50, 440, DateTimeKind.Utc).AddTicks(9383), new DateTime(2022, 6, 13, 16, 40, 50, 440, DateTimeKind.Utc).AddTicks(9384) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 13, 16, 40, 50, 440, DateTimeKind.Utc).AddTicks(9387), new DateTime(2022, 6, 13, 16, 40, 50, 440, DateTimeKind.Utc).AddTicks(9387) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 13, 16, 40, 50, 440, DateTimeKind.Utc).AddTicks(9392), new DateTime(2022, 6, 13, 16, 40, 50, 440, DateTimeKind.Utc).AddTicks(9392) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 13, 16, 40, 50, 440, DateTimeKind.Utc).AddTicks(9394), new DateTime(2022, 6, 13, 16, 40, 50, 440, DateTimeKind.Utc).AddTicks(9395) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 13, 16, 40, 50, 440, DateTimeKind.Utc).AddTicks(9396), new DateTime(2022, 6, 13, 16, 40, 50, 440, DateTimeKind.Utc).AddTicks(9397) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 13, 16, 40, 50, 440, DateTimeKind.Utc).AddTicks(9399), new DateTime(2022, 6, 13, 16, 40, 50, 440, DateTimeKind.Utc).AddTicks(9400) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 13, 16, 40, 50, 440, DateTimeKind.Utc).AddTicks(9403), new DateTime(2022, 6, 13, 16, 40, 50, 440, DateTimeKind.Utc).AddTicks(9403) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 13, 16, 40, 50, 439, DateTimeKind.Utc).AddTicks(8715), new DateTime(2022, 6, 13, 16, 40, 50, 439, DateTimeKind.Utc).AddTicks(9032) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 13, 16, 40, 50, 439, DateTimeKind.Utc).AddTicks(9651), new DateTime(2022, 6, 13, 16, 40, 50, 439, DateTimeKind.Utc).AddTicks(9653) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 13, 16, 40, 50, 439, DateTimeKind.Utc).AddTicks(9656), new DateTime(2022, 6, 13, 16, 40, 50, 439, DateTimeKind.Utc).AddTicks(9657) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 13, 16, 40, 50, 439, DateTimeKind.Utc).AddTicks(9659), new DateTime(2022, 6, 13, 16, 40, 50, 439, DateTimeKind.Utc).AddTicks(9660) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 13, 16, 40, 50, 439, DateTimeKind.Utc).AddTicks(9661), new DateTime(2022, 6, 13, 16, 40, 50, 439, DateTimeKind.Utc).AddTicks(9662) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 13, 16, 40, 50, 439, DateTimeKind.Utc).AddTicks(9671), new DateTime(2022, 6, 13, 16, 40, 50, 439, DateTimeKind.Utc).AddTicks(9672) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 13, 16, 40, 50, 439, DateTimeKind.Utc).AddTicks(9675), new DateTime(2022, 6, 13, 16, 40, 50, 439, DateTimeKind.Utc).AddTicks(9676) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 13, 16, 40, 50, 439, DateTimeKind.Utc).AddTicks(9677), new DateTime(2022, 6, 13, 16, 40, 50, 439, DateTimeKind.Utc).AddTicks(9678) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 13, 16, 40, 50, 439, DateTimeKind.Utc).AddTicks(9680), new DateTime(2022, 6, 13, 16, 40, 50, 439, DateTimeKind.Utc).AddTicks(9681) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 13, 16, 40, 50, 439, DateTimeKind.Utc).AddTicks(9685), new DateTime(2022, 6, 13, 16, 40, 50, 439, DateTimeKind.Utc).AddTicks(9686) });
        }
    }
}
