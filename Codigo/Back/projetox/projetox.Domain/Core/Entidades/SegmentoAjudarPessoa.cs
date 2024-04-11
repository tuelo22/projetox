using projetox.Domain.Base.Entidades;
using projetox.Domain.Notification.Entidades;

namespace projetox.Domain.Core.Entidades
{
    public class SegmentoAjudarPessoa : BaseEntity
    {
        public string Descricao { get; private set; }

        public virtual SegmentoCliente SegmentoCliente { get; private set; }

        /// <summary>
        /// Construtor do Entity.
        /// </summary>
        public SegmentoAjudarPessoa() { }
        /// <summary>
        /// Construtor principal.
        /// </summary>
        /// <param name="Descricao"></param>
        /// <param name="SegmentoCliente"></param>
        public SegmentoAjudarPessoa(string Descricao, SegmentoCliente SegmentoCliente)
        {
            this.Descricao = Descricao;

            if (String.IsNullOrEmpty(Descricao))
            {
                AddMensagem(Mensagem.Error("É obrigatório informar a descrição do seguimento reclamacao atendimento."));
            }

            this.SegmentoCliente = SegmentoCliente;
        }
    }
}
