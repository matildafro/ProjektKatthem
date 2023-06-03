using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjektKatthem.Data.Migrations
{
    /// <inheritdoc />
    public partial class NewFieldModelAndNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Gender",
                table: "Cats",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Info",
                table: "Cats",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Number",
                table: "Adopt",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Cats");

            migrationBuilder.DropColumn(
                name: "Info",
                table: "Cats");

            migrationBuilder.AlterColumn<int>(
                name: "Number",
                table: "Adopt",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
