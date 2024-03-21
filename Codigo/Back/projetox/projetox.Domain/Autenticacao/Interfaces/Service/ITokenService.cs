using projetox.Domain.Autenticacao.DTO.Arguments.Token;
using projetox.Domain.Autenticacao.DTO.Arguments.Usuario;
using projetox.Domain.Base.Interfaces.Service;

namespace projetox.Domain.Autenticacao.Interfaces.Service
{
    public interface ITokenService : IServiceBase
    {
        TokenDTO Gerar(LoginDTO? usuario);
    }
}
