using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using projetox.Domain.Core.Entidades;

namespace projetox.Repository.Core.Mapping
{
    public class SegmentoAjudarPessoaMapping : IEntityTypeConfiguration<SegmentoAjudarPessoa>
    {
        public void Configure(EntityTypeBuilder<SegmentoAjudarPessoa> builder)
        {
            builder.ToTable(nameof(SegmentoAjudarPessoa));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id);
            builder.Property(x => x.Descricao).IsRequired().HasMaxLength(100);
            builder.HasOne(x => x.SegmentoCliente).WithMany(x => x.SegmentoAjudarPessoas).IsRequired().OnDelete(DeleteBehavior.Cascade);
        }
    }
}
