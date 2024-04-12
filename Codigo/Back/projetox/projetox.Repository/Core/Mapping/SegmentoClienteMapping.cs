using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using projetox.Domain.Core.Entidades;
using projetox.Domain.Core.ValueObjects;

namespace projetox.Repository.Core.Mapping
{
    public class SegmentoClienteMapping : IEntityTypeConfiguration<SegmentoCliente>
    {
        public void Configure(EntityTypeBuilder<SegmentoCliente> builder)
        {
            builder.ToTable(nameof(SegmentoCliente));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id);
            builder.Property(x => x.Ajudar).IsRequired().HasMaxLength(100);
            builder.Property(x => x.BuscarProduto).IsRequired().HasMaxLength(100);
            builder.Property(x => x.ServindoPessoa).IsRequired().HasMaxLength(100);
            builder.Property(x => x.ClienteDispostoPagar).IsRequired();
            builder.HasOne(x => x.PropostaValor).WithMany(y => y.SegmentosClientes).IsRequired().OnDelete(DeleteBehavior.Cascade);
            builder.OwnsOne<Monetario>(d => d.Valor, c =>
            {
                c.Property(x => x.Valor).IsRequired();
            });
        }
    }
}
