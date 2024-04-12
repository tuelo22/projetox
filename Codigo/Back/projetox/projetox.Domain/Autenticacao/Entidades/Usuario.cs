using projetox.Domain.Autenticacao.ValueObjects;
using projetox.Domain.Base.Entidades;
using projetox.Domain.Base.ValueObjects;
using projetox.Domain.Core.Entidades;
using projetox.Domain.Core.ValueObjects;

namespace projetox.Domain.Autenticacao.Entidades
{
    public class Usuario : BaseEntity
    {
        public Nome Nome { get; private set; }
        public Documento Documento { get; private set; }
        public Email Email { get; private set; }
        public Senha Senha { get; private set; }
        public Telefone Telefone { get; private set; }
        public virtual ICollection<Empresa> Empresas { get; private set; } = [];

        /// <summary>
        /// Construtor do Entity.
        /// </summary>
        public Usuario(){}

        /// <summary>
        /// Construtor principal.
        /// </summary>
        public Usuario(Nome Nome, Documento Documento, Email Email, Senha Senha, Telefone Telefone)
        {
            this.Nome = Nome;
            this.Documento = Documento;
            this.Email = Email;
            this.Senha = Senha;
            this.Telefone = Telefone;
        }
    }
}
