using projetox.Domain.Core.Entidades;
using System.ComponentModel.DataAnnotations;

namespace projetox.Domain.Core.DTO
{
    /// <summary>
    /// Tipos de relacionamento com o cliente.
    /// </summary>
    public struct RelacionamentoClienteDTO
    {
        /// <summary>
        /// Identificador.
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Descrição
        /// </summary>
        [Required]
        public String Descricao { get; set; }
        /// <summary>
        /// Conversão da classe concreta para o DTO.
        /// </summary>
        /// <param name="entidade"></param>
        public static explicit operator RelacionamentoClienteDTO(RelacionamentoCliente entidade)
        {
            return new RelacionamentoClienteDTO()
            {
                Id = entidade.Id,
                Descricao = entidade.Descricao,
            };
        }
    }
}
