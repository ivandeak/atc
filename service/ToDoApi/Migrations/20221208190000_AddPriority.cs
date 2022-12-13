using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDoApi.Migrations
{
    public partial class AddPriority : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Priority",
                table: "ToDoItems",
                type: "TEXT",
                maxLength: 100,
                nullable: false,
                defaultValue: "NORMAL");

            migrationBuilder.Sql("UPDATE ToDoItems SET Priority = 'NORMAL'");

            migrationBuilder.AlterColumn<string>(
                name: "Priority",
                table: "ToDoItems",
                defaultValue: null);
        }
    }
}
