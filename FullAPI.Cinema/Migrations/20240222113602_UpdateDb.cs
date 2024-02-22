using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FullAPI.Cinema.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieTechnologies");

            migrationBuilder.DropTable(
                name: "RoomTechnologies");

            migrationBuilder.AddColumn<string>(
                name: "TechnologyType",
                table: "Technologies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Duration",
                table: "Movies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "MovieRoomTechnology",
                columns: table => new
                {
                    MovieRoomsMovieRoomId = table.Column<int>(type: "int", nullable: false),
                    TechnologiesTechnologyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieRoomTechnology", x => new { x.MovieRoomsMovieRoomId, x.TechnologiesTechnologyId });
                    table.ForeignKey(
                        name: "FK_MovieRoomTechnology_MovieRooms_MovieRoomsMovieRoomId",
                        column: x => x.MovieRoomsMovieRoomId,
                        principalTable: "MovieRooms",
                        principalColumn: "MovieRoomId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieRoomTechnology_Technologies_TechnologiesTechnologyId",
                        column: x => x.TechnologiesTechnologyId,
                        principalTable: "Technologies",
                        principalColumn: "TechnologyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieTechnology",
                columns: table => new
                {
                    MoviesMovieId = table.Column<int>(type: "int", nullable: false),
                    TechnologiesTechnologyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieTechnology", x => new { x.MoviesMovieId, x.TechnologiesTechnologyId });
                    table.ForeignKey(
                        name: "FK_MovieTechnology_Movies_MoviesMovieId",
                        column: x => x.MoviesMovieId,
                        principalTable: "Movies",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieTechnology_Technologies_TechnologiesTechnologyId",
                        column: x => x.TechnologiesTechnologyId,
                        principalTable: "Technologies",
                        principalColumn: "TechnologyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieRoomTechnology_TechnologiesTechnologyId",
                table: "MovieRoomTechnology",
                column: "TechnologiesTechnologyId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieTechnology_TechnologiesTechnologyId",
                table: "MovieTechnology",
                column: "TechnologiesTechnologyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieRoomTechnology");

            migrationBuilder.DropTable(
                name: "MovieTechnology");

            migrationBuilder.DropColumn(
                name: "TechnologyType",
                table: "Technologies");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Movies");

            migrationBuilder.CreateTable(
                name: "MovieTechnologies",
                columns: table => new
                {
                    MovieTechnologyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    TechnologyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieTechnologies", x => x.MovieTechnologyId);
                    table.ForeignKey(
                        name: "FK_MovieTechnologies_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieTechnologies_Technologies_TechnologyId",
                        column: x => x.TechnologyId,
                        principalTable: "Technologies",
                        principalColumn: "TechnologyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoomTechnologies",
                columns: table => new
                {
                    RoomTechnologyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieRoomId = table.Column<int>(type: "int", nullable: false),
                    TechnologyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomTechnologies", x => x.RoomTechnologyId);
                    table.ForeignKey(
                        name: "FK_RoomTechnologies_MovieRooms_MovieRoomId",
                        column: x => x.MovieRoomId,
                        principalTable: "MovieRooms",
                        principalColumn: "MovieRoomId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoomTechnologies_Technologies_TechnologyId",
                        column: x => x.TechnologyId,
                        principalTable: "Technologies",
                        principalColumn: "TechnologyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieTechnologies_MovieId",
                table: "MovieTechnologies",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieTechnologies_TechnologyId",
                table: "MovieTechnologies",
                column: "TechnologyId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomTechnologies_MovieRoomId",
                table: "RoomTechnologies",
                column: "MovieRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomTechnologies_TechnologyId",
                table: "RoomTechnologies",
                column: "TechnologyId");
        }
    }
}
