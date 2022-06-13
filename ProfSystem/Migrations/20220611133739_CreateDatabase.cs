using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProfSystem.Migrations
{
    public partial class CreateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Professional",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "NVARCHAR(200)", maxLength: 200, nullable: false),
                    Phone = table.Column<string>(type: "VARCHAR(21)", maxLength: 21, nullable: false),
                    Rg = table.Column<string>(type: "VARCHAR(30)", maxLength: 30, nullable: false),
                    Address = table.Column<string>(type: "NVARCHAR(250)", maxLength: 250, nullable: false),
                    Wage = table.Column<decimal>(type: "DECIMAL(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professional", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Professional");
        }
    }
}
