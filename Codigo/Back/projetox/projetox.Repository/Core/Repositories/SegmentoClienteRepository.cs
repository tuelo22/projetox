using projetox.Domain.Core.Entidades;
using projetox.Domain.Core.Interfaces.Repositories;
using projetox.Repository.Base.Repository;

namespace projetox.Repository.Core.Repositories
{
    public class SegmentoClienteRepository(XContext context) : RepositoryBase<SegmentoCliente, Guid>(context), ISegmentoClienteRepository
    {
    }
}
