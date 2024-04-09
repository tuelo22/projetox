using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using projetox.Domain.Autenticacao.DTO.Arguments.Token;
using projetox.Domain.Autenticacao.DTO.Arguments.Usuario;
using projetox.Domain.Autenticacao.Interfaces.Repositories;
using projetox.Domain.Autenticacao.Interfaces.Services;
using projetox.Domain.Autenticacao.ValueObjects;
using projetox.Domain.Base.Service;
using projetox.Domain.Notification.Entidades;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace projetox.Domain.Autenticacao.Services
{
    public class TokenService : ServiceBase, ITokenService
    {
        private readonly IRepositoryUsuario _RepositoryUsuario;
        private readonly IConfiguration _Configuration;

        public TokenService(IConfiguration configuration, IRepositoryUsuario repositoryUsuario)
        {
            _Configuration = configuration;
            _RepositoryUsuario = repositoryUsuario;
        }

        private TokenDTO GetReturn(string? token = null)
        {
            return new TokenDTO()
            {
                Token = token
            };
        }

        public TokenDTO Gerar(LoginDTO? dto)
        {
            if(dto == null)
            {
                AddMensagem(Mensagem.Error("É obrigatório informar os dados do usuário."));

                return GetReturn();
            }

            Senha senhacriptografada = new(dto?.Senha ?? string.Empty);
            String Login = dto?.Login ?? string.Empty;

            var usuario = _RepositoryUsuario.ListarPor(x => x.Email.Endereco == Login.ToLower() && x.Senha.Valor == senhacriptografada.Valor).FirstOrDefault();

            if (usuario == null)
            {
                AddMensagem(Mensagem.Error("Dados incorretos."));

                return GetReturn();
            }

            if (Valido() && usuario != null)
            {
                var secretkey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_Configuration["Jwt:key"] ?? String.Empty));
                String issuer = _Configuration["Jwt:Issuer"] ?? String.Empty;
                String audience = _Configuration["Jwt:Audience"] ?? String.Empty;
                var signinCredentials = new SigningCredentials(secretkey, SecurityAlgorithms.HmacSha256);
                var _tokenOptions = new JwtSecurityToken(
                     issuer : issuer, 
                     audience: audience,
                     claims: new[]
                     {
                         new Claim(type: ClaimTypes.Name, value: usuario.Email.Endereco),
                         new Claim(type: ClaimTypes.Name, value: "Geral")
                     },
                     expires:DateTime.Now.AddDays(1),
                     signingCredentials: signinCredentials
                );

                var token = new JwtSecurityTokenHandler().WriteToken( _tokenOptions);

                AddMensagem(Mensagem.Info("Login realizado com sucesso !"));

                return GetReturn(token);
            }

            return GetReturn();
        }
    }
}
