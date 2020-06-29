using Microsoft.EntityFrameworkCore.Migrations;

namespace Ch04MovieList.Migrations.Country
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryID = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    GameID = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.GameID);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryID = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    CategoryID = table.Column<string>(nullable: true),
                    GameID = table.Column<string>(nullable: true),
                    FlagImage = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryID);
                    table.ForeignKey(
                        name: "FK_Countries_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Countries_Games_GameID",
                        column: x => x.GameID,
                        principalTable: "Games",
                        principalColumn: "GameID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "Name" },
                values: new object[,]
                {
                    { "in", "Indoor" },
                    { "out", "Outdoor" }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "GameID", "Name" },
                values: new object[,]
                {
                    { "winter", "Winter Olympics" },
                    { "summer", "Summer Olympics" },
                    { "paralympics", "Paralympics" },
                    { "youth", "Youth Olympics" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryID", "CategoryID", "FlagImage", "GameID", "Name" },
                values: new object[,]
                {
                    { "ca", "in", "flag-of-Canada.png", "winter", "Canada" },
                    { "sk", "out", "flag-of-Slovakia.png", "youth", "Slovakia" },
                    { "pt", "out", "flag-of-Portugal.png", "youth", "Portugal" },
                    { "pk", "out", "flag-of-Pakistan.png", "paralympics", "Pakistan" },
                    { "nl", "out", "flag-of-Netherlands.png", "summer", "Netherlands" },
                    { "jp", "out", "flag-of-Japan.png", "winter", "Japan" },
                    { "jm", "out", "flag-of-Jamaica.png", "winter", "Jamaica" },
                    { "it", "out", "flag-of-Italy.png", "winter", "Italy" },
                    { "fi", "out", "flag-of-Finland.png", "youth", "Finland" },
                    { "br", "out", "flag-of-Brazil.png", "summer", "Brazil" },
                    { "at", "out", "flag-of-Austria.png", "paralympics", "Austria" },
                    { "uy", "in", "flag-of-Uruguay.png", "paralympics", "Uruguay" },
                    { "ua", "in", "flag-of-Ukraine.png", "paralympics", "Ukraine" },
                    { "th", "in", "flag-of-Thailand.png", "paralympics", "Thailand" },
                    { "se", "in", "flag-of-Sweden.png", "winter", "Sweden" },
                    { "ru", "in", "flag-of-Russia.png", "youth", "Russia" },
                    { "mx", "in", "flag-of-Mexico.png", "summer", "Mexico" },
                    { "gb", "in", "flag-of-Great-Britain.png", "winter", "Great Britain" },
                    { "de", "in", "flag-of-Germany.png", "summer", "Germany" },
                    { "fr", "in", "flag-of-France.png", "youth", "France" },
                    { "cy", "in", "flag-of-Cyprus.png", "youth", "Cyprus" },
                    { "cn", "in", "flag-of-China.png", "summer", "China" },
                    { "us", "out", "flag-of-United-States.png", "summer", "United States" },
                    { "zw", "out", "flag-of-Zimbabwe.png", "paralympics", "Zimbabwe" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Countries_CategoryID",
                table: "Countries",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_GameID",
                table: "Countries",
                column: "GameID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Games");
        }
    }
}
