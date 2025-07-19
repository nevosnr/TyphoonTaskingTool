using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TyphoonTaskingTool.Migrations.TaskingTool
{
    /// <inheritdoc />
    public partial class InitialTaskingSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LOOKUP_Rank",
                columns: table => new
                {
                    Rank_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rank_NameLong = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Rank_NameShort = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Rank_NATOEquiv = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__LOOKUP_R__25BE3A45C8792EA9", x => x.Rank_Id);
                });

            migrationBuilder.CreateTable(
                name: "LOOKUP_Status",
                columns: table => new
                {
                    Status_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status_Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Status_Description = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__LOOKUP_S__5190094C594F5F23", x => x.Status_Id);
                });

            migrationBuilder.CreateTable(
                name: "LOOKUP_Team",
                columns: table => new
                {
                    Team_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Team_NameLong = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    Team_NameShort = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__LOOKUP_T__02215C6AEBF1AF51", x => x.Team_Id);
                });

            migrationBuilder.CreateTable(
                name: "LOOKUP_Unit",
                columns: table => new
                {
                    Unit_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Unit_NameLong = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    Unit_NameShort = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__LOOKUP_U__27556B78AA3A02A9", x => x.Unit_Id);
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    Request_TaskId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Request_ShortId = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    Request_Created = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "(sysdatetime())"),
                    Rank_Id = table.Column<int>(type: "int", nullable: true),
                    Request_FirstName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Request_LastName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Request_EmailAdd = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    Request_ContactPhone = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    Unit_Id = table.Column<int>(type: "int", nullable: true),
                    Team_Id = table.Column<int>(type: "int", nullable: true),
                    Request_Title = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    Request_TaskDescription = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Status_Id = table.Column<int>(type: "int", nullable: true),
                    Request_Archive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Requests__369BD5A545908220", x => x.Request_TaskId);
                    table.ForeignKey(
                        name: "FK_Request_Rank",
                        column: x => x.Rank_Id,
                        principalTable: "LOOKUP_Rank",
                        principalColumn: "Rank_Id");
                    table.ForeignKey(
                        name: "FK_Request_Status",
                        column: x => x.Status_Id,
                        principalTable: "LOOKUP_Status",
                        principalColumn: "Status_Id");
                    table.ForeignKey(
                        name: "FK_Request_Team",
                        column: x => x.Team_Id,
                        principalTable: "LOOKUP_Team",
                        principalColumn: "Team_Id");
                    table.ForeignKey(
                        name: "FK_Request_Unit",
                        column: x => x.Unit_Id,
                        principalTable: "LOOKUP_Unit",
                        principalColumn: "Unit_Id");
                });

            migrationBuilder.CreateTable(
                name: "RequestUpdates",
                columns: table => new
                {
                    Update_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Request_TaskId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Update_TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "(sysdatetime())"),
                    Update_Description = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Update_By = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Status_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__RequestU__C11655E4EB5F5284", x => x.Update_Id);
                    table.ForeignKey(
                        name: "FK_UpdateRequest",
                        column: x => x.Request_TaskId,
                        principalTable: "Requests",
                        principalColumn: "Request_TaskId");
                    table.ForeignKey(
                        name: "FK_UpdateStatus",
                        column: x => x.Status_Id,
                        principalTable: "LOOKUP_Status",
                        principalColumn: "Status_Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Requests_Rank_Id",
                table: "Requests",
                column: "Rank_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_Status_Id",
                table: "Requests",
                column: "Status_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_Team_Id",
                table: "Requests",
                column: "Team_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_Unit_Id",
                table: "Requests",
                column: "Unit_Id");

            migrationBuilder.CreateIndex(
                name: "IX_RequestUpdates_Request_TaskId",
                table: "RequestUpdates",
                column: "Request_TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestUpdates_Status_Id",
                table: "RequestUpdates",
                column: "Status_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RequestUpdates");

            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropTable(
                name: "LOOKUP_Rank");

            migrationBuilder.DropTable(
                name: "LOOKUP_Status");

            migrationBuilder.DropTable(
                name: "LOOKUP_Team");

            migrationBuilder.DropTable(
                name: "LOOKUP_Unit");
        }
    }
}
