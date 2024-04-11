using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using projetox.Domain.Core.Entidades;

namespace projetox.Repository.Core.Mapping
{
    public class FonteReceitaMapping : IEntityTypeConfiguration<FonteReceita>
    {
        public void Configure(EntityTypeBuilder<FonteReceita> builder)
        {
            builder.ToTable(nameof(FonteReceita));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Descricao).IsRequired().HasMaxLength(100);
            builder.HasOne(x => x.PropostaValor).WithMany(y => y.FontesReceita).IsRequired().OnDelete(DeleteBehavior.Cascade);
        }
    }
}
