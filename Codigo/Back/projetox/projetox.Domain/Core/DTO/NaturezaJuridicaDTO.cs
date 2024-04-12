using projetox.Domain.Core.Entidades;
using System.ComponentModel.DataAnnotations;

namespace projetox.Domain.Core.DTO
{
    /// <summary>
    /// Natureza jurídica.
    /// </summary>
    public struct NaturezaJuridicaDTO
    {
        /// <summary>
        /// Identificador. 
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Descrição.
        /// </summary>
        [Required]
        public String Descricao { get; set; }

        /// <summary>
        /// Conversão da entidade principal par ao DTO.
        /// </summary>
        /// <param name="entidade"></param>
        public static explicit operator NaturezaJuridicaDTO(NaturezaJuridica entidade)
        {
            return new NaturezaJuridicaDTO()
            {
                Id = entidade.Id,
                Descricao = entidade.Descricao,
            };
        }
    }
}
