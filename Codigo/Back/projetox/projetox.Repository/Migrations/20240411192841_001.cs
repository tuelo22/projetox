using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projetox.Repository.Migrations
{
    /// <inheritdoc />
    public partial class _001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CanalDistribuicaoOpcao",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CanalDistribuicaoOpcao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NaturezaJuridica",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NaturezaJuridica", x => x.Id);
                });

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
                    Telefone_Numero = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Empresa",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Documento_Numero = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    NaturezaJuridicaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Endereco_Logradouro = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Endereco_Numero = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Endereco_Complemento = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Endereco_Bairro = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Endereco_Cidade = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Endereco_Estado = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Endereco_CEP = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    Endereco_CodIBGE = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Telefone_Numero = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Abertura = table.Column<DateTime>(type: "datetime2", nullable: false),
                    QuantidadeFuncionario = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    URLSite = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Objetivo = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Empresa_NaturezaJuridica_NaturezaJuridicaId",
                        column: x => x.NaturezaJuridicaId,
                        principalTable: "NaturezaJuridica",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmpresaUsuario",
                columns: table => new
                {
                    EmpresaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmpresasId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuariosId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpresaUsuario", x => new { x.EmpresaId, x.UsuarioId });
                    table.ForeignKey(
                        name: "FK_EmpresaUsuario_Empresa_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresa",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmpresaUsuario_Empresa_EmpresasId",
                        column: x => x.EmpresasId,
                        principalTable: "Empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmpresaUsuario_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmpresaUsuario_Usuario_UsuariosId",
                        column: x => x.UsuariosId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PropostaValor",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DescricaoNegocio = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FazerNegocio = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EmpresaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropostaValor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PropostaValor_Empresa_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RedeSocial",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    URLPerfil = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    EmpresaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RedeSocial", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RedeSocial_Empresa_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CanalDistribuicaoOpcaoPropostaValor",
                columns: table => new
                {
                    CanalDistribuicaoOpcaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PropostaValorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CanalDistribuicaoOpcaoPropostaValor", x => new { x.CanalDistribuicaoOpcaoId, x.PropostaValorId });
                    table.ForeignKey(
                        name: "FK_CanalDistribuicaoOpcaoPropostaValor_CanalDistribuicaoOpcao_CanalDistribuicaoOpcaoId",
                        column: x => x.CanalDistribuicaoOpcaoId,
                        principalTable: "CanalDistribuicaoOpcao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CanalDistribuicaoOpcaoPropostaValor_PropostaValor_PropostaValorId",
                        column: x => x.PropostaValorId,
                        principalTable: "PropostaValor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FonteReceita",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PropostaValorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FonteReceita", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FonteReceita_PropostaValor_PropostaValorId",
                        column: x => x.PropostaValorId,
                        principalTable: "PropostaValor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RelacionamentoCliente",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PropostaValorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelacionamentoCliente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RelacionamentoCliente_PropostaValor_PropostaValorId",
                        column: x => x.PropostaValorId,
                        principalTable: "PropostaValor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SegmentoCliente",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ajudar = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BuscarProduto = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ServindoPessoa = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ClienteDispostoPagar = table.Column<int>(type: "int", nullable: false),
                    Valor_Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PropostaValorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SegmentoCliente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SegmentoCliente_PropostaValor_PropostaValorId",
                        column: x => x.PropostaValorId,
                        principalTable: "PropostaValor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CanalDistribuicao",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SegmentoClienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CanalDistribuicaoOpcaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CanalDistribuicao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CanalDistribuicao_CanalDistribuicaoOpcao_CanalDistribuicaoOpcaoId",
                        column: x => x.CanalDistribuicaoOpcaoId,
                        principalTable: "CanalDistribuicaoOpcao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CanalDistribuicao_SegmentoCliente_SegmentoClienteId",
                        column: x => x.SegmentoClienteId,
                        principalTable: "SegmentoCliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SegmentoAjudarPessoa",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SegmentoClienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SegmentoAjudarPessoa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SegmentoAjudarPessoa_SegmentoCliente_SegmentoClienteId",
                        column: x => x.SegmentoClienteId,
                        principalTable: "SegmentoCliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SegmentoBuscarEmpresa",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SegmentoClienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SegmentoBuscarEmpresa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SegmentoBuscarEmpresa_SegmentoCliente_SegmentoClienteId",
                        column: x => x.SegmentoClienteId,
                        principalTable: "SegmentoCliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SegmentoReclamacaoAtendimento",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SegmentoClienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SegmentoReclamacaoAtendimento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SegmentoReclamacaoAtendimento_SegmentoCliente_SegmentoClienteId",
                        column: x => x.SegmentoClienteId,
                        principalTable: "SegmentoCliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CanalDistribuicao_CanalDistribuicaoOpcaoId",
                table: "CanalDistribuicao",
                column: "CanalDistribuicaoOpcaoId");

            migrationBuilder.CreateIndex(
                name: "IX_CanalDistribuicao_SegmentoClienteId",
                table: "CanalDistribuicao",
                column: "SegmentoClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_CanalDistribuicaoOpcaoPropostaValor_PropostaValorId",
                table: "CanalDistribuicaoOpcaoPropostaValor",
                column: "PropostaValorId");

            migrationBuilder.CreateIndex(
                name: "IX_Empresa_NaturezaJuridicaId",
                table: "Empresa",
                column: "NaturezaJuridicaId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpresaUsuario_EmpresasId",
                table: "EmpresaUsuario",
                column: "EmpresasId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpresaUsuario_UsuarioId",
                table: "EmpresaUsuario",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpresaUsuario_UsuariosId",
                table: "EmpresaUsuario",
                column: "UsuariosId");

            migrationBuilder.CreateIndex(
                name: "IX_FonteReceita_PropostaValorId",
                table: "FonteReceita",
                column: "PropostaValorId");

            migrationBuilder.CreateIndex(
                name: "IX_PropostaValor_EmpresaId",
                table: "PropostaValor",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_RedeSocial_EmpresaId",
                table: "RedeSocial",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_RelacionamentoCliente_PropostaValorId",
                table: "RelacionamentoCliente",
                column: "PropostaValorId");

            migrationBuilder.CreateIndex(
                name: "IX_SegmentoAjudarPessoa_SegmentoClienteId",
                table: "SegmentoAjudarPessoa",
                column: "SegmentoClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_SegmentoBuscarEmpresa_SegmentoClienteId",
                table: "SegmentoBuscarEmpresa",
                column: "SegmentoClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_SegmentoCliente_PropostaValorId",
                table: "SegmentoCliente",
                column: "PropostaValorId");

            migrationBuilder.CreateIndex(
                name: "IX_SegmentoReclamacaoAtendimento_SegmentoClienteId",
                table: "SegmentoReclamacaoAtendimento",
                column: "SegmentoClienteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CanalDistribuicao");

            migrationBuilder.DropTable(
                name: "CanalDistribuicaoOpcaoPropostaValor");

            migrationBuilder.DropTable(
                name: "EmpresaUsuario");

            migrationBuilder.DropTable(
                name: "FonteReceita");

            migrationBuilder.DropTable(
                name: "RedeSocial");

            migrationBuilder.DropTable(
                name: "RelacionamentoCliente");

            migrationBuilder.DropTable(
                name: "SegmentoAjudarPessoa");

            migrationBuilder.DropTable(
                name: "SegmentoBuscarEmpresa");

            migrationBuilder.DropTable(
                name: "SegmentoReclamacaoAtendimento");

            migrationBuilder.DropTable(
                name: "CanalDistribuicaoOpcao");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "SegmentoCliente");

            migrationBuilder.DropTable(
                name: "PropostaValor");

            migrationBuilder.DropTable(
                name: "Empresa");

            migrationBuilder.DropTable(
                name: "NaturezaJuridica");
        }
    }
}
