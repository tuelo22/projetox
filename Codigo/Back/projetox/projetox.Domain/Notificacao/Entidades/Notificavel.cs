using projetox.Domain.Notification.Interfaces;

namespace projetox.Domain.Notification.Entidades
{
    public abstract class Notificavel : INotificavel
    {
        private static List<Mensagem> Mensagens => new();

        public IReadOnlyCollection<Mensagem> GetMensagens()
        {
            return Mensagens;
        }

        public void AddMensagem(Mensagem mensagem)
        {
            Mensagens.Add(mensagem);
        }

        public void AddMensagens(INotificavel notificavel)
        {
            Mensagens.AddRange(notificavel.GetMensagens());
        }

        public void Limpar()
        {
            Mensagens.Clear();
        }

        public bool Valido()
        {
            return Mensagem.Sucesso(Mensagens);
        }
    }
}
