using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using projetox.Domain.Autenticacao.Entidades;

namespace projetox.Repository.Autenticacao.Mapping
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {

            builder.ToTable(nameof(Usuario));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id);
            builder.OwnsOne(d => d.Nome, c =>
            {
                c.Property(x => x.PrimeiroNome).IsRequired().HasMaxLength(50);
                c.Property(x => x.Sobrenome).IsRequired().HasMaxLength(250);
            });

            builder.OwnsOne(d => d.Documento, c =>
            {
                c.Property(x => x.Numero).IsRequired().HasMaxLength(14);
            });

            builder.OwnsOne(d => d.Email, c =>
            {
                c.Property(x => x.Endereco).IsRequired().HasMaxLength(50);
                c.Property(x => x.Confirmado).IsRequired();
            });

            builder.OwnsOne(d => d.Senha, c =>
            {
                c.Property(x => x.Valor).IsRequired().HasMaxLength(500);
            });

            builder.Property(x => x.Telefone).IsRequired().HasMaxLength(25);
        }
    }
}
