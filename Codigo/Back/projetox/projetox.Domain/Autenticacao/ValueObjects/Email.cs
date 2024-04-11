using projetox.Domain.Notification.Entidades;

namespace projetox.Domain.Autenticacao.ValueObjects
{
    public class Email : Notificavel
    {
        public Boolean Confirmado { get; private set; }
        public string Endereco { get; private set; }

        /// <summary>
        /// Construtor do Entity
        /// </summary>
        public Email(){}

        /// <summary>
        /// Construtor padrão.
        /// </summary>
        /// <param name="endereco"></param>
        /// <param name="confirmado"></param>
        public Email(string endereco, Boolean confirmado = false)
        {
            Confirmado = confirmado;
            Endereco = endereco.ToLower();

            if (!Valido(endereco))
            {
                AddMensagem(Mensagem.Error("Email invalido."));
            }
        }

        private static bool Valido(string endereco)
        {
            if (string.IsNullOrWhiteSpace(endereco))
            {
                return false;
            }

            try
            {               
                var addr = new System.Net.Mail.MailAddress(endereco);
                return addr.Address == endereco; 
            }
            catch
            {
                return false;
            }
        }
    }
}
