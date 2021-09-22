using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SICAU.App.Persistencia.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "materias",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    materia = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_materias", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "salones",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    numero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    capacidad = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_salones", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "sedes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ubicacion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sedes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "personas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    apellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    identificacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    estadoCovid = table.Column<int>(type: "int", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    unidad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    carrera = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    semestre = table.Column<int>(type: "int", nullable: true),
                    turno = table.Column<int>(type: "int", nullable: true),
                    departamento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    materiaid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_personas", x => x.id);
                    table.ForeignKey(
                        name: "FK_personas_materias_materiaid",
                        column: x => x.materiaid,
                        principalTable: "materias",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "encuestas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fechaEncuesta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    estadoCovid = table.Column<int>(type: "int", nullable: false),
                    fechaDiagnostico = table.Column<DateTime>(type: "datetime2", nullable: false),
                    personaid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_encuestas", x => x.id);
                    table.ForeignKey(
                        name: "FK_encuestas_personas_personaid",
                        column: x => x.personaid,
                        principalTable: "personas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "horarios",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    horaIngreso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    materiaid = table.Column<int>(type: "int", nullable: true),
                    diasemana = table.Column<int>(type: "int", nullable: false),
                    duracion = table.Column<int>(type: "int", nullable: false),
                    personaid = table.Column<int>(type: "int", nullable: true),
                    salonid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_horarios", x => x.id);
                    table.ForeignKey(
                        name: "FK_horarios_materias_materiaid",
                        column: x => x.materiaid,
                        principalTable: "materias",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_horarios_personas_personaid",
                        column: x => x.personaid,
                        principalTable: "personas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_horarios_salones_salonid",
                        column: x => x.salonid,
                        principalTable: "salones",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "sintomas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sintoma = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Encuestaid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sintomas", x => x.id);
                    table.ForeignKey(
                        name: "FK_sintomas_encuestas_Encuestaid",
                        column: x => x.Encuestaid,
                        principalTable: "encuestas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_encuestas_personaid",
                table: "encuestas",
                column: "personaid");

            migrationBuilder.CreateIndex(
                name: "IX_horarios_materiaid",
                table: "horarios",
                column: "materiaid");

            migrationBuilder.CreateIndex(
                name: "IX_horarios_personaid",
                table: "horarios",
                column: "personaid");

            migrationBuilder.CreateIndex(
                name: "IX_horarios_salonid",
                table: "horarios",
                column: "salonid");

            migrationBuilder.CreateIndex(
                name: "IX_personas_materiaid",
                table: "personas",
                column: "materiaid");

            migrationBuilder.CreateIndex(
                name: "IX_sintomas_Encuestaid",
                table: "sintomas",
                column: "Encuestaid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "horarios");

            migrationBuilder.DropTable(
                name: "sedes");

            migrationBuilder.DropTable(
                name: "sintomas");

            migrationBuilder.DropTable(
                name: "salones");

            migrationBuilder.DropTable(
                name: "encuestas");

            migrationBuilder.DropTable(
                name: "personas");

            migrationBuilder.DropTable(
                name: "materias");
        }
    }
}
