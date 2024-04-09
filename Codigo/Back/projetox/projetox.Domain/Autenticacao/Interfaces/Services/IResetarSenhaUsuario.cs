using projetox.Domain.Base.DTO.Arguments;
using projetox.Domain.Base.Interfaces.Services;

namespace projetox.Domain.Autenticacao.Interfaces.Services
{
    public interface IResetarSenhaUsuario : IServiceBase
    {
        ResponseBaseDTO Resetar(String email);
    }
}
