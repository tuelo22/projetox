using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using projetox.Domain.Core.Entidades;

namespace projetox.Repository.Core.Mapping
{
    public class RedeSocialMapping : IEntityTypeConfiguration<RedeSocial>
    {
        public void Configure(EntityTypeBuilder<RedeSocial> builder)
        {
            builder.ToTable(nameof(RedeSocial));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(100);
            builder.Property(x => x.URLPerfil).IsRequired().HasMaxLength(500);
            builder.HasOne(x => x.Empresa).WithMany(y => y.RedesSociais).IsRequired().OnDelete(DeleteBehavior.Cascade);
        }
    }
}
