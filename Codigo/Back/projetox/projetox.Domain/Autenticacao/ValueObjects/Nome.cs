using projetox.Domain.Notification.Entidades;

namespace projetox.Domain.Autenticacao.ValueObjects
{
    public class Nome : Notificavel
    {
        public String PrimeiroNome { get; private set; }
        public String Sobrenome { get; private set; }

        /// <summary>
        /// Construtor do Entity.
        /// </summary>
        public Nome(){}

        /// <summary>
        /// Construtor principal.
        /// </summary>
        /// <param name="primeiroNome"></param>
        /// <param name="sobrenome"></param>
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
