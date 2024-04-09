using projetox.Domain.Base.Entidades;
using projetox.Domain.Notification.Entidades;

namespace projetox.Domain.Core.Entidades
{
    public class NaturezaJuridica : BaseEntity
    {
        public String Descricao { get; private set; }
        public virtual IList<Empresa> Empresa { get; private set; } = [];

        public NaturezaJuridica(Guid? id, string descricao)
        {
            Id = id ?? Guid.NewGuid();
            Descricao = descricao;

            if (String.IsNullOrEmpty(descricao))
            {
                AddMensagem(Mensagem.Error("É obrigatório informar a descrição da natureza juridica."));
            }
        }
    }
}
