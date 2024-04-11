using projetox.Domain.Base.DTO.Arguments;

namespace projetox.Domain.Core.DTO.Arguments
{
    /// <summary>
    /// Resultado da consulta empresas.
    /// </summary>
    public class ListarEmpresaResponseDTO : ResponseBaseDTO
    {
        /// <summary>
        /// Listagem de empresas.
        /// </summary>
        public List<EmpresaDTO> Empresas { get; set; } = [];
    }
}
