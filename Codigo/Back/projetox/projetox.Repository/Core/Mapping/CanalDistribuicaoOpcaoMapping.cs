using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using projetox.Domain.Core.Entidades;

namespace projetox.Repository.Core.Mapping
{
    public class CanalDistribuicaoOpcaoMapping : IEntityTypeConfiguration<CanalDistribuicaoOpcao>
    {
        public void Configure(EntityTypeBuilder<CanalDistribuicaoOpcao> builder)
        {
            builder.ToTable(nameof(CanalDistribuicaoOpcao));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id);
            builder.Property(x => x.Descricao).IsRequired().HasMaxLength(100);

            builder
                .HasMany(e => e.PropostasValor)
                .WithMany(e => e.CanalDistribuicaoOpcoes)
                .UsingEntity(
                    "CanalDistribuicaoOpcaoPropostaValor",
                    l => l.HasOne(typeof(PropostaValor)).WithMany().HasForeignKey("PropostaValorId").HasPrincipalKey(nameof(PropostaValor.Id)),
                    r => r.HasOne(typeof(CanalDistribuicaoOpcao)).WithMany().HasForeignKey("CanalDistribuicaoOpcaoId").HasPrincipalKey(nameof(CanalDistribuicaoOpcao.Id)),
                    j => j.HasKey("CanalDistribuicaoOpcaoId", "PropostaValorId"));

            builder.HasData(new CanalDistribuicaoOpcao[]
                   {
                      new ("056b3407-59c5-40ad-bbff-bfaaee8b4662","Redes sociais"),
                      new ("47b872d5-d200-4c5d-a968-b7b0e077db63","Site"),
                      new ("63cbf794-ba75-496d-a0ee-e684ac89be77","Loja física"),
                      new ("97f93248-5f20-47ea-85e1-1fb7b0d6bee1","Whatsapp"),
                      new ("d45ee6cb-9be5-4bd6-906d-516930646226","Outros"),
                   });
        }
    }
}
