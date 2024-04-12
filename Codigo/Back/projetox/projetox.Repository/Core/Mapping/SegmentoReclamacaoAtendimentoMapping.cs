using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using projetox.Domain.Core.Entidades;

namespace projetox.Repository.Core.Mapping
{
    public class SegmentoReclamacaoAtendimentoMapping : IEntityTypeConfiguration<SegmentoReclamacaoAtendimento>
    {
        public void Configure(EntityTypeBuilder<SegmentoReclamacaoAtendimento> builder)
        {
            builder.ToTable(nameof(SegmentoReclamacaoAtendimento));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id);
            builder.Property(x => x.Descricao).HasMaxLength(100);
            builder.HasOne<SegmentoCliente>(x => x.SegmentoCliente).WithMany(y => y.SegmentoReclamacaoAtendimentos).IsRequired().OnDelete(DeleteBehavior.Cascade);
        }
    }
}
