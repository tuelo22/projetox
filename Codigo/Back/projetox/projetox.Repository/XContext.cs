using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using projetox.Domain.Autenticacao.Entidades;

namespace projetox.Repository
{
    public class XContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }


        public XContext(DbContextOptions<XContext> options) : base(options)
        {
        }

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
