using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using projetox.Domain.Autenticacao.Entidades;
using projetox.Domain.Core.Entidades;

namespace projetox.Repository
{
    public class XContext(DbContextOptions<XContext> options) : DbContext(options)
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<CanalDistribuicao> CanalDistribuicoes { get; set; }
        public DbSet<CanalDistribuicaoOpcao> CanalDistribuicoesOpcao { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<FonteReceita> FontesReceita { get; set; }
        public DbSet<NaturezaJuridica> NaturezasJuridica { get; set; }
        public DbSet<PropostaValor> PropostasValor { get; set; }
        public DbSet<RedeSocial> RedesSociais { get; set; }
        public DbSet<RelacionamentoCliente> RelacionamentoClientes { get; set; }
        public DbSet<SegmentoAjudarPessoa> SegmentoAjudarPessoas { get; set; }
        public DbSet<SegmentoBuscarEmpresa> SegmentoBuscarEmpresas { get; set; }
        public DbSet<SegmentoCliente> SegmentoClientes { get; set; }
        public DbSet<SegmentoReclamacaoAtendimento> SegmentoReclamacaoAtendimentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(XContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(LoggerFactory.Create(x => x.AddConsole()));
            base.OnConfiguring(optionsBuilder);
        }
    }
}
