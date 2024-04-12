using projetox.Domain.Autenticacao.DTO.Arguments;
using projetox.Domain.Base.DTO.Arguments;
using projetox.Domain.Base.Interfaces.Services;

namespace projetox.Domain.Autenticacao.Interfaces.Services
{
    public interface IRegistrarUsuarioService : IServiceBase
    {
        ResponseBaseDTO Registrar(NovoUsuarioDTO usuario);
    }
}
