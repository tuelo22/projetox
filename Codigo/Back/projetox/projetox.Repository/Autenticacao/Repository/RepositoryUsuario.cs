using projetox.Domain.Autenticacao.Entidades;
using projetox.Domain.Autenticacao.Interfaces.Repository;
using projetox.Repository.Base.Repository;

namespace projetox.Repository.Autenticacao.Repository
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
