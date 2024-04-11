using projetox.Domain.Notification.Enumerados;
using projetox.Domain.Notification.Interfaces;

namespace projetox.Domain.Notification.Entidades
{
    public abstract class Notificavel : INotificavel
    {
        private readonly List<Mensagem> Mensagens = [];

        public IReadOnlyCollection<Mensagem> GetMensagens() => Mensagens;

        public void AddMensagem(Mensagem mensagem)
        {
            Mensagens.Add(mensagem);
        }

        public void AddMensagens(INotificavel notificavel)
        {
            var mensagens = notificavel.GetMensagens().ToList();

            Mensagens.AddRange(mensagens);
        }

        public void Limpar()
        {
            Mensagens.Clear();
        }

        public bool Valido()
        {
           var erro = Mensagens.Where(x => x.TipoMensagem == TipoMensagem.Error || x.TipoMensagem == TipoMensagem.Fatal).ToList();

            return erro.Count == 0;
        }
    }
}
