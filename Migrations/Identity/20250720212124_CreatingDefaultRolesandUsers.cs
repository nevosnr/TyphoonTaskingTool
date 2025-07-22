using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TyphoonTaskingTool.Migrations.Identity
{
    /// <inheritdoc />
    public partial class CreatingDefaultRolesandUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "392f7177-e777-4ffc-a57d-2ed84d16ae01", null, "Administrator", "ADMINISTRATOR" },
                    { "9e30e59b-edd6-4cf2-b8d1-c254f43549dd", null, "mscuser", "MSCUSER" },
                    { "bf704d5b-3971-4f86-b75e-07d625399087", null, "teamlead", "TEAMLEAD" },
                    { "d04e5b4c-10f0-4b2a-a25a-3fbe26f63566", null, "user", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "418cb504-2c5d-4e58-9059-e22de9594e74", 0, "695d3411-4b97-44c1-9475-4c117fb9d74e", "guestuser@finalproject.co.uk", true, false, null, "GUESTUSER@FINALPROJECT.CO.UK", "GUESTUSER@FINALPROJECT.CO.UK", "AQAAAAIAAYagAAAAENRm7KWpz42YurvR6qKJP8cGksDAvssC55HEG3FYSTLzpO87hRYPxxGEcEwsGOrraw==", null, false, "1ecfdc98-7c44-444a-a9d5-43373e00c98f", false, "guestuser" },
                    { "a478c1b6-20aa-48e9-9abf-7e7c3bfcbd3e", 0, "321ba5eb-92ed-471a-bcca-6de713418ce7", "admin@finalproject.co.uk", true, false, null, "ADMIN@FINALPROJECT.CO.UK", "ADMIN@FINALPROJECT.CO.UK", "AQAAAAIAAYagAAAAEIRTERi3J9t0qJH7do3jaJphdh3nxDEvzYxrcBY4PQDmigZC+iH65mgx422C2Z3xGA==", null, false, "ee24f2f8-a33c-41fa-9d2a-fd88ee0b67a5", false, "admin" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "d04e5b4c-10f0-4b2a-a25a-3fbe26f63566", "418cb504-2c5d-4e58-9059-e22de9594e74" },
                    { "392f7177-e777-4ffc-a57d-2ed84d16ae01", "a478c1b6-20aa-48e9-9abf-7e7c3bfcbd3e" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9e30e59b-edd6-4cf2-b8d1-c254f43549dd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bf704d5b-3971-4f86-b75e-07d625399087");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d04e5b4c-10f0-4b2a-a25a-3fbe26f63566", "418cb504-2c5d-4e58-9059-e22de9594e74" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "392f7177-e777-4ffc-a57d-2ed84d16ae01", "a478c1b6-20aa-48e9-9abf-7e7c3bfcbd3e" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "392f7177-e777-4ffc-a57d-2ed84d16ae01");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d04e5b4c-10f0-4b2a-a25a-3fbe26f63566");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "418cb504-2c5d-4e58-9059-e22de9594e74");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a478c1b6-20aa-48e9-9abf-7e7c3bfcbd3e");
        }
    }
}
