using projetox.Domain.Core.Entidades;
using System.ComponentModel.DataAnnotations;

namespace projetox.Domain.Core.DTO
{
    /// <summary>
    /// Segmento de reclamação de atendimentos
    /// </summary>
    public struct SegmentoReclamacaoAtendimentoDTO
    {
        /// <summary>
        /// Identificador.
        /// </summary>
        public Guid? Id { get; set; }
        /// <summary>
        /// Descrição.
        /// </summary>
        [Required]
        public String Descricao { get; set; }
        /// <summary>
        /// Conversão da classe concreta para o DTO.
        /// </summary>
        /// <param name="entidade"></param>
        public static explicit operator SegmentoReclamacaoAtendimentoDTO(SegmentoReclamacaoAtendimento entidade)
        {
            return new SegmentoReclamacaoAtendimentoDTO()
            {
                Id = entidade.Id,
                Descricao = entidade.Descricao,
            };
        }
    }
}
