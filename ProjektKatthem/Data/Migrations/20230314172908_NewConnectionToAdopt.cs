using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjektKatthem.Data.Migrations
{
    /// <inheritdoc />
    public partial class NewConnectionToAdopt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Adopt_CatsId",
                table: "Adopt");

            migrationBuilder.CreateIndex(
                name: "IX_Adopt_CatsId",
                table: "Adopt",
                column: "CatsId",
                unique: true,
                filter: "[CatsId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Adopt_CatsId",
                table: "Adopt");

            migrationBuilder.CreateIndex(
                name: "IX_Adopt_CatsId",
                table: "Adopt",
                column: "CatsId");
        }
    }
}
