using projetox.Domain.Core.Entidades;
using System.ComponentModel.DataAnnotations;

namespace projetox.Domain.Core.DTO
{
    /// <summary>
    /// Seguemnto de busca da empresa.
    /// </summary>
    public struct SegmentoBuscarEmpresaDTO
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
        public static explicit operator SegmentoBuscarEmpresaDTO(SegmentoBuscarEmpresa entidade)
        {
            return new SegmentoBuscarEmpresaDTO()
            {
                Id = entidade.Id,
                Descricao = entidade.Descricao,
            };
        }
    }
}
