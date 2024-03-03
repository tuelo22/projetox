using projetox.Domain.Autenticacao.Entidades;
using projetox.Domain.Base.Interfaces.Repository;

namespace projetox.Domain.Autenticacao.Interfaces.Repository
{
    public interface IRepositoryUsuario : IRepositoryBase<Usuario, Guid>
    {
    }
}
