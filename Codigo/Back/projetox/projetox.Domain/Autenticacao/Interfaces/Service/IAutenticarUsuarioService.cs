using projetox.Domain.Autenticacao.DTO.Arguments.Usuario;
using projetox.Domain.Autenticacao.Entidades;
using projetox.Domain.Base.Interfaces.Service;

namespace projetox.Domain.Autenticacao.Interfaces.Service
{
    public interface IAutenticarUsuarioService : IServiceBase
    {
        Usuario? Autenticar(String Emial, String Senha);
    }
}
