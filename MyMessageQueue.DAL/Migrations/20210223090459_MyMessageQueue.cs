using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyMessageQueue.DAL.Migrations
{
    public partial class MyMessageQueue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MyMessageQueue",
                columns: table => new
                {
                    QueueMessageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MessageTimestamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyMessageQueue", x => x.QueueMessageId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MyMessageQueue");
        }
    }
}
