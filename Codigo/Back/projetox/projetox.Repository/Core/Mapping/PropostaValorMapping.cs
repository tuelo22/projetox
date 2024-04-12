using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using projetox.Domain.Core.Entidades;

namespace projetox.Repository.Core.Mapping
{
    public class PropostaValorMapping : IEntityTypeConfiguration<PropostaValor>
    {
        public void Configure(EntityTypeBuilder<PropostaValor> builder)
        {
            builder.ToTable(nameof(PropostaValor));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id);
            builder.Property(x => x.DescricaoNegocio).IsRequired().HasMaxLength(100);
            builder.Property(x => x.FazerNegocio).IsRequired().HasMaxLength(100);
            builder.HasOne(x => x.Empresa).WithMany(y => y.PropostasValor).IsRequired().OnDelete(DeleteBehavior.Cascade);


        }
    }
}
