using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace practice_falconsoft.Migrations
{
    public partial class DBConUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    User = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "Id", "Password", "User" },
                values: new object[] { new Guid("5b1c2b4d-48c7-402a-80c3-cc796ad49c6e"), "a84571394b5e99fe70aae39ece25f844acbaf83479e27f39a30732e092b19677", "falcon" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
