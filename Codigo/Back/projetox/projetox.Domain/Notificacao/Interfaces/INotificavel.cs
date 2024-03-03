using projetox.Domain.Notification.Entidades;

namespace projetox.Domain.Notification.Interfaces
{
    public interface INotificavel
    {
        IReadOnlyCollection<Mensagem> GetMensagens();

        void AddMensagens(INotificavel notificavel);

        void AddMensagem(Mensagem mensagem);

        void Limpar();

        bool Valido();
    }
}
