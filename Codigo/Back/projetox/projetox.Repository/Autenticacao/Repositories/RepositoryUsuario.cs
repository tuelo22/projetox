using projetox.Domain.Autenticacao.Entidades;
using projetox.Domain.Autenticacao.Interfaces.Repository;
using projetox.Repository.Base.Repositories;

namespace projetox.Repository.Autenticacao.Repositories
{
    public class RepositoryUsuario : RepositoryBase<Usuario, Guid>, IRepositoryUsuario
    {
        protected readonly XContext _context;

        public RepositoryUsuario(XContext context)
            : base(context)
        {
            _context = context;
        }
    }
}
