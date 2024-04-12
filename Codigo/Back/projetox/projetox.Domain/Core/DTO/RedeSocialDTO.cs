using projetox.Domain.Core.Entidades;
using System.ComponentModel.DataAnnotations;

namespace projetox.Domain.Core.DTO
{
    /// <summary>
    /// Rede social da empresa.
    /// </summary>
    public struct RedeSocialDTO
    {
        /// <summary>
        /// Identificador.
        /// </summary>
        public Guid? Id { get; set; }

        /// <summary>
        /// Nome da rede social.
        /// </summary>
        [Required]
        public string Nome { get; set; }

        /// <summary>
        /// URL do perfil na rede social.
        /// </summary>
        [Required]
        public string URLPerfil { get; set; }

        /// <summary>
        /// Conversão da classe concreta para o DTO.
        /// </summary>
        /// <param name="entidade"></param>
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
