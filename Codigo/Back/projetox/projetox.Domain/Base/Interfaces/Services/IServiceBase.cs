using projetox.Domain.Notification.DTO;
using projetox.Domain.Notification.Interfaces;

namespace projetox.Domain.Base.Interfaces.Services
{
    public interface IServiceBase : INotificavel
    {
        List<MensagemDTO> GetMensagensDTO();
    }
}
