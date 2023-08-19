using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PDIProject.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RemoveCompanyIdInAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Adresses");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Adresses",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
