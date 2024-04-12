using projetox.Domain.Base.DTO.Arguments;

namespace projetox.Domain.Core.DTO.Arguments
{
    /// <summary>
    /// Resultado da consulta de natureza juridica.
    /// </summary>
    public class ListarNaturezaJuridicoResponseDTO : ResponseBaseDTO
    {
        /// <summary>
        /// Listagem de naturezas juridicas.
        /// </summary>
        public List<NaturezaJuridicaDTO> NaturezaJuridicas { get; set; } = [];
    }
}
