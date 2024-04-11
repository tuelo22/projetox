using projetox.Domain.Base.DTO.Arguments;

namespace projetox.Domain.Core.DTO.Arguments
{
    /// <summary>
    /// Resultado da consulta de proposta de valores.
    /// </summary>
    public class ListarPropostaValorResponseDTO : ResponseBaseDTO
    {
        /// <summary>
        /// Listagem de propostas de valor.
        /// </summary>
        public List<PropostaValorDTO> PropostasValor { get; set; } = [];
    }
}
