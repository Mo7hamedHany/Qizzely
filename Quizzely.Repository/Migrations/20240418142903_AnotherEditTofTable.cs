using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Quizzely.Repository.Migrations
{
    public partial class AnotherEditTofTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ToF",
                table: "TofQuestions");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ToF",
                table: "TofQuestions",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
