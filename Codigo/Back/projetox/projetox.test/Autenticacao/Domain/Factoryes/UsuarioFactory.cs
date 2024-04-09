using projetox.Domain.Autenticacao.Entidades;
using projetox.Domain.Autenticacao.ValueObjects;
using projetox.Domain.Base.ValueObjects;
using projetox.Domain.Core.ValueObjects;

namespace projetox.test.Autenticacao.Domain.Factoryes
{
    public static class UsuarioFactory
    {
        public static Usuario CriarUsuarioPadrao()
        {
            Guid id = Guid.NewGuid();
            Nome nome = new("Julio", "Francis");
            Documento documento = new("234.908.170-28");
            Email email = new("julio@gmail.com");
            Senha senha = new("*Senha12");
            Telefone telefone = new("21991902196");
            return new(id, nome, documento, email, senha, telefone);
        }
    }
}
