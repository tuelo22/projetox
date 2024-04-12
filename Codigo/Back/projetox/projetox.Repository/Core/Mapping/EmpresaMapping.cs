using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using projetox.Domain.Base.ValueObjects;
using projetox.Domain.Core.Entidades;
using projetox.Domain.Core.ValueObjects;

namespace projetox.Repository.Core.Mapping
{
    public class EmpresaMapping : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder.ToTable(nameof(Empresa));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id);
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
            builder
                .HasMany(e => e.RedesSociais)
                .WithOne(e => e.Empresa);
        }
    }
}
