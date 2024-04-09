using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using projetox.Domain.Autenticacao.Entidades;
using projetox.Domain.Core.Entidades;

namespace projetox.Repository.Core.Mapping
{
    public class NaturezaJuridicaMapping : IEntityTypeConfiguration<NaturezaJuridica>
    {
        public void Configure(EntityTypeBuilder<NaturezaJuridica> builder)
        {
            builder.ToTable(nameof(NaturezaJuridica));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Descricao).IsRequired().HasMaxLength(100);
        }
    }
}
