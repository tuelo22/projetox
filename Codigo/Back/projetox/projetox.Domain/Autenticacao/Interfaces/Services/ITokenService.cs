using projetox.Domain.Autenticacao.DTO.Arguments.Token;
using projetox.Domain.Autenticacao.DTO.Arguments.Usuario;
using projetox.Domain.Base.Interfaces.Services;

namespace projetox.Domain.Autenticacao.Interfaces.Services
{
    public interface ITokenService : IServiceBase
    {
        TokenDTO Gerar(LoginDTO? usuario);
    }
}
