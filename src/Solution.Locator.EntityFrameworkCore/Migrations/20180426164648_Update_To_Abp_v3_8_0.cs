using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Solution.Locator.Migrations
{
    public partial class Update_To_Abp_v3_8_0 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AbpGame_AbpFriend_IdFriend",
                table: "AbpGame");

            migrationBuilder.AlterColumn<int>(
                name: "IdFriend",
                table: "AbpGame",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_AbpGame_AbpFriend_IdFriend",
                table: "AbpGame",
                column: "IdFriend",
                principalTable: "AbpFriend",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AbpGame_AbpFriend_IdFriend",
                table: "AbpGame");

            migrationBuilder.AlterColumn<int>(
                name: "IdFriend",
                table: "AbpGame",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AbpGame_AbpFriend_IdFriend",
                table: "AbpGame",
                column: "IdFriend",
                principalTable: "AbpFriend",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
