using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SICAU.App.Persistencia.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "sintomas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sintoma = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sintomas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "universidades",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    universidad = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_universidades", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "facultades",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    facultad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    universidadid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_facultades", x => x.id);
                    table.ForeignKey(
                        name: "FK_facultades_universidades_universidadid",
                        column: x => x.universidadid,
                        principalTable: "universidades",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "sedes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sede = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ubicacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    universidadid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sedes", x => x.id);
                    table.ForeignKey(
                        name: "FK_sedes_universidades_universidadid",
                        column: x => x.universidadid,
                        principalTable: "universidades",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "programas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    programa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    facultadid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_programas", x => x.id);
                    table.ForeignKey(
                        name: "FK_programas_facultades_facultadid",
                        column: x => x.facultadid,
                        principalTable: "facultades",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "salones",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    numero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    capacidad = table.Column<int>(type: "int", nullable: false),
                    sedeid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_salones", x => x.id);
                    table.ForeignKey(
                        name: "FK_salones_sedes_sedeid",
                        column: x => x.sedeid,
                        principalTable: "sedes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "materias",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    materia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    programaid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_materias", x => x.id);
                    table.ForeignKey(
                        name: "FK_materias_programas_programaid",
                        column: x => x.programaid,
                        principalTable: "programas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
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
                    sedeid = table.Column<int>(type: "int", nullable: true),
                    semestre = table.Column<int>(type: "int", nullable: true),
                    programaid = table.Column<int>(type: "int", nullable: true),
                    turno = table.Column<int>(type: "int", nullable: true),
                    PersonalAseo_sedeid = table.Column<int>(type: "int", nullable: true),
                    departamento = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_personas", x => x.id);
                    table.ForeignKey(
                        name: "FK_personas_programas_programaid",
                        column: x => x.programaid,
                        principalTable: "programas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_personas_sedes_PersonalAseo_sedeid",
                        column: x => x.PersonalAseo_sedeid,
                        principalTable: "sedes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_personas_sedes_sedeid",
                        column: x => x.sedeid,
                        principalTable: "sedes",
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
                    duracion = table.Column<int>(type: "int", nullable: false),
                    diaSemana = table.Column<int>(type: "int", nullable: false),
                    salonid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_horarios", x => x.id);
                    table.ForeignKey(
                        name: "FK_horarios_salones_salonid",
                        column: x => x.salonid,
                        principalTable: "salones",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "encuestaCovids",
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
                    table.PrimaryKey("PK_encuestaCovids", x => x.id);
                    table.ForeignKey(
                        name: "FK_encuestaCovids_personas_personaid",
                        column: x => x.personaid,
                        principalTable: "personas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "grupos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    numeroGrupo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    profesorid = table.Column<int>(type: "int", nullable: true),
                    materiaid = table.Column<int>(type: "int", nullable: true),
                    horarioid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_grupos", x => x.id);
                    table.ForeignKey(
                        name: "FK_grupos_horarios_horarioid",
                        column: x => x.horarioid,
                        principalTable: "horarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_grupos_materias_materiaid",
                        column: x => x.materiaid,
                        principalTable: "materias",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_grupos_personas_profesorid",
                        column: x => x.profesorid,
                        principalTable: "personas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "encuestaCovidSintomas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    encuestaCovidid = table.Column<int>(type: "int", nullable: true),
                    sintomaid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_encuestaCovidSintomas", x => x.id);
                    table.ForeignKey(
                        name: "FK_encuestaCovidSintomas_encuestaCovids_encuestaCovidid",
                        column: x => x.encuestaCovidid,
                        principalTable: "encuestaCovids",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_encuestaCovidSintomas_sintomas_sintomaid",
                        column: x => x.sintomaid,
                        principalTable: "sintomas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "estudianteGrupos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    estudianteid = table.Column<int>(type: "int", nullable: true),
                    grupoid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estudianteGrupos", x => x.id);
                    table.ForeignKey(
                        name: "FK_estudianteGrupos_grupos_grupoid",
                        column: x => x.grupoid,
                        principalTable: "grupos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_estudianteGrupos_personas_estudianteid",
                        column: x => x.estudianteid,
                        principalTable: "personas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_encuestaCovids_personaid",
                table: "encuestaCovids",
                column: "personaid");

            migrationBuilder.CreateIndex(
                name: "IX_encuestaCovidSintomas_encuestaCovidid",
                table: "encuestaCovidSintomas",
                column: "encuestaCovidid");

            migrationBuilder.CreateIndex(
                name: "IX_encuestaCovidSintomas_sintomaid",
                table: "encuestaCovidSintomas",
                column: "sintomaid");

            migrationBuilder.CreateIndex(
                name: "IX_estudianteGrupos_estudianteid",
                table: "estudianteGrupos",
                column: "estudianteid");

            migrationBuilder.CreateIndex(
                name: "IX_estudianteGrupos_grupoid",
                table: "estudianteGrupos",
                column: "grupoid");

            migrationBuilder.CreateIndex(
                name: "IX_facultades_universidadid",
                table: "facultades",
                column: "universidadid");

            migrationBuilder.CreateIndex(
                name: "IX_grupos_horarioid",
                table: "grupos",
                column: "horarioid");

            migrationBuilder.CreateIndex(
                name: "IX_grupos_materiaid",
                table: "grupos",
                column: "materiaid");

            migrationBuilder.CreateIndex(
                name: "IX_grupos_profesorid",
                table: "grupos",
                column: "profesorid");

            migrationBuilder.CreateIndex(
                name: "IX_horarios_salonid",
                table: "horarios",
                column: "salonid");

            migrationBuilder.CreateIndex(
                name: "IX_materias_programaid",
                table: "materias",
                column: "programaid");

            migrationBuilder.CreateIndex(
                name: "IX_personas_PersonalAseo_sedeid",
                table: "personas",
                column: "PersonalAseo_sedeid");

            migrationBuilder.CreateIndex(
                name: "IX_personas_programaid",
                table: "personas",
                column: "programaid");

            migrationBuilder.CreateIndex(
                name: "IX_personas_sedeid",
                table: "personas",
                column: "sedeid");

            migrationBuilder.CreateIndex(
                name: "IX_programas_facultadid",
                table: "programas",
                column: "facultadid");

            migrationBuilder.CreateIndex(
                name: "IX_salones_sedeid",
                table: "salones",
                column: "sedeid");

            migrationBuilder.CreateIndex(
                name: "IX_sedes_universidadid",
                table: "sedes",
                column: "universidadid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "encuestaCovidSintomas");

            migrationBuilder.DropTable(
                name: "estudianteGrupos");

            migrationBuilder.DropTable(
                name: "encuestaCovids");

            migrationBuilder.DropTable(
                name: "sintomas");

            migrationBuilder.DropTable(
                name: "grupos");

            migrationBuilder.DropTable(
                name: "horarios");

            migrationBuilder.DropTable(
                name: "materias");

            migrationBuilder.DropTable(
                name: "personas");

            migrationBuilder.DropTable(
                name: "salones");

            migrationBuilder.DropTable(
                name: "programas");

            migrationBuilder.DropTable(
                name: "sedes");

            migrationBuilder.DropTable(
                name: "facultades");

            migrationBuilder.DropTable(
                name: "universidades");
        }
    }
}
