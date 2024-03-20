using projetox.Domain.Autenticacao.DTO.Arguments.Usuario;
using projetox.Domain.Base.Interfaces.Service;

namespace projetox.Domain.Autenticacao.Interfaces.Service
{
    public interface ITokenService : IServiceBase
    {
        String Gerar(LoginDTO? usuario);
    }
}
