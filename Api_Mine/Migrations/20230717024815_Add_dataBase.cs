using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Api_Mine.Migrations
{
    /// <inheritdoc />
    public partial class Add_dataBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DrillBlockDatabaseModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrillBlockDatabaseModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DrillBlockPointsDatabaseModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DrillBlockId = table.Column<int>(type: "integer", nullable: false),
                    X = table.Column<double>(type: "double precision", nullable: false),
                    Y = table.Column<double>(type: "double precision", nullable: false),
                    Z = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrillBlockPointsDatabaseModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DrillBlockPointsDatabaseModels_DrillBlockDatabaseModels_Dri~",
                        column: x => x.DrillBlockId,
                        principalTable: "DrillBlockDatabaseModels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HoleDatabaseModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    DEPTH = table.Column<double>(type: "double precision", nullable: false),
                    DrillBlockDatabaseModelId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoleDatabaseModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HoleDatabaseModels_DrillBlockDatabaseModels_DrillBlockDatab~",
                        column: x => x.DrillBlockDatabaseModelId,
                        principalTable: "DrillBlockDatabaseModels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PointDatabaseModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Lat = table.Column<double>(type: "double precision", nullable: false),
                    Lng = table.Column<double>(type: "double precision", nullable: false),
                    DrillBlockPointsDatabaseModelId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PointDatabaseModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PointDatabaseModel_DrillBlockPointsDatabaseModels_DrillBloc~",
                        column: x => x.DrillBlockPointsDatabaseModelId,
                        principalTable: "DrillBlockPointsDatabaseModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HolePointsDatabaseModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    HoleId = table.Column<int>(type: "integer", nullable: false),
                    X = table.Column<double>(type: "double precision", nullable: false),
                    Y = table.Column<double>(type: "double precision", nullable: false),
                    Z = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HolePointsDatabaseModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HolePointsDatabaseModels_HoleDatabaseModels_HoleId",
                        column: x => x.HoleId,
                        principalTable: "HoleDatabaseModels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DrillBlockPointsDatabaseModels_DrillBlockId",
                table: "DrillBlockPointsDatabaseModels",
                column: "DrillBlockId");

            migrationBuilder.CreateIndex(
                name: "IX_HoleDatabaseModels_DrillBlockDatabaseModelId",
                table: "HoleDatabaseModels",
                column: "DrillBlockDatabaseModelId");

            migrationBuilder.CreateIndex(
                name: "IX_HolePointsDatabaseModels_HoleId",
                table: "HolePointsDatabaseModels",
                column: "HoleId");

            migrationBuilder.CreateIndex(
                name: "IX_PointDatabaseModel_DrillBlockPointsDatabaseModelId",
                table: "PointDatabaseModel",
                column: "DrillBlockPointsDatabaseModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HolePointsDatabaseModels");

            migrationBuilder.DropTable(
                name: "PointDatabaseModel");

            migrationBuilder.DropTable(
                name: "HoleDatabaseModels");

            migrationBuilder.DropTable(
                name: "DrillBlockPointsDatabaseModels");

            migrationBuilder.DropTable(
                name: "DrillBlockDatabaseModels");
        }
    }
}
