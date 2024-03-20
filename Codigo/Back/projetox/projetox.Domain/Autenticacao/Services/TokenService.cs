using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using projetox.Domain.Autenticacao.DTO.Arguments.Usuario;
using projetox.Domain.Autenticacao.Interfaces.Repository;
using projetox.Domain.Autenticacao.Interfaces.Service;
using projetox.Domain.Autenticacao.ValueObjects;
using projetox.Domain.Notification.Entidades;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace projetox.Domain.Autenticacao.Services
{
    public class TokenService : Notificavel, ITokenService
    {
        private readonly IRepositoryUsuario _RepositoryUsuario;
        private readonly IConfiguration _Configuration;

        public TokenService(IConfiguration configuration, IRepositoryUsuario repositoryUsuario)
        {
            _Configuration = configuration;
            _RepositoryUsuario = repositoryUsuario;
        }

        public string Gerar(LoginDTO? dto)
        {
            if(dto == null)
            {
                AddMensagem(Mensagem.Error("É obrigatório informar os dados do usuário."));

                return String.Empty;
            }

            Senha senhacriptografada = new(dto?.Senha ?? string.Empty);
            String Login = dto?.Login ?? string.Empty;

            var usuario = _RepositoryUsuario.ListarPor(x => x.Email.Endereco == Login && x.Senha.Valor == senhacriptografada.Valor).FirstOrDefault();

            if (usuario == null)
            {
                AddMensagem(Mensagem.Error("Dados incorretos."));

                return String.Empty;
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

                return token;
            }

            return string.Empty;
        }
    }
}
