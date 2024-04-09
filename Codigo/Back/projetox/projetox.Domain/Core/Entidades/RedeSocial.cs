using projetox.Domain.Base.Entidades;
using projetox.Domain.Notification.Entidades;

namespace projetox.Domain.Core.Entidades
{
    public class RedeSocial : BaseEntity
    {
        public string Nome { get; set; }
        public string URLPerfil { get; set; }
        public Empresa Empresa { get; set; }

        public RedeSocial(Guid? id, string nome, string uRLPerfil, Empresa empresa)
        {
            Id = id ?? Guid.NewGuid();

            Nome = nome;

            if (String.IsNullOrEmpty(nome))
            {
                AddMensagem(Mensagem.Error("É obrigatório informar o nome da rede social."));
            }

            URLPerfil = uRLPerfil;

            if (String.IsNullOrEmpty(uRLPerfil))
            {
                AddMensagem(Mensagem.Error("É obrigatório informar a url da rede social."));
            }

            Empresa = empresa;
        }
    }
}
