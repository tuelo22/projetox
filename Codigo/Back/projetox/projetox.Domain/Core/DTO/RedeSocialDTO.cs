using projetox.Domain.Core.Entidades;

namespace projetox.Domain.Core.DTO
{
    public struct RedeSocialDTO
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string URLPerfil { get; set; }

        public static explicit operator RedeSocialDTO(RedeSocial entidade)
        {
            return new RedeSocialDTO()
            {
                Id = entidade.Id,
                Nome = entidade.Nome,
                URLPerfil = entidade.URLPerfil,
            };
        }
    }
}
