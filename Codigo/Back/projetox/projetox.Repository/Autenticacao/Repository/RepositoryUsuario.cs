using projetox.Domain.Autenticacao.Entidades;
using projetox.Domain.Autenticacao.Interfaces.Repository;
using projetox.Repository.Base.Repository;

namespace projetox.Repository.Autenticacao.Repository
{
    public class RepositoryUsuario(XContext context) : RepositoryBase<Usuario, Guid>(context), IRepositoryUsuario
    {
    }
}
