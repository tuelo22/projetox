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
        public virtual ICollection<Empresa> Empresas { get; } = [];

        public Usuario(Guid? id, Nome nome, Documento documento, Email email, Senha senha, Telefone telefone)
        {
            Id = id ?? Guid.NewGuid();
            Nome = nome;
            Documento = documento;
            Email = email;
            Senha = senha;
            Telefone = telefone;
        }
    }
}
