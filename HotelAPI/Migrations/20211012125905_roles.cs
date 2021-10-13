using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelAPI.Migrations
{
    public partial class roles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4fb100b4-c94e-4e3e-a2fe-97d1b28bc38c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "77ba695d-efe4-4d91-88fd-bc066f9ec654");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b409da8b-f570-41d3-9661-a7f9abd8aee8", "ef004e82-d9de-4544-a5f8-ed24d35b6e5e", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "135bf85e-24db-4e5c-ad3d-7320ef082423", "3cd51655-e063-49b5-a9ba-d05f2414dc0b", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "135bf85e-24db-4e5c-ad3d-7320ef082423");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b409da8b-f570-41d3-9661-a7f9abd8aee8");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4fb100b4-c94e-4e3e-a2fe-97d1b28bc38c", "548a70b8-7eff-452b-aabb-99a75f3ea83c", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "77ba695d-efe4-4d91-88fd-bc066f9ec654", "11117af4-1575-4d5e-a7b9-0b998dd942ee", "aDMINISTRATOR", "ADMINISTRATOR" });
        }
    }
}
