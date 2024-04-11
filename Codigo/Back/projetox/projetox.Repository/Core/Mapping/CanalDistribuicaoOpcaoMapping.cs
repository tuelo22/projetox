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
            builder.Property(x => x.Descricao).IsRequired().HasMaxLength(100);
        }
    }
}
