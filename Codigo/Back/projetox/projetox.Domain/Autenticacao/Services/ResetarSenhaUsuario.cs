using projetox.Domain.Autenticacao.Interfaces.Services;
using projetox.Domain.Base.DTO.Arguments;
using projetox.Domain.Base.Service;
using projetox.Domain.Notification.Entidades;

namespace projetox.Domain.Autenticacao.Services
{
    public class ResetarSenhaUsuario : ServiceBase, IResetarSenhaUsuario
    {
        public ResponseBaseDTO Resetar(string email)
        {
            throw new NotImplementedException();
        }
    }
}
