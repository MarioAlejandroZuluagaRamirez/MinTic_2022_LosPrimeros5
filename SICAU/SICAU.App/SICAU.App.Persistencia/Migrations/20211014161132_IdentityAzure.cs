using Microsoft.EntityFrameworkCore.Migrations;

namespace SICAU.App.Persistencia.Migrations
{
    public partial class IdentityAzure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_facultades_universidades_Universidadid",
                table: "facultades");

            migrationBuilder.DropIndex(
                name: "IX_facultades_Universidadid",
                table: "facultades");

            migrationBuilder.DropColumn(
                name: "Universidadid",
                table: "facultades");

            migrationBuilder.AlterColumn<string>(
                name: "facultad",
                table: "facultades",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "facultad",
                table: "facultades",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<int>(
                name: "Universidadid",
                table: "facultades",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_facultades_Universidadid",
                table: "facultades",
                column: "Universidadid");

            migrationBuilder.AddForeignKey(
                name: "FK_facultades_universidades_Universidadid",
                table: "facultades",
                column: "Universidadid",
                principalTable: "universidades",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
