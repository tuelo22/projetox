using projetox.Domain.Autenticacao.DTO;
using projetox.Domain.Base.Interfaces.Services;

namespace projetox.Domain.Autenticacao.Interfaces.Services
{
    public interface ITokenService : IServiceBase
    {
        TokenDTO Gerar(LoginDTO? usuario);
    }
}
