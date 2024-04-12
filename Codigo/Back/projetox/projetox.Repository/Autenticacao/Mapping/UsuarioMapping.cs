using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using projetox.Domain.Autenticacao.Entidades;
using projetox.Domain.Autenticacao.ValueObjects;
using projetox.Domain.Base.ValueObjects;
using projetox.Domain.Core.Entidades;
using projetox.Domain.Core.ValueObjects;
using System.Reflection.Metadata;

namespace projetox.Repository.Autenticacao.Mapping
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {

            builder.ToTable(nameof(Usuario));
            builder.HasKey(x => x.Id);

            builder.OwnsOne<Nome>(d => d.Nome, c =>
            {
                c.Property(x => x.PrimeiroNome).IsRequired().HasMaxLength(50);
                c.Property(x => x.Sobrenome).IsRequired().HasMaxLength(250);
            });

            builder.OwnsOne<Documento>(d => d.Documento, c =>
            {
                c.Property(x => x.Numero).IsRequired().HasMaxLength(14);
            });

            builder.OwnsOne<Email>(d => d.Email, c =>
            {
                c.Property(x => x.Endereco).IsRequired().HasMaxLength(50);
                c.Property(x => x.Confirmado).IsRequired();
            });

            builder.OwnsOne<Senha>(d => d.Senha, c =>
            {
                c.Property(x => x.Valor).IsRequired().HasMaxLength(500);
            });

            builder.OwnsOne<Telefone>(d => d.Telefone, c =>
            {
                c.Property(x => x.Numero).IsRequired().HasMaxLength(25);
            });

            builder
                .HasMany(e => e.Empresas)
                .WithMany(e => e.Usuarios)
                .UsingEntity(
                    "UsuarioEmpresa",
                    l => l.HasOne(typeof(Empresa)).WithMany().HasForeignKey("EmpresaId").HasPrincipalKey(nameof(Empresa.Id)),
                    r => r.HasOne(typeof(Usuario)).WithMany().HasForeignKey("UsuarioId").HasPrincipalKey(nameof(Usuario.Id)),
                    j => j.HasKey("UsuarioId", "EmpresaId"));
        }
    }
}
