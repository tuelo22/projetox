using projetox.Domain.Autenticacao.DTO.Arguments.Usuario;
using projetox.Domain.Base.DTO.Arguments;
using projetox.Domain.Base.Interfaces.Service;

namespace projetox.Domain.Autenticacao.Interfaces.Service
{
    public interface IRegistrarUsuarioService : IServiceBase
    {
        ResponseBaseDTO Registrar(NovoUsuarioDTO usuario);
    }
}
