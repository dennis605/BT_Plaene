using Microsoft.EntityFrameworkCore.Migrations;

namespace BT_Pläne1.Migrations
{
    public partial class mitevent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "Personen",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Personen_EventId",
                table: "Personen",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Personen_Events_EventId",
                table: "Personen",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personen_Events_EventId",
                table: "Personen");

            migrationBuilder.DropIndex(
                name: "IX_Personen_EventId",
                table: "Personen");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "Personen");
        }
    }
}
