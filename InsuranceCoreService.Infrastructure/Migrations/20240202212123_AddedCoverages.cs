using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InsuranceCoreService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedCoverages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Coverages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InsuranceId = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coverages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Coverages_Insurances_InsuranceId",
                        column: x => x.InsuranceId,
                        principalTable: "Insurances",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InsuranceCoverages",
                columns: table => new
                {
                    InsuranceId = table.Column<int>(type: "int", nullable: false),
                    CoverageId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsuranceCoverages", x => new { x.InsuranceId, x.CoverageId });
                    table.ForeignKey(
                        name: "FK_InsuranceCoverages_Coverages_CoverageId",
                        column: x => x.CoverageId,
                        principalTable: "Coverages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InsuranceCoverages_Insurances_InsuranceId",
                        column: x => x.InsuranceId,
                        principalTable: "Insurances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Coverages_InsuranceId",
                table: "Coverages",
                column: "InsuranceId");

            migrationBuilder.CreateIndex(
                name: "IX_InsuranceCoverages_CoverageId",
                table: "InsuranceCoverages",
                column: "CoverageId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InsuranceCoverages");

            migrationBuilder.DropTable(
                name: "Coverages");
        }
    }
}
