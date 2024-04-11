using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using projetox.Domain.Autenticacao.Entidades;
using projetox.Domain.Base.ValueObjects;
using projetox.Domain.Core.Entidades;
using projetox.Domain.Core.ValueObjects;

namespace projetox.Repository.Core.Mapping
{
    internal class EmpresaMapping : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder.ToTable(nameof(Empresa));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Objetivo).IsRequired().HasMaxLength(255);
            builder.OwnsOne<Documento>(d => d.Documento, c =>
            {
                c.Property(x => x.Numero).IsRequired().HasMaxLength(14);
            });
            builder.HasOne(x => x.NaturezaJuridica).WithMany(y =>  y.Empresas);
            builder.OwnsOne<Endereco>(d => d.Endereco, c =>
            {
                c.Property(x => x.Logradouro).IsRequired().HasMaxLength(255);
                c.Property(x => x.Numero).IsRequired().HasMaxLength(5);
                c.Property(x => x.Complemento).HasMaxLength(255);
                c.Property(x => x.Bairro).IsRequired().HasMaxLength(255);
                c.Property(x => x.Cidade).IsRequired().HasMaxLength(100);
                c.Property(x => x.Estado).IsRequired().HasMaxLength(100);
                c.Property(x => x.CEP).IsRequired().HasMaxLength(14);
                c.Property(x => x.CodIBGE).IsRequired().HasMaxLength(20);
            });
            builder.OwnsOne<Telefone>(d => d.Telefone, c =>
            {
                c.Property(x => x.Numero).IsRequired().HasMaxLength(30);
            });
            builder.Property(x => x.Abertura).IsRequired();
            builder.Property(x => x.QuantidadeFuncionario).IsRequired();
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(255);
            builder.Property(x => x.URLSite).HasMaxLength(500);

            builder.HasMany(empresa => empresa.Usuarios)
                   .WithMany(usuario => usuario.Empresas)
                   .UsingEntity("EmpresaUsuario",
                           l => l.HasOne(typeof(Empresa)).WithMany().HasForeignKey("EmpresaId").HasPrincipalKey(nameof(Empresa.Id)).OnDelete(DeleteBehavior.NoAction),
                           r => r.HasOne(typeof(Usuario)).WithMany().HasForeignKey("UsuarioId").HasPrincipalKey(nameof(Usuario.Id)).OnDelete(DeleteBehavior.NoAction),
                           j => j.HasKey("EmpresaId", "UsuarioId"));

        }
    }
}
