using projetox.Domain.Core.Entidades;
using System.ComponentModel.DataAnnotations;

namespace projetox.Domain.Core.DTO
{
    /// <summary>
    /// Segmento ajudar pessoas
    /// </summary>
    public struct SegmentoAjudarPessoaDTO
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
        public static explicit operator SegmentoAjudarPessoaDTO(SegmentoAjudarPessoa entidade)
        {
            return new SegmentoAjudarPessoaDTO()
            {
                Id = entidade.Id,
                Descricao = entidade.Descricao,
            };
        }
    }
}
