using projetox.Domain.Notification.Entidades;

namespace projetox.Domain.Autenticacao.ValueObjects
{
    public class Nome : Notificavel
    {
        public String PrimeiroNome { get; set; }
        public String Sobrenome { get; set; }

        public Nome()
        {
            PrimeiroNome = String.Empty;
            Sobrenome = String.Empty;
        }

        public Nome(String primeiroNome, String sobrenome)
        {
            PrimeiroNome = primeiroNome;
            Sobrenome = sobrenome;

            if (String.IsNullOrEmpty(PrimeiroNome))
            {
                AddMensagem(Mensagem.Error("É obrigatório informar o primeiro nome."));
            }

            if (String.IsNullOrEmpty(sobrenome))
            {
                AddMensagem(Mensagem.Error("É obrigatório informar o sobrenome."));
            }
        }
    }
}
