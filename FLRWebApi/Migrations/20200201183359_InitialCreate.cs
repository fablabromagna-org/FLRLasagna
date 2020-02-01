using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FLRWebApi.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Campioni",
                columns: table => new
                {
                    Data = table.Column<DateTime>(nullable: false),
                    Temperatura = table.Column<int>(nullable: false),
                    Previsione = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campioni", x => x.Data);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Campioni");
        }
    }
}
