using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projetox.Repository.Migrations
{
    /// <inheritdoc />
    public partial class Inicio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome_PrimeiroNome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Nome_Sobrenome = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Documento_Numero = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    Email_Confirmado = table.Column<bool>(type: "bit", nullable: false),
                    Email_Endereco = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Senha_Valor = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
