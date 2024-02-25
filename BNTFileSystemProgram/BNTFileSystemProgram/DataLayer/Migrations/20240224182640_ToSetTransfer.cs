using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    public partial class ToSetTransfer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5c08d9f0-0272-4eac-a3a2-3f32a132be93");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a60b2eba-10d8-4873-8638-b00c2a8e44bf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a95e28f7-9844-46da-b92a-799268a36f7e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1765210a-4b4c-469a-96dc-5a8048d03891", "abbe7966-f398-4b9b-9814-8a214d78d298", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "71e25bc1-e74f-42fa-9ce6-309f4e1f298d", "2e38c9a3-4a18-4f11-a42a-70ed93ec6091", "Editor", "EDITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a8e39dab-407d-4b1c-913a-e27981546e9d", "0088d821-2106-4d61-a37c-50966fe6267c", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1765210a-4b4c-469a-96dc-5a8048d03891");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "71e25bc1-e74f-42fa-9ce6-309f4e1f298d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a8e39dab-407d-4b1c-913a-e27981546e9d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5c08d9f0-0272-4eac-a3a2-3f32a132be93", "3514909d-3e71-4969-aa9e-604d78d9b713", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a60b2eba-10d8-4873-8638-b00c2a8e44bf", "b2a109a9-7961-4a13-9b61-be93e94fbb6a", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a95e28f7-9844-46da-b92a-799268a36f7e", "86451d1e-da0f-428d-819d-e991ae8b263a", "Editor", "EDITOR" });
        }
    }
}
