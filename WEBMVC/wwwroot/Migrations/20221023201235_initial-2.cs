using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 10, 23, 23, 12, 34, 673, DateTimeKind.Local).AddTicks(5225), new DateTime(2022, 10, 23, 23, 12, 34, 673, DateTimeKind.Local).AddTicks(5226) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 10, 23, 23, 12, 34, 673, DateTimeKind.Local).AddTicks(5230), new DateTime(2022, 10, 23, 23, 12, 34, 673, DateTimeKind.Local).AddTicks(5232) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 10, 23, 23, 12, 34, 673, DateTimeKind.Local).AddTicks(5235), new DateTime(2022, 10, 23, 23, 12, 34, 673, DateTimeKind.Local).AddTicks(5236) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 10, 23, 16, 52, 4, 690, DateTimeKind.Local).AddTicks(486), new DateTime(2022, 10, 23, 16, 52, 4, 690, DateTimeKind.Local).AddTicks(487) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 10, 23, 16, 52, 4, 690, DateTimeKind.Local).AddTicks(490), new DateTime(2022, 10, 23, 16, 52, 4, 690, DateTimeKind.Local).AddTicks(491) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 10, 23, 16, 52, 4, 690, DateTimeKind.Local).AddTicks(494), new DateTime(2022, 10, 23, 16, 52, 4, 690, DateTimeKind.Local).AddTicks(495) });
        }
    }
}
