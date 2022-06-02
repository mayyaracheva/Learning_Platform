using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Poodle.Data.Migrations
{
    public partial class Next0206 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsRestricted",
                table: "Sections",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Rank",
                table: "Sections",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Content", "Rank" },
                values: new object[] { "testTest", 1 });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Content", "Rank" },
                values: new object[] { "testTest", 2 });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Content", "Rank" },
                values: new object[] { "testTest", 3 });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Content", "Rank" },
                values: new object[] { "testTest", 1 });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Content", "Rank" },
                values: new object[] { "testTest", 2 });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Content", "Rank" },
                values: new object[] { "testTest", 3 });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Content", "Rank" },
                values: new object[] { "testTest", 1 });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Content", "Rank" },
                values: new object[] { "testTest", 2 });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Content", "Rank" },
                values: new object[] { "testTest", 3 });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Content", "Rank" },
                values: new object[] { "testTest", 1 });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Content", "Rank" },
                values: new object[] { "testTest", 2 });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Content", "Rank" },
                values: new object[] { "testTest", 3 });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Content", "Rank" },
                values: new object[] { "testTest", 1 });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Content", "Rank" },
                values: new object[] { "testTest", 2 });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Content", "Rank" },
                values: new object[] { "testTest", 3 });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Content", "Rank" },
                values: new object[] { "testTest", 1 });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Content", "Rank" },
                values: new object[] { "testTest", 2 });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Content", "Rank" },
                values: new object[] { "testTest", 3 });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "Content", "Rank" },
                values: new object[] { "testTest", 1 });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "Content", "Rank" },
                values: new object[] { "testTest", 2 });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "Content", "Rank" },
                values: new object[] { "testTest", 3 });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "Content", "Rank" },
                values: new object[] { "testTest", 1 });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "Content", "Rank" },
                values: new object[] { "testTest", 2 });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "Content", "Rank" },
                values: new object[] { "testTest", 3 });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "Content", "Rank" },
                values: new object[] { "testTest", 1 });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "Content", "Rank" },
                values: new object[] { "testTest", 2 });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "Content", "Rank" },
                values: new object[] { "testTest", 3 });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "Content", "Rank" },
                values: new object[] { "testTest", 1 });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "Content", "Rank" },
                values: new object[] { "testTest", 2 });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "Content", "Rank" },
                values: new object[] { "testTest", 3 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 2, 19, 26, 50, 367, DateTimeKind.Utc).AddTicks(1366), new DateTime(2022, 6, 2, 19, 26, 50, 367, DateTimeKind.Utc).AddTicks(1626) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 2, 19, 26, 50, 367, DateTimeKind.Utc).AddTicks(2111), new DateTime(2022, 6, 2, 19, 26, 50, 367, DateTimeKind.Utc).AddTicks(2113) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 2, 19, 26, 50, 367, DateTimeKind.Utc).AddTicks(2116), new DateTime(2022, 6, 2, 19, 26, 50, 367, DateTimeKind.Utc).AddTicks(2117) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 2, 19, 26, 50, 367, DateTimeKind.Utc).AddTicks(2119), new DateTime(2022, 6, 2, 19, 26, 50, 367, DateTimeKind.Utc).AddTicks(2120) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 2, 19, 26, 50, 367, DateTimeKind.Utc).AddTicks(2122), new DateTime(2022, 6, 2, 19, 26, 50, 367, DateTimeKind.Utc).AddTicks(2123) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 2, 19, 26, 50, 367, DateTimeKind.Utc).AddTicks(2128), new DateTime(2022, 6, 2, 19, 26, 50, 367, DateTimeKind.Utc).AddTicks(2129) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 2, 19, 26, 50, 367, DateTimeKind.Utc).AddTicks(2131), new DateTime(2022, 6, 2, 19, 26, 50, 367, DateTimeKind.Utc).AddTicks(2132) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 2, 19, 26, 50, 367, DateTimeKind.Utc).AddTicks(2134), new DateTime(2022, 6, 2, 19, 26, 50, 367, DateTimeKind.Utc).AddTicks(2135) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 2, 19, 26, 50, 367, DateTimeKind.Utc).AddTicks(2137), new DateTime(2022, 6, 2, 19, 26, 50, 367, DateTimeKind.Utc).AddTicks(2138) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 2, 19, 26, 50, 367, DateTimeKind.Utc).AddTicks(2141), new DateTime(2022, 6, 2, 19, 26, 50, 367, DateTimeKind.Utc).AddTicks(2142) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRestricted",
                table: "Sections");

            migrationBuilder.DropColumn(
                name: "Rank",
                table: "Sections");

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 1,
                column: "Content",
                value: null);

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 2,
                column: "Content",
                value: null);

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 3,
                column: "Content",
                value: null);

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 4,
                column: "Content",
                value: null);

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 5,
                column: "Content",
                value: null);

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 6,
                column: "Content",
                value: null);

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 7,
                column: "Content",
                value: null);

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 8,
                column: "Content",
                value: null);

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 9,
                column: "Content",
                value: null);

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 10,
                column: "Content",
                value: null);

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 11,
                column: "Content",
                value: null);

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 12,
                column: "Content",
                value: null);

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 13,
                column: "Content",
                value: null);

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 14,
                column: "Content",
                value: null);

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 15,
                column: "Content",
                value: null);

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 16,
                column: "Content",
                value: null);

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 17,
                column: "Content",
                value: null);

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 18,
                column: "Content",
                value: null);

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 19,
                column: "Content",
                value: null);

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 20,
                column: "Content",
                value: null);

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 21,
                column: "Content",
                value: null);

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 22,
                column: "Content",
                value: null);

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 23,
                column: "Content",
                value: null);

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 24,
                column: "Content",
                value: null);

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 25,
                column: "Content",
                value: null);

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 26,
                column: "Content",
                value: null);

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 27,
                column: "Content",
                value: null);

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 28,
                column: "Content",
                value: null);

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 29,
                column: "Content",
                value: null);

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 30,
                column: "Content",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 1, 8, 17, 18, 513, DateTimeKind.Utc).AddTicks(1698), new DateTime(2022, 6, 1, 8, 17, 18, 513, DateTimeKind.Utc).AddTicks(2681) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 1, 8, 17, 18, 513, DateTimeKind.Utc).AddTicks(4591), new DateTime(2022, 6, 1, 8, 17, 18, 513, DateTimeKind.Utc).AddTicks(4597) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 1, 8, 17, 18, 513, DateTimeKind.Utc).AddTicks(4603), new DateTime(2022, 6, 1, 8, 17, 18, 513, DateTimeKind.Utc).AddTicks(4605) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 1, 8, 17, 18, 513, DateTimeKind.Utc).AddTicks(4610), new DateTime(2022, 6, 1, 8, 17, 18, 513, DateTimeKind.Utc).AddTicks(4612) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 1, 8, 17, 18, 513, DateTimeKind.Utc).AddTicks(4616), new DateTime(2022, 6, 1, 8, 17, 18, 513, DateTimeKind.Utc).AddTicks(4618) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 1, 8, 17, 18, 513, DateTimeKind.Utc).AddTicks(4639), new DateTime(2022, 6, 1, 8, 17, 18, 513, DateTimeKind.Utc).AddTicks(4641) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 1, 8, 17, 18, 513, DateTimeKind.Utc).AddTicks(4645), new DateTime(2022, 6, 1, 8, 17, 18, 513, DateTimeKind.Utc).AddTicks(4648) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 1, 8, 17, 18, 513, DateTimeKind.Utc).AddTicks(4652), new DateTime(2022, 6, 1, 8, 17, 18, 513, DateTimeKind.Utc).AddTicks(4654) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 1, 8, 17, 18, 513, DateTimeKind.Utc).AddTicks(4658), new DateTime(2022, 6, 1, 8, 17, 18, 513, DateTimeKind.Utc).AddTicks(4660) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 1, 8, 17, 18, 513, DateTimeKind.Utc).AddTicks(4668), new DateTime(2022, 6, 1, 8, 17, 18, 513, DateTimeKind.Utc).AddTicks(4670) });
        }
    }
}
