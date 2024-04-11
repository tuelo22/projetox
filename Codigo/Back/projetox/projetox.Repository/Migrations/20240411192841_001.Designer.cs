﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using projetox.Repository;

#nullable disable

namespace projetox.Repository.Migrations
{
    [DbContext(typeof(XContext))]
    [Migration("20240411192841_001")]
    partial class _001
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CanalDistribuicaoOpcaoPropostaValor", b =>
                {
                    b.Property<Guid>("CanalDistribuicaoOpcaoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PropostaValorId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CanalDistribuicaoOpcaoId", "PropostaValorId");

                    b.HasIndex("PropostaValorId");

                    b.ToTable("CanalDistribuicaoOpcaoPropostaValor");
                });

            modelBuilder.Entity("EmpresaUsuario", b =>
                {
                    b.Property<Guid>("EmpresaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EmpresasId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UsuariosId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("EmpresaId", "UsuarioId");

                    b.HasIndex("EmpresasId");

                    b.HasIndex("UsuarioId");

                    b.HasIndex("UsuariosId");

                    b.ToTable("EmpresaUsuario");
                });

            modelBuilder.Entity("projetox.Domain.Autenticacao.Entidades.Usuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Usuario", (string)null);
                });

            modelBuilder.Entity("projetox.Domain.Core.Entidades.CanalDistribuicao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CanalDistribuicaoOpcaoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<Guid>("SegmentoClienteId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CanalDistribuicaoOpcaoId");

                    b.HasIndex("SegmentoClienteId");

                    b.ToTable("CanalDistribuicao", (string)null);
                });

            modelBuilder.Entity("projetox.Domain.Core.Entidades.CanalDistribuicaoOpcao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("CanalDistribuicaoOpcao", (string)null);
                });

            modelBuilder.Entity("projetox.Domain.Core.Entidades.Empresa", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Abertura")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("NaturezaJuridicaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Objetivo")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("QuantidadeFuncionario")
                        .HasColumnType("int");

                    b.Property<string>("URLSite")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("Id");

                    b.HasIndex("NaturezaJuridicaId");

                    b.ToTable("Empresa", (string)null);
                });

            modelBuilder.Entity("projetox.Domain.Core.Entidades.FonteReceita", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<Guid>("PropostaValorId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PropostaValorId");

                    b.ToTable("FonteReceita", (string)null);
                });

            modelBuilder.Entity("projetox.Domain.Core.Entidades.NaturezaJuridica", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("NaturezaJuridica", (string)null);
                });

            modelBuilder.Entity("projetox.Domain.Core.Entidades.PropostaValor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DescricaoNegocio")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<Guid>("EmpresaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FazerNegocio")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.ToTable("PropostaValor", (string)null);
                });

            modelBuilder.Entity("projetox.Domain.Core.Entidades.RedeSocial", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EmpresaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("URLPerfil")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.ToTable("RedeSocial", (string)null);
                });

            modelBuilder.Entity("projetox.Domain.Core.Entidades.RelacionamentoCliente", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<Guid>("PropostaValorId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PropostaValorId");

                    b.ToTable("RelacionamentoCliente", (string)null);
                });

            modelBuilder.Entity("projetox.Domain.Core.Entidades.SegmentoAjudarPessoa", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<Guid>("SegmentoClienteId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("SegmentoClienteId");

                    b.ToTable("SegmentoAjudarPessoa", (string)null);
                });

            modelBuilder.Entity("projetox.Domain.Core.Entidades.SegmentoBuscarEmpresa", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<Guid>("SegmentoClienteId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("SegmentoClienteId");

                    b.ToTable("SegmentoBuscarEmpresa", (string)null);
                });

            modelBuilder.Entity("projetox.Domain.Core.Entidades.SegmentoCliente", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Ajudar")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("BuscarProduto")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("ClienteDispostoPagar")
                        .HasColumnType("int");

                    b.Property<Guid>("PropostaValorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ServindoPessoa")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("PropostaValorId");

                    b.ToTable("SegmentoCliente", (string)null);
                });

            modelBuilder.Entity("projetox.Domain.Core.Entidades.SegmentoReclamacaoAtendimento", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<Guid>("SegmentoClienteId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("SegmentoClienteId");

                    b.ToTable("SegmentoReclamacaoAtendimento", (string)null);
                });

            modelBuilder.Entity("CanalDistribuicaoOpcaoPropostaValor", b =>
                {
                    b.HasOne("projetox.Domain.Core.Entidades.CanalDistribuicaoOpcao", null)
                        .WithMany()
                        .HasForeignKey("CanalDistribuicaoOpcaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("projetox.Domain.Core.Entidades.PropostaValor", null)
                        .WithMany()
                        .HasForeignKey("PropostaValorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EmpresaUsuario", b =>
                {
                    b.HasOne("projetox.Domain.Core.Entidades.Empresa", null)
                        .WithMany()
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("projetox.Domain.Core.Entidades.Empresa", null)
                        .WithMany()
                        .HasForeignKey("EmpresasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("projetox.Domain.Autenticacao.Entidades.Usuario", null)
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("projetox.Domain.Autenticacao.Entidades.Usuario", null)
                        .WithMany()
                        .HasForeignKey("UsuariosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("projetox.Domain.Autenticacao.Entidades.Usuario", b =>
                {
                    b.OwnsOne("projetox.Domain.Base.ValueObjects.Documento", "Documento", b1 =>
                        {
                            b1.Property<Guid>("UsuarioId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Numero")
                                .IsRequired()
                                .HasMaxLength(14)
                                .HasColumnType("nvarchar(14)");

                            b1.HasKey("UsuarioId");

                            b1.ToTable("Usuario");

                            b1.WithOwner()
                                .HasForeignKey("UsuarioId");
                        });

                    b.OwnsOne("projetox.Domain.Core.ValueObjects.Telefone", "Telefone", b1 =>
                        {
                            b1.Property<Guid>("UsuarioId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Numero")
                                .IsRequired()
                                .HasMaxLength(25)
                                .HasColumnType("nvarchar(25)");

                            b1.HasKey("UsuarioId");

                            b1.ToTable("Usuario");

                            b1.WithOwner()
                                .HasForeignKey("UsuarioId");
                        });

                    b.OwnsOne("projetox.Domain.Autenticacao.ValueObjects.Email", "Email", b1 =>
                        {
                            b1.Property<Guid>("UsuarioId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<bool>("Confirmado")
                                .HasColumnType("bit");

                            b1.Property<string>("Endereco")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)");

                            b1.HasKey("UsuarioId");

                            b1.ToTable("Usuario");

                            b1.WithOwner()
                                .HasForeignKey("UsuarioId");
                        });

                    b.OwnsOne("projetox.Domain.Autenticacao.ValueObjects.Nome", "Nome", b1 =>
                        {
                            b1.Property<Guid>("UsuarioId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("PrimeiroNome")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)");

                            b1.Property<string>("Sobrenome")
                                .IsRequired()
                                .HasMaxLength(250)
                                .HasColumnType("nvarchar(250)");

                            b1.HasKey("UsuarioId");

                            b1.ToTable("Usuario");

                            b1.WithOwner()
                                .HasForeignKey("UsuarioId");
                        });

                    b.OwnsOne("projetox.Domain.Autenticacao.ValueObjects.Senha", "Senha", b1 =>
                        {
                            b1.Property<Guid>("UsuarioId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Valor")
                                .IsRequired()
                                .HasMaxLength(500)
                                .HasColumnType("nvarchar(500)");

                            b1.HasKey("UsuarioId");

                            b1.ToTable("Usuario");

                            b1.WithOwner()
                                .HasForeignKey("UsuarioId");
                        });

                    b.Navigation("Documento")
                        .IsRequired();

                    b.Navigation("Email")
                        .IsRequired();

                    b.Navigation("Nome")
                        .IsRequired();

                    b.Navigation("Senha")
                        .IsRequired();

                    b.Navigation("Telefone")
                        .IsRequired();
                });

            modelBuilder.Entity("projetox.Domain.Core.Entidades.CanalDistribuicao", b =>
                {
                    b.HasOne("projetox.Domain.Core.Entidades.CanalDistribuicaoOpcao", "CanalDistribuicaoOpcao")
                        .WithMany("CanaisDistribuicao")
                        .HasForeignKey("CanalDistribuicaoOpcaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("projetox.Domain.Core.Entidades.SegmentoCliente", "SegmentoCliente")
                        .WithMany()
                        .HasForeignKey("SegmentoClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CanalDistribuicaoOpcao");

                    b.Navigation("SegmentoCliente");
                });

            modelBuilder.Entity("projetox.Domain.Core.Entidades.Empresa", b =>
                {
                    b.HasOne("projetox.Domain.Core.Entidades.NaturezaJuridica", "NaturezaJuridica")
                        .WithMany("Empresas")
                        .HasForeignKey("NaturezaJuridicaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("projetox.Domain.Base.ValueObjects.Documento", "Documento", b1 =>
                        {
                            b1.Property<Guid>("EmpresaId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Numero")
                                .IsRequired()
                                .HasMaxLength(14)
                                .HasColumnType("nvarchar(14)");

                            b1.HasKey("EmpresaId");

                            b1.ToTable("Empresa");

                            b1.WithOwner()
                                .HasForeignKey("EmpresaId");
                        });

                    b.OwnsOne("projetox.Domain.Core.ValueObjects.Telefone", "Telefone", b1 =>
                        {
                            b1.Property<Guid>("EmpresaId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Numero")
                                .IsRequired()
                                .HasMaxLength(30)
                                .HasColumnType("nvarchar(30)");

                            b1.HasKey("EmpresaId");

                            b1.ToTable("Empresa");

                            b1.WithOwner()
                                .HasForeignKey("EmpresaId");
                        });

                    b.OwnsOne("projetox.Domain.Core.ValueObjects.Endereco", "Endereco", b1 =>
                        {
                            b1.Property<Guid>("EmpresaId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Bairro")
                                .IsRequired()
                                .HasMaxLength(255)
                                .HasColumnType("nvarchar(255)");

                            b1.Property<string>("CEP")
                                .IsRequired()
                                .HasMaxLength(14)
                                .HasColumnType("nvarchar(14)");

                            b1.Property<string>("Cidade")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)");

                            b1.Property<string>("CodIBGE")
                                .IsRequired()
                                .HasMaxLength(20)
                                .HasColumnType("nvarchar(20)");

                            b1.Property<string>("Complemento")
                                .HasMaxLength(255)
                                .HasColumnType("nvarchar(255)");

                            b1.Property<string>("Estado")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)");

                            b1.Property<string>("Logradouro")
                                .IsRequired()
                                .HasMaxLength(255)
                                .HasColumnType("nvarchar(255)");

                            b1.Property<string>("Numero")
                                .IsRequired()
                                .HasMaxLength(5)
                                .HasColumnType("nvarchar(5)");

                            b1.HasKey("EmpresaId");

                            b1.ToTable("Empresa");

                            b1.WithOwner()
                                .HasForeignKey("EmpresaId");
                        });

                    b.Navigation("Documento")
                        .IsRequired();

                    b.Navigation("Endereco")
                        .IsRequired();

                    b.Navigation("NaturezaJuridica");

                    b.Navigation("Telefone")
                        .IsRequired();
                });

            modelBuilder.Entity("projetox.Domain.Core.Entidades.FonteReceita", b =>
                {
                    b.HasOne("projetox.Domain.Core.Entidades.PropostaValor", "PropostaValor")
                        .WithMany("FontesReceita")
                        .HasForeignKey("PropostaValorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PropostaValor");
                });

            modelBuilder.Entity("projetox.Domain.Core.Entidades.PropostaValor", b =>
                {
                    b.HasOne("projetox.Domain.Core.Entidades.Empresa", "Empresa")
                        .WithMany("PropostasValor")
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("projetox.Domain.Core.Entidades.RedeSocial", b =>
                {
                    b.HasOne("projetox.Domain.Core.Entidades.Empresa", "Empresa")
                        .WithMany("RedesSociais")
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("projetox.Domain.Core.Entidades.RelacionamentoCliente", b =>
                {
                    b.HasOne("projetox.Domain.Core.Entidades.PropostaValor", "PropostaValor")
                        .WithMany("RelacionamentoClientes")
                        .HasForeignKey("PropostaValorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PropostaValor");
                });

            modelBuilder.Entity("projetox.Domain.Core.Entidades.SegmentoAjudarPessoa", b =>
                {
                    b.HasOne("projetox.Domain.Core.Entidades.SegmentoCliente", "SegmentoCliente")
                        .WithMany("SegmentoAjudarPessoas")
                        .HasForeignKey("SegmentoClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SegmentoCliente");
                });

            modelBuilder.Entity("projetox.Domain.Core.Entidades.SegmentoBuscarEmpresa", b =>
                {
                    b.HasOne("projetox.Domain.Core.Entidades.SegmentoCliente", "SegmentoCliente")
                        .WithMany("SegmentoBuscarEmpresas")
                        .HasForeignKey("SegmentoClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SegmentoCliente");
                });

            modelBuilder.Entity("projetox.Domain.Core.Entidades.SegmentoCliente", b =>
                {
                    b.HasOne("projetox.Domain.Core.Entidades.PropostaValor", "PropostaValor")
                        .WithMany("SegmentosClientes")
                        .HasForeignKey("PropostaValorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("projetox.Domain.Core.ValueObjects.Monetario", "Valor", b1 =>
                        {
                            b1.Property<Guid>("SegmentoClienteId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<decimal>("Valor")
                                .HasColumnType("decimal(18,2)");

                            b1.HasKey("SegmentoClienteId");

                            b1.ToTable("SegmentoCliente");

                            b1.WithOwner()
                                .HasForeignKey("SegmentoClienteId");
                        });

                    b.Navigation("PropostaValor");

                    b.Navigation("Valor")
                        .IsRequired();
                });

            modelBuilder.Entity("projetox.Domain.Core.Entidades.SegmentoReclamacaoAtendimento", b =>
                {
                    b.HasOne("projetox.Domain.Core.Entidades.SegmentoCliente", "SegmentoCliente")
                        .WithMany("SegmentoReclamacaoAtendimentos")
                        .HasForeignKey("SegmentoClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SegmentoCliente");
                });

            modelBuilder.Entity("projetox.Domain.Core.Entidades.CanalDistribuicaoOpcao", b =>
                {
                    b.Navigation("CanaisDistribuicao");
                });

            modelBuilder.Entity("projetox.Domain.Core.Entidades.Empresa", b =>
                {
                    b.Navigation("PropostasValor");

                    b.Navigation("RedesSociais");
                });

            modelBuilder.Entity("projetox.Domain.Core.Entidades.NaturezaJuridica", b =>
                {
                    b.Navigation("Empresas");
                });

            modelBuilder.Entity("projetox.Domain.Core.Entidades.PropostaValor", b =>
                {
                    b.Navigation("FontesReceita");

                    b.Navigation("RelacionamentoClientes");

                    b.Navigation("SegmentosClientes");
                });

            modelBuilder.Entity("projetox.Domain.Core.Entidades.SegmentoCliente", b =>
                {
                    b.Navigation("SegmentoAjudarPessoas");

                    b.Navigation("SegmentoBuscarEmpresas");

                    b.Navigation("SegmentoReclamacaoAtendimentos");
                });
#pragma warning restore 612, 618
        }
    }
}