using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using projetox.Domain.Core.Entidades;

namespace projetox.Repository.Core.Mapping
{
    public class NaturezaJuridicaMapping : IEntityTypeConfiguration<NaturezaJuridica>
    {
        public void Configure(EntityTypeBuilder<NaturezaJuridica> builder)
        {
            builder.ToTable(nameof(NaturezaJuridica));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id);
            builder.Property(x => x.Descricao).IsRequired().HasMaxLength(100);

            builder.HasData(new NaturezaJuridica[]
            {
                    new ("47610fa3-be72-4e0a-9f11-1200b3700595","Empresa Pública"),
                    new ("b994f785-1dfc-4597-908c-5eb60cf86cfa","Sociedade de Economia Mista"),
                    new ("269a2852-21bc-4483-9d75-29172f53f191","Sociedade Anônima Aberta"),
                    new ("46a35d1c-720b-403e-94d3-70a4dada94bb","Sociedade Anônima Fechada"),
                    new ("96ba3a34-3174-4d27-81f9-55eedbeb0021","Sociedade Empresária Limitada"),
                    new ("9842c97c-a930-4c87-ab71-c582dbd4802f","Sociedade Empresária em Nome Coletivo"),
                    new ("bb76bf45-3354-46e2-9b9a-eb6ed05dfd4d","Sociedade Empresária em Comandita Simples"),
                    new ("cc79b38b-247b-437a-b443-b1c3f64c4246","Sociedade Empresária em Comandita por Ações"),
                    new ("b161d5a1-2708-450b-b4f0-efde0f914061","Sociedade em Conta de Participação"),
                    new ("88528675-0737-4d01-9d74-f551334c98a2","Empresário (Individual)"),
                    new ("2d69da97-ab08-4f4f-bca7-f06ab993d413","Cooperativa"),
                    new ("0f738818-940f-4f66-8382-82577bea9f3d","Consórcio de Sociedades"),
                    new ("163a9ff9-44b5-4d96-ba66-9fb6f78e628b","Grupo de Sociedades"),
                    new ("6238d6cf-94b6-4dd0-8d89-0cc21157242a","Estabelecimento, no Brasil, de Sociedade Estrangeira"),
                    new ("05b22fb4-682a-43d8-8359-02dbfa263326","Estabelecimento, no Brasil, de Empresa Binacional Argentino-Brasileira"),
                    new ("92ad4d63-9efe-4486-b7e2-d71d3a869f0c","Empresa Domiciliada no Exterior"),
                    new ("d627523c-2095-4dc9-a038-6c3504ee627f","Clube/Fundo de Investimento"),
                    new ("4700e739-637b-491e-9aca-39a0bec301f0","Sociedade Simples Pura"),
                    new ("a957a2f4-a744-47ad-98c1-1295a21daf25","Sociedade Simples Limitada"),
                    new ("e112209a-7af8-4c07-b8d9-62f70d0375dd","Sociedade Simples em Nome Coletivo"),
                    new ("21971845-cec6-40d3-b280-bfa026ae0b12","Sociedade Simples em Comandita Simples"),
                    new ("6892b42f-15a7-408d-9ac3-8eff65c97346","Empresa Binacional"),
                    new ("fe85f277-65bb-4c4e-9344-2e7ba811b752","Consórcio de Empregadores"),
                    new ("d7565c27-6763-4e6d-942f-32753d6bfe89","Consórcio Simples"),
                    new ("bfea3dfe-f6ff-4db3-89be-14a70b3d1839","Empresa Individual de Responsabilidade Limitada (de Natureza Empresária)"),
                    new ("90a4cd32-5f1f-4ded-a285-f9d549372cc6","Empresa Individual de Responsabilidade Limitada (de Natureza Simples)"),
                    new ("6fed5d6b-8128-4d5a-ae57-49078bb388a6","Sociedade Unipessoal de Advogados"),
                    new ("d39370b9-abb4-448d-89d3-6d78412520d2","Cooperativas de Consumo"),
                    new ("9e6a7356-ac04-4383-a40b-6988e95a179c","Empresa Simples de Inovação - Inova Simples"),
                    new ("7c515124-9d3b-46e5-9a99-7024b5270918","Investidor Não Residente"),
                    new ("764ca754-54d3-447a-8976-6e05d3d6d55a","Serviço Notarial e Registral (Cartório)"),
                    new ("dee365e6-1c93-424f-b882-a0100c167550","Fundação Privada"),
                    new ("319a3f60-8a9e-4668-8f2c-bf079d20de70","Serviço Social Autônomo"),
                    new ("d1f84d86-83de-4cd7-aa07-8fb8bb58315f","Condomínio Edilício"),
                    new ("5c97f3fc-804c-453b-bb04-7b3402eb12bf","Comissão de Conciliação Prévia"),
                    new ("0c782749-d321-46ba-80b4-3cfaa72104a7","Entidade de Mediação e Arbitragem"),
                    new ("9dec824d-2471-433d-a3cc-9bfbe6d90519","Entidade Sindical"),
                    new ("4778c548-05b5-4e1d-b0ca-da6088ddc036","Estabelecimento, no Brasil, de Fundação ou Associação Estrangeiras"),
                    new ("357f783c-4dd3-47e1-9883-b29a1116909a","Fundação ou Associação Domiciliada no Exterior"),
                    new ("cc0804db-7bfe-4b62-b422-248d56eb0f13","Organização Religiosa"),
                    new ("e272ce0f-29e2-4a30-9082-5554ed0040e1","Comunidade Indígena"),
                    new ("6c0462c4-cc19-4c4f-be0f-211b64cd9145","Fundo Privado"),
                    new ("e9d4d27b-73da-44f5-8de7-adda78b4f0ee","Órgão de Direção Nacional de Partido Político"),
                    new ("9a974541-b379-45f3-8955-e7486e42cc00","Órgão de Direção Regional de Partido Político"),
                    new ("3fef395a-9c71-40e3-8ac0-d90309a96218","Órgão de Direção Local de Partido Político"),
                    new ("77100271-c89f-42b5-b463-61371b4deed3","Comitê Financeiro de Partido Político"),
                    new ("1520cfa9-b0e2-4566-ab25-14c2f56cdc84","Frente Plebiscitária ou Referendária"),
                    new ("2411e352-269c-46ef-9f3e-1bfa3b1ea8f5","Organização Social (OS)"),
                    new ("68490f47-b627-4e21-9669-a13104585365","Demais Condomínios"),
                    new ("28c125bc-5b45-4ecc-a3e0-249100c06fa5","Plano de Benefícios de Previdência Complementar Fechada"),
                    new ("a3f37a9c-b62e-4ef9-afff-09800893cea6","Associação Privada"),
                    new ("56f3ff63-1deb-4264-9aa9-a83aa1c42a54","Empresa Individual Imobiliária"),
                    new ("67bdcecb-33e3-452b-bfc4-bfea1f7d0b73","Segurado Especial"),
                    new ("dcb0eb5b-fad7-4af7-8d15-b2eb9a219731","Contribuinte individual"),
                    new ("986dc3f6-7423-46b2-995a-dc9100d06b80","Candidato a Cargo Político Eletivo"),
                    new ("a483bc25-f85b-44c3-bb3e-bbfceda0050c","Leiloeiro"),
                    new ("3767dffe-761f-4f17-8f47-283d69ab2086","Produtor Rural (Pessoa Física)")
            });
        }
    }
}
