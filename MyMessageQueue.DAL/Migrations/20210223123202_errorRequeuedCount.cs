using Microsoft.EntityFrameworkCore.Migrations;

namespace MyMessageQueue.DAL.Migrations
{
    public partial class errorRequeuedCount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ErrorRequeuedCount",
                table: "MyMessageQueue",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RequedCount",
                table: "MyMessageQueue",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ErrorRequeuedCount",
                table: "MyMessageQueue");

            migrationBuilder.DropColumn(
                name: "RequedCount",
                table: "MyMessageQueue");
        }
    }
}
