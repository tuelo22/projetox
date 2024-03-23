using projetox.Domain.Base.Extends;
using projetox.Domain.Notification.Entidades;

namespace projetox.Domain.Core.ValueObjects
{
    public class Telefone : Notificavel
    {
        public String Numero { get; private set; }

        public Telefone(String numero)
        {
            Numero = numero.RetornaApenasNumeros();

            if (String.IsNullOrEmpty(numero))
            {
                AddMensagem(Mensagem.Error("É obrigatório informar o número de telefone."));
            }

            if (Numero.Length != numero.Length)
            {
                AddMensagem(Mensagem.Error("É obrigatório informar apenas números no telefone."));
            }
        }

        public override string ToString()
        {
            return Numero;
        }
    }
}
