using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InsuranceCoreService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AdjustedManyToManyTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Coverages_Insurances_InsuranceId",
                table: "Coverages");

            migrationBuilder.DropIndex(
                name: "IX_Coverages_InsuranceId",
                table: "Coverages");

            migrationBuilder.DropColumn(
                name: "InsuranceId",
                table: "Coverages");

            migrationBuilder.CreateTable(
                name: "InsuranceCoverage",
                columns: table => new
                {
                    CoveragesId = table.Column<int>(type: "int", nullable: false),
                    InsurancesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsuranceCoverage", x => new { x.CoveragesId, x.InsurancesId });
                    table.ForeignKey(
                        name: "FK_InsuranceCoverage_Coverages_CoveragesId",
                        column: x => x.CoveragesId,
                        principalTable: "Coverages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InsuranceCoverage_Insurances_InsurancesId",
                        column: x => x.InsurancesId,
                        principalTable: "Insurances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InsuranceCoverage_InsurancesId",
                table: "InsuranceCoverage",
                column: "InsurancesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InsuranceCoverage");

            migrationBuilder.AddColumn<int>(
                name: "InsuranceId",
                table: "Coverages",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Coverages_InsuranceId",
                table: "Coverages",
                column: "InsuranceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Coverages_Insurances_InsuranceId",
                table: "Coverages",
                column: "InsuranceId",
                principalTable: "Insurances",
                principalColumn: "Id");
        }
    }
}
