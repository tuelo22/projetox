using projetox.Domain.Base.DTO.Arguments;

namespace projetox.Domain.Core.DTO.Arguments
{
    /// <summary>
    /// Resultado da consulta de segmento de cliente.
    /// </summary>
    public class ListarSegmentoClienteResponseDTO : ResponseBaseDTO
    {
        /// <summary>
        /// Listagem de empresas.
        /// </summary>
        public List<SegmentoClienteDTO> SegmentosClientes { get; set; } = [];
    }
}
