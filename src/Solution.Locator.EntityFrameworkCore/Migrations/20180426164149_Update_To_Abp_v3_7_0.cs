using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Solution.Locator.Migrations
{
    public partial class Update_To_Abp_v3_7_0 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AbpGame_AbpFriend_FriendId",
                table: "AbpGame");

            migrationBuilder.DropIndex(
                name: "IX_AbpGame_FriendId",
                table: "AbpGame");

            migrationBuilder.DropColumn(
                name: "FriendId",
                table: "AbpGame");

            migrationBuilder.AddColumn<int>(
                name: "IdFriend",
                table: "AbpGame",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AbpGame_IdFriend",
                table: "AbpGame",
                column: "IdFriend");

            migrationBuilder.AddForeignKey(
                name: "FK_AbpGame_AbpFriend_IdFriend",
                table: "AbpGame",
                column: "IdFriend",
                principalTable: "AbpFriend",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AbpGame_AbpFriend_IdFriend",
                table: "AbpGame");

            migrationBuilder.DropIndex(
                name: "IX_AbpGame_IdFriend",
                table: "AbpGame");

            migrationBuilder.DropColumn(
                name: "IdFriend",
                table: "AbpGame");

            migrationBuilder.AddColumn<int>(
                name: "FriendId",
                table: "AbpGame",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AbpGame_FriendId",
                table: "AbpGame",
                column: "FriendId");

            migrationBuilder.AddForeignKey(
                name: "FK_AbpGame_AbpFriend_FriendId",
                table: "AbpGame",
                column: "FriendId",
                principalTable: "AbpFriend",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
