using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDoApi.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ToDoItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Content = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    Status = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    CreatedDate = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDoItems", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ToDoItems",
                columns: new[] { "Id", "Content", "CreatedDate", "Status" },
                values: new object[] { new Guid("35bbef83-2b66-4d94-b1b6-075b5172868f"), "Finish up work on latest feature", 1305581813669744640L, "PENDING" });

            migrationBuilder.InsertData(
                table: "ToDoItems",
                columns: new[] { "Id", "Content", "CreatedDate", "Status" },
                values: new object[] { new Guid("38560f1d-83aa-4824-a39d-f81b2ac4ae81"), "Make a bitmoji", 1305581813628784640L, "PENDING" });

            migrationBuilder.InsertData(
                table: "ToDoItems",
                columns: new[] { "Id", "Content", "CreatedDate", "Status" },
                values: new object[] { new Guid("e404faa1-7a06-41d2-87b8-7ddfb9e7300c"), "Buy bread", 1305581813587824640L, "PENDING" });

            migrationBuilder.InsertData(
                table: "ToDoItems",
                columns: new[] { "Id", "Content", "CreatedDate", "Status" },
                values: new object[] { new Guid("cf185182-88c1-4413-969d-733cea151b1a"), "Follow up with Sam RE Friday night", 1305581813546864640L, "PENDING" });

            migrationBuilder.InsertData(
                table: "ToDoItems",
                columns: new[] { "Id", "Content", "CreatedDate", "Status" },
                values: new object[] { new Guid("eb60226c-f9a0-44fc-887c-ec98ce39f433"), "Cat flea treatment", 1305581813459476480L, "PENDING" });

            migrationBuilder.InsertData(
                table: "ToDoItems",
                columns: new[] { "Id", "Content", "CreatedDate", "Status" },
                values: new object[] { new Guid("cc552a5d-a3e4-4e5e-bcb0-3ec3d249a3f9"), "Daily walk", 1305581813393141760L, "PENDING" });

            migrationBuilder.InsertData(
                table: "ToDoItems",
                columns: new[] { "Id", "Content", "CreatedDate", "Status" },
                values: new object[] { new Guid("ad35676c-81a0-48c3-8af6-4d8dd41671f0"), "Take out the rubbish", 1305581813239767040L, "DONE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ToDoItems");
        }
    }
}
