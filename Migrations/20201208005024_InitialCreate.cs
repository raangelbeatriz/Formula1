using Microsoft.EntityFrameworkCore.Migrations;

namespace Formula1.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Posicao",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomePiloto = table.Column<string>(nullable: true),
                    NomeEquipe = table.Column<string>(nullable: true),
                    PosicaoGrid = table.Column<string>(nullable: true),
                    PontosCorrida = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posicao", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posicao");
        }
    }
}
