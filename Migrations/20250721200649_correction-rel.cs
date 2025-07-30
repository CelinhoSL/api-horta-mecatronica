using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Horta_Api.Migrations
{
    /// <inheritdoc />
    public partial class correctionrel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_main_controllers_users_UserTokenId",
                table: "main_controllers");

            migrationBuilder.DropForeignKey(
                name: "FK_users_user_logs_UserLogId",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_users",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_users_UserLogId",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_main_controllers_UserTokenId",
                table: "main_controllers");

            migrationBuilder.DropColumn(
                name: "UserLogId",
                table: "users");

            migrationBuilder.DropColumn(
                name: "UserTokenId",
                table: "main_controllers");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "users",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<string>(
                name: "TokenId",
                table: "users",
                type: "text",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "user_logs",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "main_controllers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_users",
                table: "users",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_user_logs_UserId",
                table: "user_logs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_main_controllers_UserId",
                table: "main_controllers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_main_controllers_users_UserId",
                table: "main_controllers",
                column: "UserId",
                principalTable: "users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_user_logs_users_UserId",
                table: "user_logs",
                column: "UserId",
                principalTable: "users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_main_controllers_users_UserId",
                table: "main_controllers");

            migrationBuilder.DropForeignKey(
                name: "FK_user_logs_users_UserId",
                table: "user_logs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_users",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_user_logs_UserId",
                table: "user_logs");

            migrationBuilder.DropIndex(
                name: "IX_main_controllers_UserId",
                table: "main_controllers");

            migrationBuilder.DropColumn(
                name: "email",
                table: "users");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "user_logs");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "main_controllers");

            migrationBuilder.AlterColumn<Guid>(
                name: "TokenId",
                table: "users",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "users",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "UserLogId",
                table: "users",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "UserTokenId",
                table: "main_controllers",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_users",
                table: "users",
                column: "TokenId");

            migrationBuilder.CreateIndex(
                name: "IX_users_UserLogId",
                table: "users",
                column: "UserLogId");

            migrationBuilder.CreateIndex(
                name: "IX_main_controllers_UserTokenId",
                table: "main_controllers",
                column: "UserTokenId");

            migrationBuilder.AddForeignKey(
                name: "FK_main_controllers_users_UserTokenId",
                table: "main_controllers",
                column: "UserTokenId",
                principalTable: "users",
                principalColumn: "TokenId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_users_user_logs_UserLogId",
                table: "users",
                column: "UserLogId",
                principalTable: "user_logs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
