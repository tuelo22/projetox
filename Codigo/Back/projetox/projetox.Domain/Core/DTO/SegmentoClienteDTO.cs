using projetox.Domain.Core.Entidades;
using System.ComponentModel.DataAnnotations;

namespace projetox.Domain.Core.DTO
{
    /// <summary>
    /// Segmento do cliente
    /// </summary>
    public struct SegmentoClienteDTO
    {
        /// <summary>
        /// Identificador.
        /// </summary>
        public Guid? Id { get; set; }
        /// <summary>
        /// Descrição do campo ajudar.
        /// </summary>
        [Required]
        public String Ajudar { get; set; }
        /// <summary>
        /// Descrição do campo buscar produto.
        /// </summary>
        [Required]
        public String BuscarProduto { get; set; }
        /// <summary>
        /// Descrição do campo servindo pessoa
        /// </summary>
        [Required]
        public String ServindoPessoa { get; set; }
        /// <summary>
        /// Valores aceitose = (Sim, Nao, Pesquisar)
        /// </summary>
        [Required]
        public string ClienteDispostoPagar { get; set; }
        /// <summary>
        /// Valor do seguimento.
        /// </summary>
        [Required]
        public decimal Valor { get; set; }
        /// <summary>
        /// Identificador da proposta de valor.
        /// </summary>
        [Required]
        public Guid PropostaValorId { get; set; }
        /// <summary>
        /// Lista de segmentos buscar empresas.
        /// </summary>
        [Required]
        public List<SegmentoBuscarEmpresaDTO> SegmentoBuscarEmpresas { get; set; }
        /// <summary>
        /// Lista de segumentos de relamação de atendimento.
        /// </summary>
        [Required]
        public List<SegmentoReclamacaoAtendimentoDTO> SegmentoReclamacaoAtendimentos { get; set; }
        /// <summary>
        /// Segmento de ajudar pessoas.
        /// </summary>
        [Required]
        public List<SegmentoAjudarPessoaDTO> SegmentoAjudarPessoas { get; set; }
        /// <summary>
        /// Conversão da classe concreta para o DTO.
        /// </summary>
        /// <param name="entidade"></param>
        public static explicit operator SegmentoClienteDTO(SegmentoCliente entidade)
        {
            return new SegmentoClienteDTO()
            {
                Id = entidade.Id,
                Ajudar = entidade.Ajudar,
                BuscarProduto = entidade.BuscarProduto,
                ServindoPessoa = entidade.ServindoPessoa,
                ClienteDispostoPagar = entidade.ClienteDispostoPagar.ToString(),
                Valor = entidade.Valor,
                PropostaValorId = entidade.PropostaValor.Id,
                SegmentoBuscarEmpresas = entidade.SegmentoBuscarEmpresas.Select(x => (SegmentoBuscarEmpresaDTO)x).ToList(),
                SegmentoReclamacaoAtendimentos = entidade.SegmentoReclamacaoAtendimentos.Select(x => (SegmentoReclamacaoAtendimentoDTO)x).ToList(),
                SegmentoAjudarPessoas = entidade.SegmentoAjudarPessoas.Select(x => (SegmentoAjudarPessoaDTO)x).ToList(),
            };
        }
    }
}
