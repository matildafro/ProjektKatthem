using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjektKatthem.Data.Migrations
{
    /// <inheritdoc />
    public partial class NewModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: true),
                    Breed = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImgName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adopted = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Registered = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Adopt",
                columns: table => new
                {
                    AdoptId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdoptName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Number = table.Column<int>(type: "int", nullable: true),
                    Pickup = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CatsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adopt", x => x.AdoptId);
                    table.ForeignKey(
                        name: "FK_Adopt_Cats_CatsId",
                        column: x => x.CatsId,
                        principalTable: "Cats",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adopt_CatsId",
                table: "Adopt",
                column: "CatsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adopt");

            migrationBuilder.DropTable(
                name: "Cats");
        }
    }
}
