using projetox.Domain.Core.Entidades;
using projetox.Domain.Core.Interfaces.Repositories;
using projetox.Repository.Base.Repository;

namespace projetox.Repository.Core.Repositories
{
    public class CanalDistribuicaoOpcaoRepository(XContext context) : RepositoryBase<CanalDistribuicaoOpcao, Guid>(context), ICanalDistribuicaoOpcaoRepository
    {
    }
}
