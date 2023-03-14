using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjektKatthem.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddingAdoptCat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CatsAdopted",
                table: "Adopt",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CatsAdopted",
                table: "Adopt");
        }
    }
}
