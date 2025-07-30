using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Horta_Api.Migrations
{
    /// <inheritdoc />
    public partial class alltables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "user_logs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IpAddress = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserAgent = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_logs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    TokenId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    UserAgent = table.Column<string>(type: "text", nullable: false),
                    IpAddress = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserLogId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.TokenId);
                    table.ForeignKey(
                        name: "FK_users_user_logs_UserLogId",
                        column: x => x.UserLogId,
                        principalTable: "user_logs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "main_controllers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IpAddress = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: false),
                    LightStatus = table.Column<bool>(type: "boolean", nullable: false),
                    PumpRelayStatus = table.Column<bool>(type: "boolean", nullable: false),
                    UserTokenId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_main_controllers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_main_controllers_users_UserTokenId",
                        column: x => x.UserTokenId,
                        principalTable: "users",
                        principalColumn: "TokenId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "light_sensors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Value = table.Column<float>(type: "real", nullable: false),
                    MainControllerId = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_light_sensors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_light_sensors_main_controllers_MainControllerId",
                        column: x => x.MainControllerId,
                        principalTable: "main_controllers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "temperature_sensors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Value = table.Column<float>(type: "real", nullable: false),
                    MainControllerId = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_temperature_sensors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_temperature_sensors_main_controllers_MainControllerId",
                        column: x => x.MainControllerId,
                        principalTable: "main_controllers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "water_level_sensors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Value = table.Column<float>(type: "real", nullable: false),
                    MainControllerId = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_water_level_sensors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_water_level_sensors_main_controllers_MainControllerId",
                        column: x => x.MainControllerId,
                        principalTable: "main_controllers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_light_sensors_MainControllerId",
                table: "light_sensors",
                column: "MainControllerId");

            migrationBuilder.CreateIndex(
                name: "IX_main_controllers_UserTokenId",
                table: "main_controllers",
                column: "UserTokenId");

            migrationBuilder.CreateIndex(
                name: "IX_temperature_sensors_MainControllerId",
                table: "temperature_sensors",
                column: "MainControllerId");

            migrationBuilder.CreateIndex(
                name: "IX_users_UserLogId",
                table: "users",
                column: "UserLogId");

            migrationBuilder.CreateIndex(
                name: "IX_water_level_sensors_MainControllerId",
                table: "water_level_sensors",
                column: "MainControllerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "light_sensors");

            migrationBuilder.DropTable(
                name: "temperature_sensors");

            migrationBuilder.DropTable(
                name: "water_level_sensors");

            migrationBuilder.DropTable(
                name: "main_controllers");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "user_logs");
        }
    }
}
