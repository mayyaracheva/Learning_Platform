using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Poodle.Data.Migrations
{
    public partial class SEcond15June : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "UnlockOn",
                table: "Sections",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 15, 9, 58, 21, 491, DateTimeKind.Utc).AddTicks(2814), new DateTime(2022, 6, 15, 9, 58, 21, 491, DateTimeKind.Utc).AddTicks(2831) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 15, 9, 58, 21, 491, DateTimeKind.Utc).AddTicks(2892), new DateTime(2022, 6, 15, 9, 58, 21, 491, DateTimeKind.Utc).AddTicks(2893) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 15, 9, 58, 21, 491, DateTimeKind.Utc).AddTicks(2896), new DateTime(2022, 6, 15, 9, 58, 21, 491, DateTimeKind.Utc).AddTicks(2897) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 15, 9, 58, 21, 491, DateTimeKind.Utc).AddTicks(2900), new DateTime(2022, 6, 15, 9, 58, 21, 491, DateTimeKind.Utc).AddTicks(2901) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 15, 9, 58, 21, 491, DateTimeKind.Utc).AddTicks(2903), new DateTime(2022, 6, 15, 9, 58, 21, 491, DateTimeKind.Utc).AddTicks(2905) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 15, 9, 58, 21, 491, DateTimeKind.Utc).AddTicks(2916), new DateTime(2022, 6, 15, 9, 58, 21, 491, DateTimeKind.Utc).AddTicks(2917) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 15, 9, 58, 21, 491, DateTimeKind.Utc).AddTicks(2920), new DateTime(2022, 6, 15, 9, 58, 21, 491, DateTimeKind.Utc).AddTicks(2921) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 15, 9, 58, 21, 491, DateTimeKind.Utc).AddTicks(2923), new DateTime(2022, 6, 15, 9, 58, 21, 491, DateTimeKind.Utc).AddTicks(2924) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 15, 9, 58, 21, 491, DateTimeKind.Utc).AddTicks(2927), new DateTime(2022, 6, 15, 9, 58, 21, 491, DateTimeKind.Utc).AddTicks(2928) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 15, 9, 58, 21, 491, DateTimeKind.Utc).AddTicks(2932), new DateTime(2022, 6, 15, 9, 58, 21, 491, DateTimeKind.Utc).AddTicks(2933) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 15, 9, 58, 21, 488, DateTimeKind.Utc).AddTicks(9784), new DateTime(2022, 6, 15, 9, 58, 21, 489, DateTimeKind.Utc).AddTicks(496) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 15, 9, 58, 21, 489, DateTimeKind.Utc).AddTicks(1911), new DateTime(2022, 6, 15, 9, 58, 21, 489, DateTimeKind.Utc).AddTicks(1916) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 15, 9, 58, 21, 489, DateTimeKind.Utc).AddTicks(1921), new DateTime(2022, 6, 15, 9, 58, 21, 489, DateTimeKind.Utc).AddTicks(1922) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 15, 9, 58, 21, 489, DateTimeKind.Utc).AddTicks(1925), new DateTime(2022, 6, 15, 9, 58, 21, 489, DateTimeKind.Utc).AddTicks(1927) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 15, 9, 58, 21, 489, DateTimeKind.Utc).AddTicks(1929), new DateTime(2022, 6, 15, 9, 58, 21, 489, DateTimeKind.Utc).AddTicks(1931) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 15, 9, 58, 21, 489, DateTimeKind.Utc).AddTicks(1943), new DateTime(2022, 6, 15, 9, 58, 21, 489, DateTimeKind.Utc).AddTicks(1945) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 15, 9, 58, 21, 489, DateTimeKind.Utc).AddTicks(1948), new DateTime(2022, 6, 15, 9, 58, 21, 489, DateTimeKind.Utc).AddTicks(1949) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 15, 9, 58, 21, 489, DateTimeKind.Utc).AddTicks(1952), new DateTime(2022, 6, 15, 9, 58, 21, 489, DateTimeKind.Utc).AddTicks(1953) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 15, 9, 58, 21, 489, DateTimeKind.Utc).AddTicks(1956), new DateTime(2022, 6, 15, 9, 58, 21, 489, DateTimeKind.Utc).AddTicks(1958) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 15, 9, 58, 21, 489, DateTimeKind.Utc).AddTicks(1963), new DateTime(2022, 6, 15, 9, 58, 21, 489, DateTimeKind.Utc).AddTicks(1964) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UnlockOn",
                table: "Sections");

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
    }
}
