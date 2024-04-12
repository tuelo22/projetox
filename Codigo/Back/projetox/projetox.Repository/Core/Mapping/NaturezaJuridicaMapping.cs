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
            builder.Property(x => x.Descricao).IsRequired().HasMaxLength(100);

            builder.HasData(new NaturezaJuridica[]
            {
                    new ("Empresa Pública"),
                    new ("Sociedade de Economia Mista"),
                    new ("Sociedade Anônima Aberta"),
                    new ("Sociedade Anônima Fechada"),
                    new ("Sociedade Empresária Limitada"),
                    new ("Sociedade Empresária em Nome Coletivo"),
                    new ("Sociedade Empresária em Comandita Simples"),
                    new ("Sociedade Empresária em Comandita por Ações"),
                    new ("Sociedade em Conta de Participação"),
                    new ("Empresário (Individual)"),
                    new ("Cooperativa"),
                    new ("Consórcio de Sociedades"),
                    new ("Grupo de Sociedades"),
                    new ("Estabelecimento, no Brasil, de Sociedade Estrangeira"),
                    new ("Estabelecimento, no Brasil, de Empresa Binacional Argentino-Brasileira"),
                    new ("Empresa Domiciliada no Exterior"),
                    new ("Clube/Fundo de Investimento"),
                    new ("Sociedade Simples Pura"),
                    new ("Sociedade Simples Limitada"),
                    new ("Sociedade Simples em Nome Coletivo"),
                    new ("Sociedade Simples em Comandita Simples"),
                    new ("Empresa Binacional"),
                    new ("Consórcio de Empregadores"),
                    new ("Consórcio Simples"),
                    new ("Empresa Individual de Responsabilidade Limitada (de Natureza Empresária)"),
                    new ("Empresa Individual de Responsabilidade Limitada (de Natureza Simples)"),
                    new ("Sociedade Unipessoal de Advogados"),
                    new ("Cooperativas de Consumo"),
                    new ("Empresa Simples de Inovação - Inova Simples"),
                    new ("Investidor Não Residente"),
                    new ("Serviço Notarial e Registral (Cartório)"),
                    new ("Fundação Privada"),
                    new ("Serviço Social Autônomo"),
                    new ("Condomínio Edilício"),
                    new ("Comissão de Conciliação Prévia"),
                    new ("Entidade de Mediação e Arbitragem"),
                    new ("Entidade Sindical"),
                    new ("Estabelecimento, no Brasil, de Fundação ou Associação Estrangeiras"),
                    new ("Fundação ou Associação Domiciliada no Exterior"),
                    new ("Organização Religiosa"),
                    new ("Comunidade Indígena"),
                    new ("Fundo Privado"),
                    new ("Órgão de Direção Nacional de Partido Político"),
                    new ("Órgão de Direção Regional de Partido Político"),
                    new ("Órgão de Direção Local de Partido Político"),
                    new ("Comitê Financeiro de Partido Político"),
                    new ("Frente Plebiscitária ou Referendária"),
                    new ("Organização Social (OS)"),
                    new ("Demais Condomínios"),
                    new ("Plano de Benefícios de Previdência Complementar Fechada"),
                    new ("Associação Privada"),
                    new ("Empresa Individual Imobiliária"),
                    new ("Segurado Especial"),
                    new ("Contribuinte individual"),
                    new ("Candidato a Cargo Político Eletivo"),
                    new ("Leiloeiro"),
                    new ("Produtor Rural (Pessoa Física)")
            });
        }
    }
}
