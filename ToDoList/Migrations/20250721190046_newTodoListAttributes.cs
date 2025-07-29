using System;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoList.Migrations
{
    /// <inheritdoc />
    public partial class newTodoListAttributes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>
                (
                    name: "Priority",
                    table: "Todolist",
                    nullable: true
                );
            migrationBuilder.AlterColumn<int>
                (
                    name: "ID",
                    table: "Todolist",
                    nullable: true
                );
            migrationBuilder.AlterColumn<int>
                (
                    name: "CompletionDate",
                    table: "Todolist",
                    nullable: true
                );
            migrationBuilder.RenameColumn(
                name: "Item",
                table: "Todolist",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "IsDone",
                table: "Todolist",
                newName: "Priority");

            migrationBuilder.RenameColumn(
                name: "Comment",
                table: "Todolist",
                newName: "Status");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Todolist",
                type: "TEXT",
                nullable: true,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatedOn",
                table: "Todolist",
                type: "TEXT",
                nullable: true,
                defaultValue: DateTime.UtcNow);

            migrationBuilder.AddColumn<DateTime>(
                name: "DueDate",
                table: "Todolist",
                type: "TEXT",
                nullable: true,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Todolist");

            migrationBuilder.DropColumn(
                name: "DueDate",
                table: "Todolist");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Todolist",
                newName: "Item");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Todolist",
                newName: "Comment");

            migrationBuilder.RenameColumn(
                name: "Priority",
                table: "Todolist",
                newName: "IsDone");
        }
    }
}
