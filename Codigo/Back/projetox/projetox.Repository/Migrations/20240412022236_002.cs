using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace projetox.Repository.Migrations
{
    /// <inheritdoc />
    public partial class _002 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "NaturezaJuridica",
                columns: new[] { "Id", "Descricao" },
                values: new object[,]
                {
                    { new Guid("006e3b54-ef4a-426b-ae82-7c4e5bfd908b"), "Entidade de Mediação e Arbitragem" },
                    { new Guid("010f3e97-2a06-4116-95d1-33c5ffc32e68"), "Cooperativas de Consumo" },
                    { new Guid("02d0464f-99b6-4533-9bd5-16d552a34833"), "Sociedade Empresária em Nome Coletivo" },
                    { new Guid("0503466a-6950-490f-bc83-c3ad4290b4f6"), "Clube/Fundo de Investimento" },
                    { new Guid("0a7dcb32-5230-4f83-bb54-57328c8e8ece"), "Candidato a Cargo Político Eletivo" },
                    { new Guid("0b83bfba-2aab-4a84-8673-5200651d7969"), "Estabelecimento, no Brasil, de Empresa Binacional Argentino-Brasileira" },
                    { new Guid("0fb0258a-05f5-4ec7-8c71-baa21a945709"), "Órgão de Direção Local de Partido Político" },
                    { new Guid("105713c6-75ad-4964-8f93-eef899d7ea8f"), "Fundo Privado" },
                    { new Guid("12978b06-3e34-423e-b89f-bbc0d4a5eead"), "Sociedade em Conta de Participação" },
                    { new Guid("1aac0557-646b-47f1-8d69-31f35ba30d7a"), "Sociedade Unipessoal de Advogados" },
                    { new Guid("1ccff087-9d80-49ae-a41c-24677e87a26f"), "Organização Social (OS)" },
                    { new Guid("1e135128-2fce-45dc-96c7-5abdb350c26a"), "Leiloeiro" },
                    { new Guid("2076ed25-0410-4e9a-ba01-326b4cd0f66b"), "Condomínio Edilício" },
                    { new Guid("20cf1af8-a173-4ed3-ac81-46e5aaf5ae42"), "Consórcio de Empregadores" },
                    { new Guid("214817d8-aaf6-4765-8967-0b097a6b3090"), "Sociedade Empresária em Comandita Simples" },
                    { new Guid("2664dcd6-82bb-4b04-828d-418c242f802b"), "Empresa Individual de Responsabilidade Limitada (de Natureza Empresária)" },
                    { new Guid("27989b1f-dad5-42a2-948b-78bc1cada243"), "Estabelecimento, no Brasil, de Fundação ou Associação Estrangeiras" },
                    { new Guid("31d27c53-00e8-4555-b4cb-9744def95281"), "Consórcio de Sociedades" },
                    { new Guid("3cdd55cb-1d23-4362-bf27-ccc60b7de337"), "Sociedade Simples em Nome Coletivo" },
                    { new Guid("3d6464e5-de8e-4a81-8e61-33ed31f33487"), "Serviço Notarial e Registral (Cartório)" },
                    { new Guid("4c42d252-37d2-460e-883b-593a285acc78"), "Sociedade Simples Limitada" },
                    { new Guid("50c5dabb-996a-4bcd-abbd-1501ce6e3981"), "Associação Privada" },
                    { new Guid("51a9c67b-6243-4fbd-9ece-2a825c1cfb5a"), "Sociedade Anônima Fechada" },
                    { new Guid("55abc785-da69-472c-8db4-ebd26eef795c"), "Contribuinte individual" },
                    { new Guid("5b0bc486-4efb-42b3-aa08-47d43f38cbe0"), "Sociedade Empresária em Comandita por Ações" },
                    { new Guid("5c181b05-d28f-4808-93b4-fe8a998c3133"), "Organização Religiosa" },
                    { new Guid("600ff2c9-965e-447e-948d-f9d5cd1075f8"), "Cooperativa" },
                    { new Guid("6f3d17c7-83cd-43c0-8e54-fec18d258c44"), "Segurado Especial" },
                    { new Guid("6f68ad5b-0232-4874-9a0e-970bbd60219d"), "Sociedade Empresária Limitada" },
                    { new Guid("7737b2de-cc3c-4372-92ad-853125d66d6e"), "Sociedade de Economia Mista" },
                    { new Guid("78999c7d-ca99-44d9-aa82-81300e0d685e"), "Empresa Domiciliada no Exterior" },
                    { new Guid("83244725-1f3d-4607-8e9c-0a517c0cf281"), "Empresa Pública" },
                    { new Guid("8afc62ac-48b2-4fe6-ba17-d7618f956ba6"), "Empresa Individual Imobiliária" },
                    { new Guid("8c31af3c-5fbf-4a66-89f6-4e1607e177ef"), "Empresa Simples de Inovação - Inova Simples" },
                    { new Guid("8c708251-0351-409d-83b5-9647e430c90c"), "Produtor Rural (Pessoa Física)" },
                    { new Guid("946115cb-c669-4099-b3e3-11ba546190ff"), "Comunidade Indígena" },
                    { new Guid("a9376496-19f8-4fbf-b7c3-45a43bbe8b31"), "Empresa Binacional" },
                    { new Guid("b2e905a3-62ec-44d7-bf0b-bcdcbdf643f1"), "Órgão de Direção Regional de Partido Político" },
                    { new Guid("b43fdab4-abe3-4429-8f09-022ff908129d"), "Entidade Sindical" },
                    { new Guid("b6564961-b3f6-4eb2-965c-b62f5f596a82"), "Estabelecimento, no Brasil, de Sociedade Estrangeira" },
                    { new Guid("b912f542-ffcf-49c8-aeb5-582f6b0c41dd"), "Frente Plebiscitária ou Referendária" },
                    { new Guid("bab30284-6a94-4f71-8ab8-7c536cd5cffa"), "Demais Condomínios" },
                    { new Guid("be19c5b0-e8e3-4e06-8362-aa41d0e34447"), "Serviço Social Autônomo" },
                    { new Guid("bf107ba0-80a7-4d2c-86e0-b674b4a557f1"), "Fundação ou Associação Domiciliada no Exterior" },
                    { new Guid("cb8d37d2-e471-46a4-9e19-606a9b5d6ef0"), "Empresário (Individual)" },
                    { new Guid("cf401b36-d069-4454-9dc7-7630eacf54f2"), "Sociedade Anônima Aberta" },
                    { new Guid("d7819591-d266-44ea-8e97-e291b65e81b0"), "Plano de Benefícios de Previdência Complementar Fechada" },
                    { new Guid("dab515e6-182e-4c1f-b3ae-32c117677463"), "Consórcio Simples" },
                    { new Guid("e03f6133-ee08-4315-a78d-52094edbe983"), "Fundação Privada" },
                    { new Guid("e0c8bb2a-4d84-4816-83c6-69b476263ee0"), "Comitê Financeiro de Partido Político" },
                    { new Guid("e129505a-0987-485d-ae4d-82f47960d171"), "Empresa Individual de Responsabilidade Limitada (de Natureza Simples)" },
                    { new Guid("e239ee6f-8b6a-4f78-92f4-a6c94d2428bb"), "Grupo de Sociedades" },
                    { new Guid("e84b9aba-6df9-4a55-b3c4-f9e9f02e1712"), "Comissão de Conciliação Prévia" },
                    { new Guid("f865effe-3d44-4d88-b7e0-7f9e9539a5d8"), "Órgão de Direção Nacional de Partido Político" },
                    { new Guid("fa2f3a8b-0a9d-4166-8d9e-f575276f063b"), "Sociedade Simples em Comandita Simples" },
                    { new Guid("fb74e7c9-8a23-4709-846e-6792590932be"), "Sociedade Simples Pura" },
                    { new Guid("ff177aee-cbc0-438f-ab43-203a65fd7be6"), "Investidor Não Residente" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "NaturezaJuridica",
                keyColumn: "Id",
                keyValue: new Guid("006e3b54-ef4a-426b-ae82-7c4e5bfd908b"));

            migrationBuilder.DeleteData(
                table: "NaturezaJuridica",
                keyColumn: "Id",
                keyValue: new Guid("010f3e97-2a06-4116-95d1-33c5ffc32e68"));

            migrationBuilder.DeleteData(
                table: "NaturezaJuridica",
                keyColumn: "Id",
                keyValue: new Guid("02d0464f-99b6-4533-9bd5-16d552a34833"));

            migrationBuilder.DeleteData(
                table: "NaturezaJuridica",
                keyColumn: "Id",
                keyValue: new Guid("0503466a-6950-490f-bc83-c3ad4290b4f6"));

            migrationBuilder.DeleteData(
                table: "NaturezaJuridica",
                keyColumn: "Id",
                keyValue: new Guid("0a7dcb32-5230-4f83-bb54-57328c8e8ece"));

            migrationBuilder.DeleteData(
                table: "NaturezaJuridica",
                keyColumn: "Id",
                keyValue: new Guid("0b83bfba-2aab-4a84-8673-5200651d7969"));

            migrationBuilder.DeleteData(
                table: "NaturezaJuridica",
                keyColumn: "Id",
                keyValue: new Guid("0fb0258a-05f5-4ec7-8c71-baa21a945709"));

            migrationBuilder.DeleteData(
                table: "NaturezaJuridica",
                keyColumn: "Id",
                keyValue: new Guid("105713c6-75ad-4964-8f93-eef899d7ea8f"));

            migrationBuilder.DeleteData(
                table: "NaturezaJuridica",
                keyColumn: "Id",
                keyValue: new Guid("12978b06-3e34-423e-b89f-bbc0d4a5eead"));

            migrationBuilder.DeleteData(
                table: "NaturezaJuridica",
                keyColumn: "Id",
                keyValue: new Guid("1aac0557-646b-47f1-8d69-31f35ba30d7a"));

            migrationBuilder.DeleteData(
                table: "NaturezaJuridica",
                keyColumn: "Id",
                keyValue: new Guid("1ccff087-9d80-49ae-a41c-24677e87a26f"));

            migrationBuilder.DeleteData(
                table: "NaturezaJuridica",
                keyColumn: "Id",
                keyValue: new Guid("1e135128-2fce-45dc-96c7-5abdb350c26a"));

            migrationBuilder.DeleteData(
                table: "NaturezaJuridica",
                keyColumn: "Id",
                keyValue: new Guid("2076ed25-0410-4e9a-ba01-326b4cd0f66b"));

            migrationBuilder.DeleteData(
                table: "NaturezaJuridica",
                keyColumn: "Id",
                keyValue: new Guid("20cf1af8-a173-4ed3-ac81-46e5aaf5ae42"));

            migrationBuilder.DeleteData(
                table: "NaturezaJuridica",
                keyColumn: "Id",
                keyValue: new Guid("214817d8-aaf6-4765-8967-0b097a6b3090"));

            migrationBuilder.DeleteData(
                table: "NaturezaJuridica",
                keyColumn: "Id",
                keyValue: new Guid("2664dcd6-82bb-4b04-828d-418c242f802b"));

            migrationBuilder.DeleteData(
                table: "NaturezaJuridica",
                keyColumn: "Id",
                keyValue: new Guid("27989b1f-dad5-42a2-948b-78bc1cada243"));

            migrationBuilder.DeleteData(
                table: "NaturezaJuridica",
                keyColumn: "Id",
                keyValue: new Guid("31d27c53-00e8-4555-b4cb-9744def95281"));

            migrationBuilder.DeleteData(
                table: "NaturezaJuridica",
                keyColumn: "Id",
                keyValue: new Guid("3cdd55cb-1d23-4362-bf27-ccc60b7de337"));

            migrationBuilder.DeleteData(
                table: "NaturezaJuridica",
                keyColumn: "Id",
                keyValue: new Guid("3d6464e5-de8e-4a81-8e61-33ed31f33487"));

            migrationBuilder.DeleteData(
                table: "NaturezaJuridica",
                keyColumn: "Id",
                keyValue: new Guid("4c42d252-37d2-460e-883b-593a285acc78"));

            migrationBuilder.DeleteData(
                table: "NaturezaJuridica",
                keyColumn: "Id",
                keyValue: new Guid("50c5dabb-996a-4bcd-abbd-1501ce6e3981"));

            migrationBuilder.DeleteData(
                table: "NaturezaJuridica",
                keyColumn: "Id",
                keyValue: new Guid("51a9c67b-6243-4fbd-9ece-2a825c1cfb5a"));

            migrationBuilder.DeleteData(
                table: "NaturezaJuridica",
                keyColumn: "Id",
                keyValue: new Guid("55abc785-da69-472c-8db4-ebd26eef795c"));

            migrationBuilder.DeleteData(
                table: "NaturezaJuridica",
                keyColumn: "Id",
                keyValue: new Guid("5b0bc486-4efb-42b3-aa08-47d43f38cbe0"));

            migrationBuilder.DeleteData(
                table: "NaturezaJuridica",
                keyColumn: "Id",
                keyValue: new Guid("5c181b05-d28f-4808-93b4-fe8a998c3133"));

            migrationBuilder.DeleteData(
                table: "NaturezaJuridica",
                keyColumn: "Id",
                keyValue: new Guid("600ff2c9-965e-447e-948d-f9d5cd1075f8"));

            migrationBuilder.DeleteData(
                table: "NaturezaJuridica",
                keyColumn: "Id",
                keyValue: new Guid("6f3d17c7-83cd-43c0-8e54-fec18d258c44"));

            migrationBuilder.DeleteData(
                table: "NaturezaJuridica",
                keyColumn: "Id",
                keyValue: new Guid("6f68ad5b-0232-4874-9a0e-970bbd60219d"));

            migrationBuilder.DeleteData(
                table: "NaturezaJuridica",
                keyColumn: "Id",
                keyValue: new Guid("7737b2de-cc3c-4372-92ad-853125d66d6e"));

            migrationBuilder.DeleteData(
                table: "NaturezaJuridica",
                keyColumn: "Id",
                keyValue: new Guid("78999c7d-ca99-44d9-aa82-81300e0d685e"));

            migrationBuilder.DeleteData(
                table: "NaturezaJuridica",
                keyColumn: "Id",
                keyValue: new Guid("83244725-1f3d-4607-8e9c-0a517c0cf281"));

            migrationBuilder.DeleteData(
                table: "NaturezaJuridica",
                keyColumn: "Id",
                keyValue: new Guid("8afc62ac-48b2-4fe6-ba17-d7618f956ba6"));

            migrationBuilder.DeleteData(
                table: "NaturezaJuridica",
                keyColumn: "Id",
                keyValue: new Guid("8c31af3c-5fbf-4a66-89f6-4e1607e177ef"));

            migrationBuilder.DeleteData(
                table: "NaturezaJuridica",
                keyColumn: "Id",
                keyValue: new Guid("8c708251-0351-409d-83b5-9647e430c90c"));

            migrationBuilder.DeleteData(
                table: "NaturezaJuridica",
                keyColumn: "Id",
                keyValue: new Guid("946115cb-c669-4099-b3e3-11ba546190ff"));

            migrationBuilder.DeleteData(
                table: "NaturezaJuridica",
                keyColumn: "Id",
                keyValue: new Guid("a9376496-19f8-4fbf-b7c3-45a43bbe8b31"));

            migrationBuilder.DeleteData(
                table: "NaturezaJuridica",
                keyColumn: "Id",
                keyValue: new Guid("b2e905a3-62ec-44d7-bf0b-bcdcbdf643f1"));

            migrationBuilder.DeleteData(
                table: "NaturezaJuridica",
                keyColumn: "Id",
                keyValue: new Guid("b43fdab4-abe3-4429-8f09-022ff908129d"));

            migrationBuilder.DeleteData(
                table: "NaturezaJuridica",
                keyColumn: "Id",
                keyValue: new Guid("b6564961-b3f6-4eb2-965c-b62f5f596a82"));

            migrationBuilder.DeleteData(
                table: "NaturezaJuridica",
                keyColumn: "Id",
                keyValue: new Guid("b912f542-ffcf-49c8-aeb5-582f6b0c41dd"));

            migrationBuilder.DeleteData(
                table: "NaturezaJuridica",
                keyColumn: "Id",
                keyValue: new Guid("bab30284-6a94-4f71-8ab8-7c536cd5cffa"));

            migrationBuilder.DeleteData(
                table: "NaturezaJuridica",
                keyColumn: "Id",
                keyValue: new Guid("be19c5b0-e8e3-4e06-8362-aa41d0e34447"));

            migrationBuilder.DeleteData(
                table: "NaturezaJuridica",
                keyColumn: "Id",
                keyValue: new Guid("bf107ba0-80a7-4d2c-86e0-b674b4a557f1"));

            migrationBuilder.DeleteData(
                table: "NaturezaJuridica",
                keyColumn: "Id",
                keyValue: new Guid("cb8d37d2-e471-46a4-9e19-606a9b5d6ef0"));

            migrationBuilder.DeleteData(
                table: "NaturezaJuridica",
                keyColumn: "Id",
                keyValue: new Guid("cf401b36-d069-4454-9dc7-7630eacf54f2"));

            migrationBuilder.DeleteData(
                table: "NaturezaJuridica",
                keyColumn: "Id",
                keyValue: new Guid("d7819591-d266-44ea-8e97-e291b65e81b0"));

            migrationBuilder.DeleteData(
                table: "NaturezaJuridica",
                keyColumn: "Id",
                keyValue: new Guid("dab515e6-182e-4c1f-b3ae-32c117677463"));

            migrationBuilder.DeleteData(
                table: "NaturezaJuridica",
                keyColumn: "Id",
                keyValue: new Guid("e03f6133-ee08-4315-a78d-52094edbe983"));

            migrationBuilder.DeleteData(
                table: "NaturezaJuridica",
                keyColumn: "Id",
                keyValue: new Guid("e0c8bb2a-4d84-4816-83c6-69b476263ee0"));

            migrationBuilder.DeleteData(
                table: "NaturezaJuridica",
                keyColumn: "Id",
                keyValue: new Guid("e129505a-0987-485d-ae4d-82f47960d171"));

            migrationBuilder.DeleteData(
                table: "NaturezaJuridica",
                keyColumn: "Id",
                keyValue: new Guid("e239ee6f-8b6a-4f78-92f4-a6c94d2428bb"));

            migrationBuilder.DeleteData(
                table: "NaturezaJuridica",
                keyColumn: "Id",
                keyValue: new Guid("e84b9aba-6df9-4a55-b3c4-f9e9f02e1712"));

            migrationBuilder.DeleteData(
                table: "NaturezaJuridica",
                keyColumn: "Id",
                keyValue: new Guid("f865effe-3d44-4d88-b7e0-7f9e9539a5d8"));

            migrationBuilder.DeleteData(
                table: "NaturezaJuridica",
                keyColumn: "Id",
                keyValue: new Guid("fa2f3a8b-0a9d-4166-8d9e-f575276f063b"));

            migrationBuilder.DeleteData(
                table: "NaturezaJuridica",
                keyColumn: "Id",
                keyValue: new Guid("fb74e7c9-8a23-4709-846e-6792590932be"));

            migrationBuilder.DeleteData(
                table: "NaturezaJuridica",
                keyColumn: "Id",
                keyValue: new Guid("ff177aee-cbc0-438f-ab43-203a65fd7be6"));
        }
    }
}
