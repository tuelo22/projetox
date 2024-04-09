using projetox.Domain.Autenticacao.ValueObjects;

namespace projetox.test.Autenticacao.ValueObjects
{
    public class NomeTest
    {
        [Fact]
        public void Nome_CriacaoComParametrosValidos_DeveInstanciarCorretamente()
        {
            // Arrange
            var primeiroNome = "Nome de Teste";
            var sobreNome = "Sobrenome de teste";

            // Act
            var nome = new Nome(primeiroNome, sobreNome);

            // Assert
            Assert.NotNull(nome);
            Assert.Equal(nome.PrimeiroNome, primeiroNome);
            Assert.Equal(nome.Sobrenome, sobreNome);
            Assert.True(nome.Valido());
        }
    }
}
