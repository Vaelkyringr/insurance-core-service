using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InsuranceCoreService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedPropertiesToCoverage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "BaseAmount",
                table: "Coverages",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "CoverageType",
                table: "Coverages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BaseAmount",
                table: "Coverages");

            migrationBuilder.DropColumn(
                name: "CoverageType",
                table: "Coverages");
        }
    }
}
