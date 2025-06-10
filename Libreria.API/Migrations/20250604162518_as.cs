using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Libreria.API.Migrations
{
    /// <inheritdoc />
    public partial class @as : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Paises",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capital = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Continente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Idioma = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Moneda = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paises", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "Autores",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaisCodigo = table.Column<int>(type: "int", nullable: false),
                    FechaNacmiento = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autores", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Autores_Paises_PaisCodigo",
                        column: x => x.PaisCodigo,
                        principalTable: "Paises",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Editoriales",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaisCodigo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Editoriales", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Editoriales_Paises_PaisCodigo",
                        column: x => x.PaisCodigo,
                        principalTable: "Paises",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Libros",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnioPublicacion = table.Column<int>(type: "int", nullable: false),
                    CantidadPaginas = table.Column<int>(type: "int", nullable: false),
                    CantidadEjemplares = table.Column<int>(type: "int", nullable: false),
                    PaisCodigo = table.Column<int>(type: "int", nullable: false),
                    AutorCodigo = table.Column<int>(type: "int", nullable: false),
                    EditorialCodigo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libros", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Libros_Autores_AutorCodigo",
                        column: x => x.AutorCodigo,
                        principalTable: "Autores",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Libros_Editoriales_EditorialCodigo",
                        column: x => x.EditorialCodigo,
                        principalTable: "Editoriales",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Libros_Paises_PaisCodigo",
                        column: x => x.PaisCodigo,
                        principalTable: "Paises",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Autores_PaisCodigo",
                table: "Autores",
                column: "PaisCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_Editoriales_PaisCodigo",
                table: "Editoriales",
                column: "PaisCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_Libros_AutorCodigo",
                table: "Libros",
                column: "AutorCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_Libros_EditorialCodigo",
                table: "Libros",
                column: "EditorialCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_Libros_PaisCodigo",
                table: "Libros",
                column: "PaisCodigo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Libros");

            migrationBuilder.DropTable(
                name: "Autores");

            migrationBuilder.DropTable(
                name: "Editoriales");

            migrationBuilder.DropTable(
                name: "Paises");
        }
    }
}
