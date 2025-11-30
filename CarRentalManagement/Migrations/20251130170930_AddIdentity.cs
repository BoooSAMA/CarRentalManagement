using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarRentalManagement.Migrations
{
    /// <inheritdoc />
    public partial class AddIdentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Models",
                table: "Models");

            migrationBuilder.RenameTable(
                name: "Models",
                newName: "Model");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Model",
                table: "Model",
                column: "Id");

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

            migrationBuilder.InsertData(
                table: "Make",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "System", new DateTime(2025, 12, 1, 1, 9, 29, 494, DateTimeKind.Local).AddTicks(5831), new DateTime(2025, 12, 1, 1, 9, 29, 494, DateTimeKind.Local).AddTicks(5833), "BMW", "System" },
                    { 2, "System", new DateTime(2025, 12, 1, 1, 9, 29, 494, DateTimeKind.Local).AddTicks(5834), new DateTime(2025, 12, 1, 1, 9, 29, 494, DateTimeKind.Local).AddTicks(5835), "Toyota", "System" }
                });

            migrationBuilder.InsertData(
                table: "Model",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "System", new DateTime(2025, 12, 1, 1, 9, 29, 494, DateTimeKind.Local).AddTicks(5929), new DateTime(2025, 12, 1, 1, 9, 29, 494, DateTimeKind.Local).AddTicks(5930), "i4", "System" },
                    { 2, "System", new DateTime(2025, 12, 1, 1, 9, 29, 494, DateTimeKind.Local).AddTicks(5931), new DateTime(2025, 12, 1, 1, 9, 29, 494, DateTimeKind.Local).AddTicks(5932), "X5", "System" },
                    { 3, "System", new DateTime(2025, 12, 1, 1, 9, 29, 494, DateTimeKind.Local).AddTicks(5933), new DateTime(2025, 12, 1, 1, 9, 29, 494, DateTimeKind.Local).AddTicks(5934), "Prius", "System" },
                    { 4, "System", new DateTime(2025, 12, 1, 1, 9, 29, 494, DateTimeKind.Local).AddTicks(5935), new DateTime(2025, 12, 1, 1, 9, 29, 494, DateTimeKind.Local).AddTicks(5935), "C-HR", "System" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Model",
                table: "Model");

            migrationBuilder.DeleteData(
                table: "Make",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Make",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Model",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Model",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Model",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Model",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.RenameTable(
                name: "Model",
                newName: "Models");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Models",
                table: "Models",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Colour",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2025, 12, 1, 1, 1, 28, 214, DateTimeKind.Local).AddTicks(9628), new DateTime(2025, 12, 1, 1, 1, 28, 214, DateTimeKind.Local).AddTicks(9641) });

            migrationBuilder.UpdateData(
                table: "Colour",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2025, 12, 1, 1, 1, 28, 214, DateTimeKind.Local).AddTicks(9645), new DateTime(2025, 12, 1, 1, 1, 28, 214, DateTimeKind.Local).AddTicks(9645) });
        }
    }
}
