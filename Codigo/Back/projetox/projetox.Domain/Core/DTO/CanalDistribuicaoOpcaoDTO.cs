using projetox.Domain.Core.Entidades;
using System.ComponentModel.DataAnnotations;

namespace projetox.Domain.Core.DTO
{
    /// <summary>
    /// Opção do canal de distribuição.
    /// </summary>
    public struct CanalDistribuicaoOpcaoDTO
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
        public static explicit operator CanalDistribuicaoOpcaoDTO(CanalDistribuicaoOpcao entidade)
        {
            return new CanalDistribuicaoOpcaoDTO()
            {
                Id = entidade.Id,
                Descricao = entidade.Descricao,
            };
        }
    }
}
