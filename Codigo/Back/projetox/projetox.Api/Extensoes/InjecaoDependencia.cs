using projetox.Domain.Autenticacao.Interfaces.Repository;
using projetox.Domain.Autenticacao.Interfaces.Service;
using projetox.Domain.Autenticacao.Services;
using projetox.Domain.Base.Interfaces.Repository;
using projetox.Repository.Autenticacao.Repository;
using projetox.Repository.Base.Repository;
using projetox.Repository.Transactions;

namespace projetox.Api.Extensoes
{
    public static class InjecaoDependencia
    {
        public static void AddInjecaoDependencia(this IServiceCollection services) 
        {
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IRegistrarUsuarioService, RegistrarUsuarioService>();
            services.AddScoped<IResetarSenhaUsuario, ResetarSenhaUsuario>();
            services.AddScoped<IRepositoryUsuario, RepositoryUsuario>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IRepositoryBase<,>), typeof(RepositoryBase<,>));
        }
    }
}
