using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

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
                name: "UsuarioEmpresa",
                columns: table => new
                {
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmpresaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioEmpresa", x => new { x.UsuarioId, x.EmpresaId });
                    table.ForeignKey(
                        name: "FK_UsuarioEmpresa_Empresa_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioEmpresa_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
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

            migrationBuilder.InsertData(
                table: "CanalDistribuicaoOpcao",
                columns: new[] { "Id", "Descricao" },
                values: new object[,]
                {
                    { new Guid("056b3407-59c5-40ad-bbff-bfaaee8b4662"), "Redes sociais" },
                    { new Guid("47b872d5-d200-4c5d-a968-b7b0e077db63"), "Site" },
                    { new Guid("63cbf794-ba75-496d-a0ee-e684ac89be77"), "Loja física" },
                    { new Guid("97f93248-5f20-47ea-85e1-1fb7b0d6bee1"), "Whatsapp" },
                    { new Guid("d45ee6cb-9be5-4bd6-906d-516930646226"), "Outros" }
                });

            migrationBuilder.InsertData(
                table: "NaturezaJuridica",
                columns: new[] { "Id", "Descricao" },
                values: new object[,]
                {
                    { new Guid("05b22fb4-682a-43d8-8359-02dbfa263326"), "Estabelecimento, no Brasil, de Empresa Binacional Argentino-Brasileira" },
                    { new Guid("0c782749-d321-46ba-80b4-3cfaa72104a7"), "Entidade de Mediação e Arbitragem" },
                    { new Guid("0f738818-940f-4f66-8382-82577bea9f3d"), "Consórcio de Sociedades" },
                    { new Guid("1520cfa9-b0e2-4566-ab25-14c2f56cdc84"), "Frente Plebiscitária ou Referendária" },
                    { new Guid("163a9ff9-44b5-4d96-ba66-9fb6f78e628b"), "Grupo de Sociedades" },
                    { new Guid("21971845-cec6-40d3-b280-bfa026ae0b12"), "Sociedade Simples em Comandita Simples" },
                    { new Guid("2411e352-269c-46ef-9f3e-1bfa3b1ea8f5"), "Organização Social (OS)" },
                    { new Guid("269a2852-21bc-4483-9d75-29172f53f191"), "Sociedade Anônima Aberta" },
                    { new Guid("28c125bc-5b45-4ecc-a3e0-249100c06fa5"), "Plano de Benefícios de Previdência Complementar Fechada" },
                    { new Guid("2d69da97-ab08-4f4f-bca7-f06ab993d413"), "Cooperativa" },
                    { new Guid("319a3f60-8a9e-4668-8f2c-bf079d20de70"), "Serviço Social Autônomo" },
                    { new Guid("357f783c-4dd3-47e1-9883-b29a1116909a"), "Fundação ou Associação Domiciliada no Exterior" },
                    { new Guid("3767dffe-761f-4f17-8f47-283d69ab2086"), "Produtor Rural (Pessoa Física)" },
                    { new Guid("3fef395a-9c71-40e3-8ac0-d90309a96218"), "Órgão de Direção Local de Partido Político" },
                    { new Guid("46a35d1c-720b-403e-94d3-70a4dada94bb"), "Sociedade Anônima Fechada" },
                    { new Guid("4700e739-637b-491e-9aca-39a0bec301f0"), "Sociedade Simples Pura" },
                    { new Guid("47610fa3-be72-4e0a-9f11-1200b3700595"), "Empresa Pública" },
                    { new Guid("4778c548-05b5-4e1d-b0ca-da6088ddc036"), "Estabelecimento, no Brasil, de Fundação ou Associação Estrangeiras" },
                    { new Guid("56f3ff63-1deb-4264-9aa9-a83aa1c42a54"), "Empresa Individual Imobiliária" },
                    { new Guid("5c97f3fc-804c-453b-bb04-7b3402eb12bf"), "Comissão de Conciliação Prévia" },
                    { new Guid("6238d6cf-94b6-4dd0-8d89-0cc21157242a"), "Estabelecimento, no Brasil, de Sociedade Estrangeira" },
                    { new Guid("67bdcecb-33e3-452b-bfc4-bfea1f7d0b73"), "Segurado Especial" },
                    { new Guid("68490f47-b627-4e21-9669-a13104585365"), "Demais Condomínios" },
                    { new Guid("6892b42f-15a7-408d-9ac3-8eff65c97346"), "Empresa Binacional" },
                    { new Guid("6c0462c4-cc19-4c4f-be0f-211b64cd9145"), "Fundo Privado" },
                    { new Guid("6fed5d6b-8128-4d5a-ae57-49078bb388a6"), "Sociedade Unipessoal de Advogados" },
                    { new Guid("764ca754-54d3-447a-8976-6e05d3d6d55a"), "Serviço Notarial e Registral (Cartório)" },
                    { new Guid("77100271-c89f-42b5-b463-61371b4deed3"), "Comitê Financeiro de Partido Político" },
                    { new Guid("7c515124-9d3b-46e5-9a99-7024b5270918"), "Investidor Não Residente" },
                    { new Guid("88528675-0737-4d01-9d74-f551334c98a2"), "Empresário (Individual)" },
                    { new Guid("90a4cd32-5f1f-4ded-a285-f9d549372cc6"), "Empresa Individual de Responsabilidade Limitada (de Natureza Simples)" },
                    { new Guid("92ad4d63-9efe-4486-b7e2-d71d3a869f0c"), "Empresa Domiciliada no Exterior" },
                    { new Guid("96ba3a34-3174-4d27-81f9-55eedbeb0021"), "Sociedade Empresária Limitada" },
                    { new Guid("9842c97c-a930-4c87-ab71-c582dbd4802f"), "Sociedade Empresária em Nome Coletivo" },
                    { new Guid("986dc3f6-7423-46b2-995a-dc9100d06b80"), "Candidato a Cargo Político Eletivo" },
                    { new Guid("9a974541-b379-45f3-8955-e7486e42cc00"), "Órgão de Direção Regional de Partido Político" },
                    { new Guid("9dec824d-2471-433d-a3cc-9bfbe6d90519"), "Entidade Sindical" },
                    { new Guid("9e6a7356-ac04-4383-a40b-6988e95a179c"), "Empresa Simples de Inovação - Inova Simples" },
                    { new Guid("a3f37a9c-b62e-4ef9-afff-09800893cea6"), "Associação Privada" },
                    { new Guid("a483bc25-f85b-44c3-bb3e-bbfceda0050c"), "Leiloeiro" },
                    { new Guid("a957a2f4-a744-47ad-98c1-1295a21daf25"), "Sociedade Simples Limitada" },
                    { new Guid("b161d5a1-2708-450b-b4f0-efde0f914061"), "Sociedade em Conta de Participação" },
                    { new Guid("b994f785-1dfc-4597-908c-5eb60cf86cfa"), "Sociedade de Economia Mista" },
                    { new Guid("bb76bf45-3354-46e2-9b9a-eb6ed05dfd4d"), "Sociedade Empresária em Comandita Simples" },
                    { new Guid("bfea3dfe-f6ff-4db3-89be-14a70b3d1839"), "Empresa Individual de Responsabilidade Limitada (de Natureza Empresária)" },
                    { new Guid("cc0804db-7bfe-4b62-b422-248d56eb0f13"), "Organização Religiosa" },
                    { new Guid("cc79b38b-247b-437a-b443-b1c3f64c4246"), "Sociedade Empresária em Comandita por Ações" },
                    { new Guid("d1f84d86-83de-4cd7-aa07-8fb8bb58315f"), "Condomínio Edilício" },
                    { new Guid("d39370b9-abb4-448d-89d3-6d78412520d2"), "Cooperativas de Consumo" },
                    { new Guid("d627523c-2095-4dc9-a038-6c3504ee627f"), "Clube/Fundo de Investimento" },
                    { new Guid("d7565c27-6763-4e6d-942f-32753d6bfe89"), "Consórcio Simples" },
                    { new Guid("dcb0eb5b-fad7-4af7-8d15-b2eb9a219731"), "Contribuinte individual" },
                    { new Guid("dee365e6-1c93-424f-b882-a0100c167550"), "Fundação Privada" },
                    { new Guid("e112209a-7af8-4c07-b8d9-62f70d0375dd"), "Sociedade Simples em Nome Coletivo" },
                    { new Guid("e272ce0f-29e2-4a30-9082-5554ed0040e1"), "Comunidade Indígena" },
                    { new Guid("e9d4d27b-73da-44f5-8de7-adda78b4f0ee"), "Órgão de Direção Nacional de Partido Político" },
                    { new Guid("fe85f277-65bb-4c4e-9344-2e7ba811b752"), "Consórcio de Empregadores" }
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

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioEmpresa_EmpresaId",
                table: "UsuarioEmpresa",
                column: "EmpresaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CanalDistribuicao");

            migrationBuilder.DropTable(
                name: "CanalDistribuicaoOpcaoPropostaValor");

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
                name: "UsuarioEmpresa");

            migrationBuilder.DropTable(
                name: "CanalDistribuicaoOpcao");

            migrationBuilder.DropTable(
                name: "SegmentoCliente");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "PropostaValor");

            migrationBuilder.DropTable(
                name: "Empresa");

            migrationBuilder.DropTable(
                name: "NaturezaJuridica");
        }
    }
}
