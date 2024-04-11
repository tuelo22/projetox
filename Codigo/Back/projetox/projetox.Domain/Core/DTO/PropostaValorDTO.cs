using projetox.Domain.Core.Entidades;
using System.ComponentModel.DataAnnotations;

namespace projetox.Domain.Core.DTO
{
    /// <summary>
    /// Proposta de valor
    /// </summary>
    public struct PropostaValorDTO
    {
        /// <summary>
        /// Identificador.
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Descrição do negócio
        /// </summary>
        [Required]
        public String DescricaoNegocio { get; set; }
        /// <summary>
        /// Descrição do cmapo fazer negócio.
        /// </summary>
        [Required]
        public String FazerNegocio { get; set; }
        /// <summary>
        /// Identificador da empresa.
        /// </summary>
        [Required]
        public Guid EmpresaId { get; set; }
        /// <summary>
        /// Listagem dos canais de distribuição.
        /// </summary>
        [Required]
        public List<CanalDistribuicaoOpcaoDTO> CanaisDistribuicaoOpcao { get; set; }
        /// <summary>
        /// Relacionamento com clientes.
        /// </summary>
        [Required]
        public List<RelacionamentoClienteDTO> RelacionamentoClientes { get; set; }
        /// <summary>
        /// Descrição das formas de receita.
        /// </summary>
        [Required]
        public List<FonteReceitaDTO> FontesReceita { get; set; }
        /// <summary>
        /// Conversão da classe concreta para o DTO.
        /// </summary>
        /// <param name="entidade"></param>
        public static explicit operator PropostaValorDTO(PropostaValor entidade)
        {
            return new PropostaValorDTO()
            {
                Id = entidade.Id,
                DescricaoNegocio = entidade.DescricaoNegocio,
                FazerNegocio = entidade.FazerNegocio,
                EmpresaId = entidade.Empresa.Id,
                CanaisDistribuicaoOpcao = entidade.CanalDistribuicaoOpcoes.Select(x => (CanalDistribuicaoOpcaoDTO)x).ToList(),
                RelacionamentoClientes = entidade.RelacionamentoClientes.Select(x => (RelacionamentoClienteDTO)x).ToList(),
                FontesReceita = entidade.FontesReceita.Select(x => (FonteReceitaDTO)x).ToList(),
            };
        }
    }
}
