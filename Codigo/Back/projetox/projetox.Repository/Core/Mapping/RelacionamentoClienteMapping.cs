using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using projetox.Domain.Core.Entidades;

namespace projetox.Repository.Core.Mapping
{
    public class RelacionamentoClienteMapping : IEntityTypeConfiguration<RelacionamentoCliente>
    {
        public void Configure(EntityTypeBuilder<RelacionamentoCliente> builder)
        {
            builder.ToTable(nameof(RelacionamentoCliente));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Descricao).IsRequired().HasMaxLength(100);
            builder.HasOne(x => x.PropostaValor).WithMany(x => x.RelacionamentoClientes).IsRequired().OnDelete(DeleteBehavior.Cascade);
        }
    }
}
