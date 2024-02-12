using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InsuranceCoreService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Insurers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<decimal>(
                name: "YearlyPremium",
                table: "Insurances",
                type: "decimal(18,4)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndPeriod",
                table: "Insurances",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartPeriod",
                table: "Insurances",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Insurers");

            migrationBuilder.DropColumn(
                name: "EndPeriod",
                table: "Insurances");

            migrationBuilder.DropColumn(
                name: "StartPeriod",
                table: "Insurances");

            migrationBuilder.AlterColumn<decimal>(
                name: "YearlyPremium",
                table: "Insurances",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)");
        }
    }
}
