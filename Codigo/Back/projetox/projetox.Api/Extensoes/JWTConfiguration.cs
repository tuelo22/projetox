using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace projetox.Api.Extensoes
{
    public static class JWTConfiguration
    {
        public const string AccessKey = "CgP7NyLXtaGmyOgjj3sUMwmAlrSKqa5JyZ4P1OlfQeM";
        public const string SecretKey = "UTboSKRUb13ZmztLtyB0W4BN37ndx_aK8__ry9sxfv8";
        public const string ApplicationName = "ApplicationTests";
        public const string ClientId = "e84a2d13704647d18277966ec839d39e";
        public const string Issuer = "http://localhost";

        public static void AddJWTConfiguration(this IServiceCollection services)
        {
            // Configuração do JWT
            var key = Encoding.ASCII.GetBytes(SecretKey); // Substitua pela sua chave secreta
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = Issuer,
                        ValidateAudience = true,
                        ValidAudience = ClientId,
                        ValidateLifetime = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key)
                    };
                });
        }

        public static string GenerateJwtToken(string username)
        {
            var key = Encoding.ASCII.GetBytes(SecretKey);
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, username)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
