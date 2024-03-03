using projetox.Domain.Base.DTO.Arguments;
using projetox.Domain.Base.Interfaces.Service;

namespace projetox.Domain.Autenticacao.Interfaces.Service
{
    public interface IResetarSenhaUsuario : IServiceBase
    {
        ResponseBaseDTO Resetar(String email);
    }
}
