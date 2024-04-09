using projetox.Domain.Notification.Entidades;

namespace projetox.Domain.Autenticacao.ValueObjects
{
    public class Email : Notificavel
    {
        public Boolean Confirmado { get; set; }
        public string Endereco { get; set; }

        public Email(string endereco)
        {
            Confirmado = false;
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
