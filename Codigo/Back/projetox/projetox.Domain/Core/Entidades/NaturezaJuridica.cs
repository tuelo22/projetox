using projetox.Domain.Base.Entidades;
using projetox.Domain.Notification.Entidades;

namespace projetox.Domain.Core.Entidades
{
    public class NaturezaJuridica : BaseEntity
    {
        public String Descricao { get; private set; }
        public virtual ICollection<Empresa> Empresas { get; private set; } = [];

        /// <summary>
        /// Constu
        /// </summary>
        public NaturezaJuridica()
        {}

        /// <summary>
        /// Construtor principal.
        /// </summary>
        /// <param name="descricao"></param>
        public NaturezaJuridica(string descricao)
        {
            Descricao = descricao;

            if (String.IsNullOrEmpty(descricao))
            {
                AddMensagem(Mensagem.Error("É obrigatório informar a descrição da natureza juridica."));
            }
        }

        /// <summary>
        /// Construtor principal.
        /// </summary>
        /// <param name="descricao"></param>
        public NaturezaJuridica(String id, string descricao)
        {
            Id = Guid.Parse(id);
            Descricao = descricao;

            if (String.IsNullOrEmpty(descricao))
            {
                AddMensagem(Mensagem.Error("É obrigatório informar a descrição da natureza juridica."));
            }
        }
    }
}
