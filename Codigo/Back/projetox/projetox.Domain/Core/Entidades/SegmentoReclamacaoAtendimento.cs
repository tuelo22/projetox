using projetox.Domain.Base.Entidades;
using projetox.Domain.Notification.Entidades;

namespace projetox.Domain.Core.Entidades
{
    public class SegmentoReclamacaoAtendimento : BaseEntity
    {
        public string Descricao { get; private set; }

        public virtual SegmentoCliente SegmentoCliente { get; private set; }

        public SegmentoReclamacaoAtendimento() { }

        public SegmentoReclamacaoAtendimento(string Descricao, SegmentoCliente SegmentoCliente)
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
