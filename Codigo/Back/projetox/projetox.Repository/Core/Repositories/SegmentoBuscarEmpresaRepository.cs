using projetox.Domain.Core.Entidades;
using projetox.Domain.Core.Interfaces.Repositories;
using projetox.Repository.Base.Repository;

namespace projetox.Repository.Core.Repositories
{
    public class SegmentoBuscarEmpresaRepository(XContext context) : RepositoryBase<SegmentoBuscarEmpresa, Guid>(context), ISegmentoBuscarEmpresaRepository
    {
    }
}
