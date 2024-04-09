using projetox.Domain.Autenticacao.ValueObjects;

namespace projetox.test.Autenticacao.ValueObjects
{
    public class SenhaTest
    {
        [Fact]
        public void Senha_CriacaoComParametrosValidos_DeveInstanciarCorretamente()
        {
            // Arrange
            string SenhaValor = "*Abcd1234";
            string SenhaCriptografada = "8b8d9b64231fc79907c345c5f0c7beae0f553a715a87ab45def2ff9f3f5e100d57c3504f-61c6-4476-8542-95a48779ff61";

            // Act
            var senha = new Senha(SenhaValor);

            // Assert
            Assert.NotNull(senha);
            Assert.Equal(senha.Valor, SenhaCriptografada);
            Assert.True(senha.Valido());
        }

        [Fact]
        public void Senha_CriacaoComParametrosInvalidos_DeveInstanciarInvalido()
        {
            // Arrange
            string SenhaValor = "*Abcd1";
            // Caso tenha erros a senha não será criptografada.
            string SenhaCriptografada = "*Abcd1";

            // Act
            var senha = new Senha(SenhaValor);

            // Assert
            Assert.NotNull(senha);
            Assert.Equal(senha.Valor, SenhaCriptografada);
            Assert.False(senha.Valido());
        }

        [Fact]
        public void Senha_ResetarSenha()
        {
            // Arrange
            string SenhaValor = "*Abcd1234";
            string SenhaCriptografada = "8b8d9b64231fc79907c345c5f0c7beae0f553a715a87ab45def2ff9f3f5e100d57c3504f-61c6-4476-8542-95a48779ff61";

            var senha = new Senha(SenhaValor);
            // Act
            senha.ResetarSenha();

            // Assert
            Assert.NotNull(senha);
            Assert.NotEqual(senha.Valor, SenhaCriptografada);
            Assert.True(senha.Valido());
        }

    }
}
