using Microsoft.Extensions.Configuration;
using Moq;
using projetox.Domain.Autenticacao.DTO.Arguments.Usuario;
using projetox.Domain.Autenticacao.Entidades;
using projetox.Domain.Autenticacao.Interfaces.Repositories;
using projetox.Domain.Autenticacao.Services;
using projetox.test.Autenticacao.Factoryes;
using System.Linq.Expressions;
using System.Security.Cryptography;

namespace projetox.test.Autenticacao.Service
{
    public class TokenServiceTests
    {
        [Fact]
        public void Gerar_QuandoDtoNulo_DeveRetornarTokenVazioEMensagemDeErro()
        {
            var configurationMock = new Mock<IConfiguration>();
            var repositoryUsuarioMock = new Mock<IRepositoryUsuario>();
            var service = new TokenService(configurationMock.Object, repositoryUsuarioMock.Object);

            var result = service.Gerar(null);

            Assert.Null(result.Token);
            Assert.Contains("É obrigatório informar os dados do usuário.", service.GetMensagens().Select(m => m.Valor));
        }

        [Fact]
        public void Gerar_QuandoDadosIncorretos_DeveRetornarTokenVazioEMensagemDeErro()
        {
            var configurationMock = new Mock<IConfiguration>();
            var repositoryUsuarioMock = new Mock<IRepositoryUsuario>();
            var service = new TokenService(configurationMock.Object, repositoryUsuarioMock.Object);

            var dto = new LoginDTO { Login = "usuario@teste.com", Senha = "senhaIncorreta" };

            // Mock do RepositoryUsuario retornando null, simula usuário não encontrado
            repositoryUsuarioMock.Setup(repo => repo.ListarPor(It.IsAny<Expression<Func<Usuario, bool>>>())).Returns(new List<Usuario>().AsQueryable());

            var result = service.Gerar(dto);

            Assert.Null(result.Token);
            Assert.Contains("Dados incorretos.", service.GetMensagens().Select(m => m.Valor));
        }

        [Fact]
        public void Gerar_QuandoLoginSucesso_DeveRetornarTokenNaoVazio()
        {

            //Gera secretekey para validar
            var secretKey = new byte[32]; 
            using (RNGCryptoServiceProvider rng = new())
            {
                rng.GetBytes(secretKey);
            }
            var base64SecretKey = Convert.ToBase64String(secretKey);

            var configurationMock = new Mock<IConfiguration>();
            configurationMock.SetupGet(x => x["Jwt:key"]).Returns(base64SecretKey);
            configurationMock.SetupGet(x => x["Jwt:Issuer"]).Returns("emissor_do_token");
            configurationMock.SetupGet(x => x["Jwt:Audience"]).Returns("audiencia_do_token");

            var repositoryUsuarioMock = new Mock<IRepositoryUsuario>();
            var service = new TokenService(configurationMock.Object, repositoryUsuarioMock.Object);
            var dto = new LoginDTO { Login = "julio@gmail.com", Senha = "*Senha12" };
            var usuario = UsuarioFactory.CriarUsuarioPadrao();
            var usuarios = new List<Usuario> { usuario };

            // Mock do RepositoryUsuario retornando o usuário válido
            repositoryUsuarioMock.Setup(repo => repo.ListarPor(It.IsAny<Expression<Func<Usuario, bool>>>())).Returns(usuarios.AsQueryable());

            var result = service.Gerar(dto);

            Assert.NotNull(result.Token);
            Assert.Contains("Login realizado com sucesso !", service.GetMensagens().Select(m => m.Valor));
        }
    }
}
