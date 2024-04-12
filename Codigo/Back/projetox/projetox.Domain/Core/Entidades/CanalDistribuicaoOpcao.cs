using projetox.Domain.Base.Entidades;
using projetox.Domain.Notification.Entidades;

namespace projetox.Domain.Core.Entidades
{
    public class CanalDistribuicaoOpcao : BaseEntity
    {
        public String Descricao { get; private set; }
        public virtual ICollection<CanalDistribuicao> CanaisDistribuicao { get; private set; } = [];
        public virtual ICollection<PropostaValor> PropostasValor { get; private set; } = [];

        /// <summary>
        /// Construtor do Entity.
        /// </summary>
        public CanalDistribuicaoOpcao() { }

        /// <summary>
        /// Construtor principal.
        /// </summary>
        /// <param name="descricao"></param>
        /// <param name="propostaValor"></param>
        public CanalDistribuicaoOpcao(String descricao)
        {
            Descricao = descricao;

            if (String.IsNullOrEmpty(Descricao))
            {
                AddMensagem(Mensagem.Error("É obrigatório informar a descrição da opção do canal de distribuição."));
            }
        }

        /// <summary>
        /// Construtor principal.
        /// </summary>
        /// <param name="descricao"></param>
        /// <param name="propostaValor"></param>
        public CanalDistribuicaoOpcao(String id, String descricao)
        {
            Id = Guid.Parse(id);
            Descricao = descricao;

            if (String.IsNullOrEmpty(Descricao))
            {
                AddMensagem(Mensagem.Error("É obrigatório informar a descrição da opção do canal de distribuição."));
            }
        }
    }
}
