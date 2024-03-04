using projetox.Domain.Autenticacao.Interfaces.Service;
using projetox.Domain.Base.DTO.Arguments;
using projetox.Domain.Notification.Entidades;

namespace projetox.Domain.Autenticacao.Services
{
    public class ResetarSenhaUsuario : Notificavel, IResetarSenhaUsuario
    {
        public ResponseBaseDTO Resetar(string email)
        {
            throw new NotImplementedException();
        }
    }
}
