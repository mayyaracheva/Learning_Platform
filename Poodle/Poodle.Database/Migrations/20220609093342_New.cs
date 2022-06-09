using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Poodle.Data.Migrations
{
    public partial class New : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhotoURL",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                column: "PhotoURL",
                value: "img/course-1.jpg");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2,
                column: "PhotoURL",
                value: "img/course-2.jpg");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3,
                column: "PhotoURL",
                value: "img/course-3.jpg");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 4,
                column: "PhotoURL",
                value: "img/course-4.jpg");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 5,
                column: "PhotoURL",
                value: "img/course-5.jpg");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 6,
                column: "PhotoURL",
                value: "img/course-6.jpg");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 7,
                column: "PhotoURL",
                value: "img/course-7.jpg");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 8,
                column: "PhotoURL",
                value: "img/course-8.jpg");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 9,
                column: "PhotoURL",
                value: "img/course-9.jpg");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 10,
                column: "PhotoURL",
                value: "img/course-10.jpg");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 9, 9, 33, 40, 431, DateTimeKind.Utc).AddTicks(7514), new DateTime(2022, 6, 9, 9, 33, 40, 431, DateTimeKind.Utc).AddTicks(8094) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 9, 9, 33, 40, 431, DateTimeKind.Utc).AddTicks(9132), new DateTime(2022, 6, 9, 9, 33, 40, 431, DateTimeKind.Utc).AddTicks(9136) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 9, 9, 33, 40, 431, DateTimeKind.Utc).AddTicks(9143), new DateTime(2022, 6, 9, 9, 33, 40, 431, DateTimeKind.Utc).AddTicks(9144) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 9, 9, 33, 40, 431, DateTimeKind.Utc).AddTicks(9147), new DateTime(2022, 6, 9, 9, 33, 40, 431, DateTimeKind.Utc).AddTicks(9149) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 9, 9, 33, 40, 431, DateTimeKind.Utc).AddTicks(9152), new DateTime(2022, 6, 9, 9, 33, 40, 431, DateTimeKind.Utc).AddTicks(9153) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 9, 9, 33, 40, 431, DateTimeKind.Utc).AddTicks(9163), new DateTime(2022, 6, 9, 9, 33, 40, 431, DateTimeKind.Utc).AddTicks(9164) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 9, 9, 33, 40, 431, DateTimeKind.Utc).AddTicks(9167), new DateTime(2022, 6, 9, 9, 33, 40, 431, DateTimeKind.Utc).AddTicks(9168) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 9, 9, 33, 40, 431, DateTimeKind.Utc).AddTicks(9171), new DateTime(2022, 6, 9, 9, 33, 40, 431, DateTimeKind.Utc).AddTicks(9172) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 9, 9, 33, 40, 431, DateTimeKind.Utc).AddTicks(9175), new DateTime(2022, 6, 9, 9, 33, 40, 431, DateTimeKind.Utc).AddTicks(9177) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 9, 9, 33, 40, 431, DateTimeKind.Utc).AddTicks(9181), new DateTime(2022, 6, 9, 9, 33, 40, 431, DateTimeKind.Utc).AddTicks(9183) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoURL",
                table: "Courses");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 9, 8, 27, 10, 690, DateTimeKind.Utc).AddTicks(8099), new DateTime(2022, 6, 9, 8, 27, 10, 690, DateTimeKind.Utc).AddTicks(8538) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 9, 8, 27, 10, 690, DateTimeKind.Utc).AddTicks(9347), new DateTime(2022, 6, 9, 8, 27, 10, 690, DateTimeKind.Utc).AddTicks(9351) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 9, 8, 27, 10, 690, DateTimeKind.Utc).AddTicks(9355), new DateTime(2022, 6, 9, 8, 27, 10, 690, DateTimeKind.Utc).AddTicks(9356) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 9, 8, 27, 10, 690, DateTimeKind.Utc).AddTicks(9359), new DateTime(2022, 6, 9, 8, 27, 10, 690, DateTimeKind.Utc).AddTicks(9360) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 9, 8, 27, 10, 690, DateTimeKind.Utc).AddTicks(9362), new DateTime(2022, 6, 9, 8, 27, 10, 690, DateTimeKind.Utc).AddTicks(9363) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 9, 8, 27, 10, 690, DateTimeKind.Utc).AddTicks(9374), new DateTime(2022, 6, 9, 8, 27, 10, 690, DateTimeKind.Utc).AddTicks(9375) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 9, 8, 27, 10, 690, DateTimeKind.Utc).AddTicks(9377), new DateTime(2022, 6, 9, 8, 27, 10, 690, DateTimeKind.Utc).AddTicks(9379) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 9, 8, 27, 10, 690, DateTimeKind.Utc).AddTicks(9381), new DateTime(2022, 6, 9, 8, 27, 10, 690, DateTimeKind.Utc).AddTicks(9382) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 9, 8, 27, 10, 690, DateTimeKind.Utc).AddTicks(9385), new DateTime(2022, 6, 9, 8, 27, 10, 690, DateTimeKind.Utc).AddTicks(9386) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 9, 8, 27, 10, 690, DateTimeKind.Utc).AddTicks(9390), new DateTime(2022, 6, 9, 8, 27, 10, 690, DateTimeKind.Utc).AddTicks(9392) });
        }
    }
}
