using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEnd.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Member",
                columns: table => new
                {
                    CardNumber = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BloodGroup = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoomNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Block = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Session = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Year = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => x.CardNumber);
                });

            migrationBuilder.CreateTable(
                name: "Session",
                columns: table => new
                {
                    SessionNumber = table.Column<int>(type: "int", nullable: false),
                    SessionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstOfMonth = table.Column<bool>(type: "bit", nullable: false),
                    ManagerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CardNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Session", x => x.SessionNumber);
                });

            migrationBuilder.CreateTable(
                name: "FundCollection",
                columns: table => new
                {
                    ReceiptNumber = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    SessionNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FundCollection", x => x.ReceiptNumber);
                    table.ForeignKey(
                        name: "FK_FundCollection_Session_SessionNumber",
                        column: x => x.SessionNumber,
                        principalTable: "Session",
                        principalColumn: "SessionNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "purchage",
                columns: table => new
                {
                    SerialNumber = table.Column<int>(type: "int", nullable: false),
                    Dated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Items = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    SessionNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_purchage", x => x.SerialNumber);
                    table.ForeignKey(
                        name: "FK_purchage_Session_SessionNumber",
                        column: x => x.SessionNumber,
                        principalTable: "Session",
                        principalColumn: "SessionNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FundCollection_SessionNumber",
                table: "FundCollection",
                column: "SessionNumber");

            migrationBuilder.CreateIndex(
                name: "IX_purchage_SessionNumber",
                table: "purchage",
                column: "SessionNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FundCollection");

            migrationBuilder.DropTable(
                name: "Member");

            migrationBuilder.DropTable(
                name: "purchage");

            migrationBuilder.DropTable(
                name: "Session");
        }
    }
}
