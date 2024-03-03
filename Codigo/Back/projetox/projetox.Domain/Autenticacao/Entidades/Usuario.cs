using projetox.Domain.Autenticacao.ValueObjects;
using projetox.Domain.Base.Entidades;
using projetox.Domain.Notification.Entidades;

namespace projetox.Domain.Autenticacao.Entidades
{
    public class Usuario : PersistenceEntity
    {
        public Nome Nome { get; set; }
        public Documento Documento { get; set; }
        public Email Email { get; set; }
        public Senha Senha { get; set; }
        public String Telefone { get; set; }

        public Usuario()
        {
        }

        public Usuario(Nome nome, Documento documento, Email email, Senha senha, string telefone)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Documento = documento;
            Email = email;
            Senha = senha;
            Telefone = telefone;

            if (String.IsNullOrEmpty(telefone))
            {
                AddMensagem(Mensagem.Error("É obrigatório a informação de telefone."));
            }
        }
    }
}
