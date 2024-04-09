using Moq;
using projetox.Domain.Autenticacao.DTO.Arguments.Usuario;
using projetox.Domain.Autenticacao.Entidades;
using projetox.Domain.Autenticacao.Interfaces.Repositories;
using projetox.Domain.Autenticacao.Services;

namespace projetox.test.Autenticacao.Service
{
    public class RegistrarUsuarioServiceTest
    {
        [Fact]
        public void Registrar_ComInformacoesValidas_DeveRegistrarUsuario()
        {
            // Arrange
            var repositoryMock = new Mock<IRepositoryUsuario>();
            repositoryMock.Setup(repo => repo.ObterPor(It.IsAny<Func<Usuario, bool>>())).Returns((Usuario)null);

            var service = new RegistrarUsuarioService(repositoryMock.Object);

            var novoUsuarioDTO = new NovoUsuarioDTO
            {
                PrimeiroNome = "Primeiro",
                Sobrenome = "Sobrenome",
                Email = "usuario@teste.com",
                Senha = "Senha123!",
                ConfirmacaoSenha = "Senha123!",
                NumeroDocumento = "27949555009",
                Telefone = "11999999999"
            };

            // Act
            var response = service.Registrar(novoUsuarioDTO);

            // Assert
            Assert.Contains("Usuário cadastrado com sucesso !", response.Mensagens.Select(m => m.Mensagem));
            repositoryMock.Verify(repo => repo.Adicionar(It.IsAny<Usuario>()), Times.Once);
        }
    }
}
