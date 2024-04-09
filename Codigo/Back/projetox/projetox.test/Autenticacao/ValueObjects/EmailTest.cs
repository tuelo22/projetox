using projetox.Domain.Autenticacao.ValueObjects;

namespace projetox.test.Autenticacao.ValueObjects
{
    public class EmailTest
    {
        [Fact]
        public void Email_CriacaoComParametrosValidos_DeveInstanciarCorretamente()
        {
            // Arrange
            string Enderecoemail = "julio@gmail.com";

            // Act
            var email = new Email(Enderecoemail);

            // Assert
            Assert.NotNull(email);
            Assert.Equal(email.Endereco, Enderecoemail);
            Assert.True(email.Valido());
        }

        [Fact]
        public void Email_CriacaoComParametrosInvalido_DeveInstanciarInvalido()
        {
            // Arrange
            string Enderecoemail = "juliogmailcom";

            // Act
            var email = new Email(Enderecoemail);

            // Assert
            Assert.NotNull(email);
            Assert.Equal(email.Endereco, Enderecoemail);
            Assert.False(email.Valido());
        }
    }
}
