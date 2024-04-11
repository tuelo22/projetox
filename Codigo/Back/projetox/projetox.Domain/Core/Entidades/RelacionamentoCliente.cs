using projetox.Domain.Base.Entidades;
using projetox.Domain.Notification.Entidades;

namespace projetox.Domain.Core.Entidades
{
    public class RelacionamentoCliente : BaseEntity
    {
        public String Descricao { get; private set; }
        public virtual PropostaValor PropostaValor { get; private set; }

        /// <summary>
        /// Construtor do Entity.
        /// </summary>
        public RelacionamentoCliente(){}

        /// <summary>
        /// Construtor principal.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="descricao"></param>
        /// <param name="propostaValor"></param>
        public RelacionamentoCliente(String descricao, PropostaValor propostaValor)
        {
            Descricao = descricao;
            PropostaValor = propostaValor;

            if (String.IsNullOrEmpty(Descricao))
            {
                AddMensagem(Mensagem.Error("É obrigatório informar a descrição do relacionamento com o cliente."));
            }
        }
    }
}
