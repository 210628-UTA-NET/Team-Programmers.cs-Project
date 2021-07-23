using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp.Migrations
{
    public partial class ChangeColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ColumnType",
                table: "KanbanCards");

            migrationBuilder.AddColumn<int>(
                name: "Column",
                table: "KanbanCards",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Column",
                table: "KanbanCards");

            migrationBuilder.AddColumn<string>(
                name: "ColumnType",
                table: "KanbanCards",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
