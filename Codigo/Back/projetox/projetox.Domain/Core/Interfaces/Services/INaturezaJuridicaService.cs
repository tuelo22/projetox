using projetox.Domain.Base.Interfaces.Services;
using projetox.Domain.Core.DTO.Arguments;

namespace projetox.Domain.Core.Interfaces.Services
{
    public interface INaturezaJuridicaService : IServiceBase
    {
        ListarNaturezaJuridicoResponseDTO ListarTodos();
    }
}
