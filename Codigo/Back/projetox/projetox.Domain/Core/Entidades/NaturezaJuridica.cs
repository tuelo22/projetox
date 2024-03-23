using projetox.Domain.Base.Entidades;
using projetox.Domain.Notification.Entidades;

namespace projetox.Domain.Core.Entidades
{
    public class NaturezaJuridica : PersistenceEntity
    {
        public required String Descricao { get; set; }

        public NaturezaJuridica(string descricao)
        {
            Descricao = descricao;

            if (String.IsNullOrEmpty(descricao))
            {
                AddMensagem(Mensagem.Error("É obrigatório informar a descrição da natureza juridica."));
            }
        }

        public NaturezaJuridica(){}
    }
}
