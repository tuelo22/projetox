using projetox.Domain.Autenticacao.Entidades;
using projetox.Domain.Autenticacao.ValueObjects;
using projetox.Domain.Base.ValueObjects;
using projetox.Domain.Core.ValueObjects;

namespace projetox.test.Autenticacao.Entities
{
    public class UsuarioTest
    {
        [Fact]
        public void Usuario_CriacaoComParametrosValidos_DeveInstanciarCorretamente()
        {
            // Arrange
            var id = Guid.NewGuid();
            var nome = new Nome("Nome de Teste", "Sobrenome de teste");
            var documento = new Documento("123456789");
            var email = new Email("teste@teste.com");
            var senha = new Senha("senhaForte123");
            var telefone = new Telefone("11999999999");

            // Act
            var usuario = new Usuario(id, nome, documento, email, senha, telefone);

            // Assert
            Assert.NotNull(usuario);
            Assert.Equal(usuario.Id, id);
            Assert.Equal(nome, usuario.Nome);
            Assert.Equal(documento, usuario.Documento);
            Assert.Equal(email, usuario.Email);
            Assert.Equal(senha, usuario.Senha);
            Assert.Equal(telefone, usuario.Telefone);
            Assert.Empty(usuario.Empresas);
            Assert.True(usuario.Valido());
        }
    }
}
