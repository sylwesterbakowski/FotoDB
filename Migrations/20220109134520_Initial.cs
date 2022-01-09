using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FotoDB.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Krajs",
                columns: table => new
                {
                    KrajModelID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Krajs", x => x.KrajModelID);
                });

            migrationBuilder.CreateTable(
                name: "Autors",
                columns: table => new
                {
                    AutorModelID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwisko = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Imie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KrajModelID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autors", x => x.AutorModelID);
                    table.ForeignKey(
                        name: "FK_Autors_Krajs_KrajModelID",
                        column: x => x.KrajModelID,
                        principalTable: "Krajs",
                        principalColumn: "KrajModelID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Fotos",
                columns: table => new
                {
                    FotoModelID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataWykonania = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FotoTytul = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FotoData = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    FotoRozszerzenie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AutorModelID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fotos", x => x.FotoModelID);
                    table.ForeignKey(
                        name: "FK_Fotos_Autors_AutorModelID",
                        column: x => x.AutorModelID,
                        principalTable: "Autors",
                        principalColumn: "AutorModelID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Autors_KrajModelID",
                table: "Autors",
                column: "KrajModelID");

            migrationBuilder.CreateIndex(
                name: "IX_Fotos_AutorModelID",
                table: "Fotos",
                column: "AutorModelID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fotos");

            migrationBuilder.DropTable(
                name: "Autors");

            migrationBuilder.DropTable(
                name: "Krajs");
        }
    }
}
