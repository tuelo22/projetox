using projetox.Domain.Core.Entidades;
using System.ComponentModel.DataAnnotations;

namespace projetox.Domain.Core.DTO
{
    /// <summary>
    /// Fonte de receita da empresa.
    /// </summary>
    public struct FonteReceitaDTO
    {
        /// <summary>
        /// Identificador.
        /// </summary>
        public Guid? Id { get; set; }
        /// <summary>
        /// Descrição
        /// </summary>
        [Required]
        public String Descricao { get; set; }
        /// <summary>
        /// Conversão da classe concreta para o DTO.
        /// </summary>
        /// <param name="entidade"></param>
        public static explicit operator FonteReceitaDTO(FonteReceita entidade)
        {
            return new FonteReceitaDTO()
            {
                Id = entidade.Id,
                Descricao = entidade.Descricao,
            };
        }
    }
}
