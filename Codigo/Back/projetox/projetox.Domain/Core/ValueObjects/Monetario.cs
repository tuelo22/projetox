using projetox.Domain.Notification.Entidades;

namespace projetox.Domain.Core.ValueObjects
{
    public class Monetario : Notificavel
    {
        public decimal Valor { get; private set; }

        /// <summary>
        /// Construtor do Entity
        /// </summary>
        public Monetario(){}

        /// <summary>
        /// Construtor padrão
        /// </summary>
        /// <param name="valor"></param>
        public Monetario(decimal valor)
        {
            if (valor < 0)
            {
                AddMensagem(Mensagem.Error("Valor monteário não pode ser negativo."));
            }

            Valor = valor;
        }

        public string Formatado()
        {
            return $"{Valor:N2}";
        }

        public static implicit operator decimal(Monetario d) => d.Valor;
        public static implicit operator Monetario(decimal valor) => new (valor);
    }
}
