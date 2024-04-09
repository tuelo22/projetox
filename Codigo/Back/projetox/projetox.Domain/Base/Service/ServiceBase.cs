using projetox.Domain.Base.DTO.Arguments;
using projetox.Domain.Base.Interfaces.Services;
using projetox.Domain.Notification.DTO;
using projetox.Domain.Notification.Entidades;

namespace projetox.Domain.Base.Service
{
    public class ServiceBase: Notificavel, IServiceBase
    {
        public List<MensagemDTO> GetMensagensDTO()
        {
            return GetMensagens().ToList().Select(x => (MensagemDTO)x).ToList();
        }
        public virtual ResponseBaseDTO GetRetorno() => new ()
        {
            Mensagens = GetMensagensDTO(),
        };
    }
}
