using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using projetox.Domain.Core.Entidades;

namespace projetox.Repository.Core.Mapping
{
    public class CanalDistribuicaoMapping : IEntityTypeConfiguration<CanalDistribuicao>
    {
        public void Configure(EntityTypeBuilder<CanalDistribuicao> builder)
        {
            builder.ToTable(nameof(CanalDistribuicao));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Descricao).IsRequired().HasMaxLength(100);
            builder.HasOne(x => x.CanalDistribuicaoOpcao).WithMany(y => y.CanaisDistribuicao).IsRequired();            
        }
    }
}
