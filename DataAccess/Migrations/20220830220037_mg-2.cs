using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class mg2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chats_ChatMembers_ChatMemberId",
                table: "Chats");

            migrationBuilder.DropTable(
                name: "AppUserChatMember");

            migrationBuilder.DropIndex(
                name: "IX_Chats_ChatMemberId",
                table: "Chats");

            migrationBuilder.DropColumn(
                name: "ChatMemberId",
                table: "Chats");

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "ChatMembers",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ChatMembers_AppUserId",
                table: "ChatMembers",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatMembers_AspNetUsers_AppUserId",
                table: "ChatMembers",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatMembers_AspNetUsers_AppUserId",
                table: "ChatMembers");

            migrationBuilder.DropIndex(
                name: "IX_ChatMembers_AppUserId",
                table: "ChatMembers");

            migrationBuilder.AddColumn<Guid>(
                name: "ChatMemberId",
                table: "Chats",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "ChatMembers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "AppUserChatMember",
                columns: table => new
                {
                    AppUsersId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ChatMembersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserChatMember", x => new { x.AppUsersId, x.ChatMembersId });
                    table.ForeignKey(
                        name: "FK_AppUserChatMember_AspNetUsers_AppUsersId",
                        column: x => x.AppUsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppUserChatMember_ChatMembers_ChatMembersId",
                        column: x => x.ChatMembersId,
                        principalTable: "ChatMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Chats_ChatMemberId",
                table: "Chats",
                column: "ChatMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserChatMember_ChatMembersId",
                table: "AppUserChatMember",
                column: "ChatMembersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Chats_ChatMembers_ChatMemberId",
                table: "Chats",
                column: "ChatMemberId",
                principalTable: "ChatMembers",
                principalColumn: "Id");
        }
    }
}
