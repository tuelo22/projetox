using projetox.Domain.Base.Entidades;
using projetox.Domain.Notification.Entidades;

namespace projetox.Domain.Core.Entidades
{
    public class CanalDistribuicao : BaseEntity
    {
        public string Descricao { get; private set; }

        public virtual SegmentoCliente SegmentoCliente { get; private set; }
        public virtual CanalDistribuicaoOpcao? CanalDistribuicaoOpcao { get; private set; }

        /// <summary>
        /// Construtor do Entity.
        /// </summary>
        public CanalDistribuicao() { }
        /// <summary>
        /// Construtor principal.
        /// </summary>
        /// <param name="Descricao"></param>
        /// <param name="SegmentoCliente"></param>
        /// <param name="CanalDistribuicaoOpcao"></param>
        public CanalDistribuicao(string Descricao, SegmentoCliente SegmentoCliente, CanalDistribuicaoOpcao? CanalDistribuicaoOpcao)
        {
            this.Descricao = Descricao;

            if (String.IsNullOrEmpty(Descricao))
            {
                AddMensagem(Mensagem.Error("É obrigatório informar a descrição do seguimento reclamacao atendimento."));
            }

            this.SegmentoCliente = SegmentoCliente;
            this.CanalDistribuicaoOpcao = CanalDistribuicaoOpcao;
        }
    }
}
