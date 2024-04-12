using projetox.Domain.Base.DTO.Arguments;

namespace projetox.Domain.Autenticacao.DTO
{
    public class TokenDTO : ResponseBaseDTO
    {
        public string? Token { get; set; }
    }
}
