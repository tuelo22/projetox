using projetox.Domain.Autenticacao.Interfaces.Repositories;
using projetox.Domain.Autenticacao.Interfaces.Services;
using projetox.Domain.Autenticacao.Services;
using projetox.Domain.Base.Interfaces.Repositories;
using projetox.Domain.Core.Interfaces.Repositories;
using projetox.Domain.Core.Interfaces.Services;
using projetox.Domain.Core.Services;
using projetox.Repository.Autenticacao.Repositories;
using projetox.Repository.Base.Repository;
using projetox.Repository.Core.Repositories;
using projetox.Repository.Transactions;

namespace projetox.Api.Extensoes
{
    /// <summary>
    /// Classe extatica de extenção para injeção de dependencia.
    /// </summary>
    public static class InjecaoDependencia
    {
        /// <summary>
        /// Método de extenção para injeção de dependencia.
        /// </summary>
        public static void AddInjecaoDependencia(this IServiceCollection services) 
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IRepositoryBase<,>), typeof(RepositoryBase<,>));

            // Repository
            services.AddScoped<IRepositoryUsuario, RepositoryUsuario>();
            services.AddScoped<IEmpresaRepository, EmpresaRepository>();
            services.AddScoped<INaturezaJuridicaRepository, NaturezaJuridicaRepository>();
            services.AddScoped<ICanalDistribuicaoOpcaoRepository, CanalDistribuicaoOpcaoRepository>();
            services.AddScoped<IPropostaValorRepository, PropostaValorRepository>();
            services.AddScoped<ISegmentoClienteRepository, SegmentoClienteRepository>();

            //Service
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IRegistrarUsuarioService, RegistrarUsuarioService>();
            services.AddScoped<IResetarSenhaUsuario, ResetarSenhaUsuario>();
            services.AddScoped<IEmpresaService, EmpresaService>();
            services.AddScoped<IPropostaValorService, PropostaValorService>();
            services.AddScoped<ISegmentoClienteService, SegmentoClienteService>();
        }
    }
}
