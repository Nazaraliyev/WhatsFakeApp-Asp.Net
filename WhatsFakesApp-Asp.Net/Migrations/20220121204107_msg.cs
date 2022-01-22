using Microsoft.EntityFrameworkCore.Migrations;

namespace WhatsFakesApp_Asp.Net.Migrations
{
    public partial class msg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_messages_AspNetUsers_ReceiverId1",
                table: "messages");

            migrationBuilder.DropForeignKey(
                name: "FK_messages_AspNetUsers_SenderId1",
                table: "messages");

            migrationBuilder.DropIndex(
                name: "IX_messages_ReceiverId1",
                table: "messages");

            migrationBuilder.DropIndex(
                name: "IX_messages_SenderId1",
                table: "messages");

            migrationBuilder.DropColumn(
                name: "ReceiverId1",
                table: "messages");

            migrationBuilder.DropColumn(
                name: "SenderId1",
                table: "messages");

            migrationBuilder.AlterColumn<string>(
                name: "SenderId",
                table: "messages",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "ReceiverId",
                table: "messages",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SenderId",
                table: "messages",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ReceiverId",
                table: "messages",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReceiverId1",
                table: "messages",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SenderId1",
                table: "messages",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_messages_ReceiverId1",
                table: "messages",
                column: "ReceiverId1");

            migrationBuilder.CreateIndex(
                name: "IX_messages_SenderId1",
                table: "messages",
                column: "SenderId1");

            migrationBuilder.AddForeignKey(
                name: "FK_messages_AspNetUsers_ReceiverId1",
                table: "messages",
                column: "ReceiverId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_messages_AspNetUsers_SenderId1",
                table: "messages",
                column: "SenderId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
