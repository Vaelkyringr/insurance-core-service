using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InsuranceCoreService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedFieldsForInsurance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "InsuranceNumber",
                table: "Insurances",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "YearlyPremium",
                table: "Insurances",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InsuranceNumber",
                table: "Insurances");

            migrationBuilder.DropColumn(
                name: "YearlyPremium",
                table: "Insurances");
        }
    }
}
