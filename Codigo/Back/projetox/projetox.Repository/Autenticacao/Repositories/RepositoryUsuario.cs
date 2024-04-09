using projetox.Domain.Autenticacao.Entidades;
using projetox.Domain.Autenticacao.Interfaces.Repositories;
using projetox.Repository.Base.Repository;

namespace projetox.Repository.Autenticacao.Repositories
{
    public class RepositoryUsuario(XContext context) : RepositoryBase<Usuario, Guid>(context), IRepositoryUsuario
    {
    }
}
