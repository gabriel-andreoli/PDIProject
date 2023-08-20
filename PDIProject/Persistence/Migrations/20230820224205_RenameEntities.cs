using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PDIProject.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RenameEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskJobUsers_TaskJobs_TaskJobId",
                table: "TaskJobUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskJobUsers_Users_UserId",
                table: "TaskJobUsers");

            migrationBuilder.DropTable(
                name: "HabilitiesUsers");

            migrationBuilder.DropTable(
                name: "Habilities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskJobUsers",
                table: "TaskJobUsers");

            migrationBuilder.RenameTable(
                name: "TaskJobUsers",
                newName: "TaskJobsUsers");

            migrationBuilder.RenameIndex(
                name: "IX_TaskJobUsers_UserId",
                table: "TaskJobsUsers",
                newName: "IX_TaskJobsUsers_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskJobUsers_TaskJobId",
                table: "TaskJobsUsers",
                newName: "IX_TaskJobsUsers_TaskJobId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskJobsUsers",
                table: "TaskJobsUsers",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Abilities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abilities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AbilitiesUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    AbilityId = table.Column<int>(type: "int", nullable: false),
                    DateAcquisition = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbilitiesUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbilitiesUsers_Abilities_AbilityId",
                        column: x => x.AbilityId,
                        principalTable: "Abilities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AbilitiesUsers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AbilitiesUsers_AbilityId",
                table: "AbilitiesUsers",
                column: "AbilityId");

            migrationBuilder.CreateIndex(
                name: "IX_AbilitiesUsers_UserId",
                table: "AbilitiesUsers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskJobsUsers_TaskJobs_TaskJobId",
                table: "TaskJobsUsers",
                column: "TaskJobId",
                principalTable: "TaskJobs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskJobsUsers_Users_UserId",
                table: "TaskJobsUsers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskJobsUsers_TaskJobs_TaskJobId",
                table: "TaskJobsUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskJobsUsers_Users_UserId",
                table: "TaskJobsUsers");

            migrationBuilder.DropTable(
                name: "AbilitiesUsers");

            migrationBuilder.DropTable(
                name: "Abilities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskJobsUsers",
                table: "TaskJobsUsers");

            migrationBuilder.RenameTable(
                name: "TaskJobsUsers",
                newName: "TaskJobUsers");

            migrationBuilder.RenameIndex(
                name: "IX_TaskJobsUsers_UserId",
                table: "TaskJobUsers",
                newName: "IX_TaskJobUsers_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskJobsUsers_TaskJobId",
                table: "TaskJobUsers",
                newName: "IX_TaskJobUsers_TaskJobId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskJobUsers",
                table: "TaskJobUsers",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Habilities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Habilities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HabilitiesUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HabilityId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateAcquisition = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HabilitiesUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HabilitiesUsers_Habilities_HabilityId",
                        column: x => x.HabilityId,
                        principalTable: "Habilities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HabilitiesUsers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_HabilitiesUsers_HabilityId",
                table: "HabilitiesUsers",
                column: "HabilityId");

            migrationBuilder.CreateIndex(
                name: "IX_HabilitiesUsers_UserId",
                table: "HabilitiesUsers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskJobUsers_TaskJobs_TaskJobId",
                table: "TaskJobUsers",
                column: "TaskJobId",
                principalTable: "TaskJobs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskJobUsers_Users_UserId",
                table: "TaskJobUsers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
