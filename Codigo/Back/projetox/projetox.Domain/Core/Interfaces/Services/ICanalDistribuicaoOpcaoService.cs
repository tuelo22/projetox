using projetox.Domain.Base.Interfaces.Services;
using projetox.Domain.Core.DTO.Arguments;

namespace projetox.Domain.Core.Interfaces.Services
{
    public interface ICanalDistribuicaoOpcaoService : IServiceBase
    {
        public ListarCanalDistribuicaoOpcaoDTO ListarTodos();
    }
}
