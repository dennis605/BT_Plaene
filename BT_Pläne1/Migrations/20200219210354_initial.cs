using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BT_Pläne1.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    EventId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventEnd = table.Column<DateTime>(nullable: false),
                    EventVorlauf = table.Column<int>(nullable: false),
                    EventOrt = table.Column<string>(nullable: true),
                    EventBeschreibung = table.Column<string>(nullable: true),
                    EventInfo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.EventId);
                });

            migrationBuilder.CreateTable(
                name: "Personen",
                columns: table => new
                {
                    PersonId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vorname = table.Column<string>(nullable: true),
                    Nachname = table.Column<string>(nullable: true),
                    Rolle = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personen", x => x.PersonId);
                });

            migrationBuilder.CreateTable(
                name: "PersonenEvent",
                columns: table => new
                {
                    EventId = table.Column<int>(nullable: false),
                    PersonId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonenEvent", x => new { x.PersonId, x.EventId });
                    table.ForeignKey(
                        name: "FK_PersonenEvent_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonenEvent_Personen_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Personen",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Personen_Vorname_Nachname_Rolle",
                table: "Personen",
                columns: new[] { "Vorname", "Nachname", "Rolle" });

            migrationBuilder.CreateIndex(
                name: "IX_PersonenEvent_EventId",
                table: "PersonenEvent",
                column: "EventId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonenEvent");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Personen");
        }
    }
}
