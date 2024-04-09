using projetox.Domain.Autenticacao.Entidades;
using projetox.Domain.Base.Interfaces.Repositories;

namespace projetox.Domain.Autenticacao.Interfaces.Repositories
{
    public interface IRepositoryUsuario : IRepositoryBase<Usuario, Guid>
    {
    }
}
