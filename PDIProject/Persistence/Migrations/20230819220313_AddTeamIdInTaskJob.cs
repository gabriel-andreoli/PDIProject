using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PDIProject.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddTeamIdInTaskJob : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TeamId",
                table: "TaskJobs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TeamId",
                table: "TaskJobs");
        }
    }
}
