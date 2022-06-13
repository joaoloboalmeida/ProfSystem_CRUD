using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProfSystem.Migrations
{
    public partial class UpdateDatabaseV6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Professional_Phone",
                table: "Professional",
                column: "Phone",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Professional_Phone",
                table: "Professional");
        }
    }
}
