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
        }
    }
}
