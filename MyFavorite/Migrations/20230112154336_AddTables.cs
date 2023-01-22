using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyFavorite.Migrations
{
    /// <inheritdoc />
    public partial class AddTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Filmes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    posterpath = table.Column<string>(name: "poster_path", type: "nvarchar(max)", nullable: true),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    overview = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    popularity = table.Column<float>(type: "real", nullable: true),
                    video = table.Column<bool>(type: "bit", nullable: true),
                    originallanguage = table.Column<string>(name: "original_language", type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filmes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Series",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    posterpath = table.Column<string>(name: "poster_path", type: "nvarchar(max)", nullable: true),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    seasonnumber = table.Column<int>(name: "season_number", type: "int", nullable: false),
                    overview = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    popularity = table.Column<float>(type: "real", nullable: true),
                    video = table.Column<bool>(type: "bit", nullable: true),
                    originallanguage = table.Column<string>(name: "original_language", type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Series", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Filmes");

            migrationBuilder.DropTable(
                name: "Series");
        }
    }
}
