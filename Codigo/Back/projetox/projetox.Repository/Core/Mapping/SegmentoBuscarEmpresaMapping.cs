using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using projetox.Domain.Core.Entidades;

namespace projetox.Repository.Core.Mapping
{
    public class SegmentoBuscarEmpresaMapping : IEntityTypeConfiguration<SegmentoBuscarEmpresa>
    {
        public void Configure(EntityTypeBuilder<SegmentoBuscarEmpresa> builder)
        {
            builder.ToTable(nameof(SegmentoBuscarEmpresa));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Descricao).IsRequired().HasMaxLength(100);
            builder.HasOne(x => x.SegmentoCliente).WithMany(y => y.SegmentoBuscarEmpresas).IsRequired().OnDelete(DeleteBehavior.Cascade);
        }
    }
}
