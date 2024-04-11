using projetox.Domain.Base.Entidades;
using projetox.Domain.Notification.Entidades;

namespace projetox.Domain.Core.Entidades
{
    public class RedeSocial : BaseEntity
    {
        public string Nome { get; set; }
        public string URLPerfil { get; set; }
        public virtual Empresa Empresa { get; set; }

        /// <summary>
        /// Construtor do Entity.
        /// </summary>
        public RedeSocial(){ }

        /// <summary>
        /// Construtor principal.
        /// </summary>
        /// <param name="nome"></param>
        /// <param name="uRLPerfil"></param>
        /// <param name="empresa"></param>
        public RedeSocial(string nome, string uRLPerfil, Empresa empresa)
        {
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
