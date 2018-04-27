using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Solution.Locator.Migrations
{
    public partial class Update_To_Abp_v3_6_0 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AbpFriend",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    NickName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpFriend", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AbpGame",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    FriendId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpGame", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbpGame_AbpFriend_FriendId",
                        column: x => x.FriendId,
                        principalTable: "AbpFriend",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AbpGame_FriendId",
                table: "AbpGame",
                column: "FriendId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AbpGame");

            migrationBuilder.DropTable(
                name: "AbpFriend");
        }
    }
}
