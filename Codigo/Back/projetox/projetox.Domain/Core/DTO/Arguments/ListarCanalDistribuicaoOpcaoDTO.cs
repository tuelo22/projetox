using projetox.Domain.Base.DTO.Arguments;

namespace projetox.Domain.Core.DTO.Arguments
{
    /// <summary>
    /// Resultado da consulta de canais de distribuição opção.
    /// </summary>
    public class ListarCanalDistribuicaoOpcaoDTO : ResponseBaseDTO
    {
        /// <summary>
        /// Listagem de canais de distribuição opção.
        /// </summary>
        public List<CanalDistribuicaoOpcaoDTO> CanaisDistribuicaoOpcao { get; set; } = [];
    }
}
