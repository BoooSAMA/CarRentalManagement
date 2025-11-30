using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarRentalManagement.Migrations
{
    /// <inheritdoc />
    public partial class SeedUserRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ad2bcf0c-20db-474f-8407-5a6b159518ba", null, "Administrator", "ADMINISTRATOR" },
                    { "bd2bcf0c-20db-474f-8407-5a6b159518bb", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "3781efa7-66dc-47f0-860f-e506d04102e4", 0, "28a6fff4-9fb2-4d2c-8cb4-4c63ad80eee7", "admin@localhost.com", true, "Admin", "User", false, null, "ADMIN@LOCALHOST.COM", "ADMIN@LOCALHOST.COM", "AQAAAAIAAYagAAAAEBA7nC5AzeVOaQeB9Dv6Ucg4opIYb3LZpUyeKd0vysYtWidpsgpD2KyBX0kGbcFDEg==", null, false, "116b34ff-9842-4f4c-b541-7fab64000d79", false, "admin@localhost.com" });

            migrationBuilder.UpdateData(
                table: "Colour",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2025, 12, 1, 2, 6, 3, 720, DateTimeKind.Local).AddTicks(5963), new DateTime(2025, 12, 1, 2, 6, 3, 720, DateTimeKind.Local).AddTicks(5981) });

            migrationBuilder.UpdateData(
                table: "Colour",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2025, 12, 1, 2, 6, 3, 720, DateTimeKind.Local).AddTicks(5983), new DateTime(2025, 12, 1, 2, 6, 3, 720, DateTimeKind.Local).AddTicks(5984) });

            migrationBuilder.UpdateData(
                table: "Make",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2025, 12, 1, 2, 6, 3, 720, DateTimeKind.Local).AddTicks(6213), new DateTime(2025, 12, 1, 2, 6, 3, 720, DateTimeKind.Local).AddTicks(6214) });

            migrationBuilder.UpdateData(
                table: "Make",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2025, 12, 1, 2, 6, 3, 720, DateTimeKind.Local).AddTicks(6215), new DateTime(2025, 12, 1, 2, 6, 3, 720, DateTimeKind.Local).AddTicks(6216) });

            migrationBuilder.UpdateData(
                table: "Model",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2025, 12, 1, 2, 6, 3, 720, DateTimeKind.Local).AddTicks(6309), new DateTime(2025, 12, 1, 2, 6, 3, 720, DateTimeKind.Local).AddTicks(6310) });

            migrationBuilder.UpdateData(
                table: "Model",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2025, 12, 1, 2, 6, 3, 720, DateTimeKind.Local).AddTicks(6312), new DateTime(2025, 12, 1, 2, 6, 3, 720, DateTimeKind.Local).AddTicks(6312) });

            migrationBuilder.UpdateData(
                table: "Model",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2025, 12, 1, 2, 6, 3, 720, DateTimeKind.Local).AddTicks(6313), new DateTime(2025, 12, 1, 2, 6, 3, 720, DateTimeKind.Local).AddTicks(6314) });

            migrationBuilder.UpdateData(
                table: "Model",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2025, 12, 1, 2, 6, 3, 720, DateTimeKind.Local).AddTicks(6315), new DateTime(2025, 12, 1, 2, 6, 3, 720, DateTimeKind.Local).AddTicks(6315) });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "ad2bcf0c-20db-474f-8407-5a6b159518ba", "3781efa7-66dc-47f0-860f-e506d04102e4" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bd2bcf0c-20db-474f-8407-5a6b159518bb");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ad2bcf0c-20db-474f-8407-5a6b159518ba", "3781efa7-66dc-47f0-860f-e506d04102e4" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad2bcf0c-20db-474f-8407-5a6b159518ba");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3781efa7-66dc-47f0-860f-e506d04102e4");

            migrationBuilder.UpdateData(
                table: "Colour",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2025, 12, 1, 1, 9, 29, 494, DateTimeKind.Local).AddTicks(5519), new DateTime(2025, 12, 1, 1, 9, 29, 494, DateTimeKind.Local).AddTicks(5529) });

            migrationBuilder.UpdateData(
                table: "Colour",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2025, 12, 1, 1, 9, 29, 494, DateTimeKind.Local).AddTicks(5532), new DateTime(2025, 12, 1, 1, 9, 29, 494, DateTimeKind.Local).AddTicks(5533) });

            migrationBuilder.UpdateData(
                table: "Make",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2025, 12, 1, 1, 9, 29, 494, DateTimeKind.Local).AddTicks(5831), new DateTime(2025, 12, 1, 1, 9, 29, 494, DateTimeKind.Local).AddTicks(5833) });

            migrationBuilder.UpdateData(
                table: "Make",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2025, 12, 1, 1, 9, 29, 494, DateTimeKind.Local).AddTicks(5834), new DateTime(2025, 12, 1, 1, 9, 29, 494, DateTimeKind.Local).AddTicks(5835) });

            migrationBuilder.UpdateData(
                table: "Model",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2025, 12, 1, 1, 9, 29, 494, DateTimeKind.Local).AddTicks(5929), new DateTime(2025, 12, 1, 1, 9, 29, 494, DateTimeKind.Local).AddTicks(5930) });

            migrationBuilder.UpdateData(
                table: "Model",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2025, 12, 1, 1, 9, 29, 494, DateTimeKind.Local).AddTicks(5931), new DateTime(2025, 12, 1, 1, 9, 29, 494, DateTimeKind.Local).AddTicks(5932) });

            migrationBuilder.UpdateData(
                table: "Model",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2025, 12, 1, 1, 9, 29, 494, DateTimeKind.Local).AddTicks(5933), new DateTime(2025, 12, 1, 1, 9, 29, 494, DateTimeKind.Local).AddTicks(5934) });

            migrationBuilder.UpdateData(
                table: "Model",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2025, 12, 1, 1, 9, 29, 494, DateTimeKind.Local).AddTicks(5935), new DateTime(2025, 12, 1, 1, 9, 29, 494, DateTimeKind.Local).AddTicks(5935) });
        }
    }
}
