using projetox.Domain.Base.Entidades;
using projetox.Domain.Notification.Entidades;

namespace projetox.Domain.Core.Entidades
{
    public class FonteReceita : BaseEntity
    {
        public String Descricao { get; private set; }
        public virtual PropostaValor PropostaValor { get; private set; }

        /// <summary>
        /// Construtor do Entity
        /// </summary>
        public FonteReceita()
        {}

        /// <summary>
        /// Construtor principal.
        /// </summary>
        /// <param name="descricao"></param>
        /// <param name="propostaValor"></param>
        public FonteReceita(String descricao, PropostaValor propostaValor)
        {
            Descricao = descricao;
            PropostaValor = propostaValor;

            if (String.IsNullOrEmpty(Descricao))
            {
                AddMensagem(Mensagem.Error("É obrigatório informar a descrição da fonte de receita."));
            }
        }
    }
}
