using projetox.Domain.Autenticacao.Interfaces.Repository;
using projetox.Domain.Autenticacao.Interfaces.Service;
using projetox.Repository.Autenticacao.Repositories;

namespace projetox.Api.Extensoes
{
    public static class InjecaoDependencia
    {
        public static void AddInjecaoDependencia(this IServiceCollection services) 
        {
            services.AddScoped<IAutenticarUsuarioService, RepositoryUsuario>();

            services.AddScoped<IRepositoryUsuario, RepositoryUsuario>();
        
        }
    }
}
