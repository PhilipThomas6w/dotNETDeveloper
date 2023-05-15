using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpartaToDo.App.Migrations
{
    /// <inheritdoc />
    public partial class SpartanAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SpartanId",
                table: "ToDoItems",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_ToDoItems_SpartanId",
                table: "ToDoItems",
                column: "SpartanId");

            migrationBuilder.AddForeignKey(
                name: "FK_ToDoItems_AspNetUsers_SpartanId",
                table: "ToDoItems",
                column: "SpartanId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDoItems_AspNetUsers_SpartanId",
                table: "ToDoItems");

            migrationBuilder.DropIndex(
                name: "IX_ToDoItems_SpartanId",
                table: "ToDoItems");

            migrationBuilder.DropColumn(
                name: "SpartanId",
                table: "ToDoItems");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");
        }
    }
}
