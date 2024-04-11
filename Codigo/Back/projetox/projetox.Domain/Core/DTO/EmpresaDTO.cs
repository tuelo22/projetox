using projetox.Domain.Core.Entidades;
using System.ComponentModel.DataAnnotations;

namespace projetox.Domain.Core.DTO
{
    /// <summary>
    /// Empresa
    /// </summary>
    public struct EmpresaDTO
    {
        /// <summary>
        /// Identificador. 
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Documento;
        /// </summary>
        [Required]
        public string Documento { get; set; }
        /// <summary>
        /// Identificador da natureza juridica.
        /// </summary>
        [Required]
        public Guid NaturezaJuridicaId { get; set; }
        /// <summary>
        /// Descrição da natureza juridica.
        /// </summary>
        public string DescricaoNaturezaJuridica { get; set; }
        /// <summary>
        /// Data de abertura da empresa
        /// </summary>
        [Required]
        public DateTime Abertura { get; set; }
        /// <summary>
        /// Quantidade de funcionarios.
        /// </summary>
        [Required]
        public Int32 QuantidadeFuncionario { get; set; }
        /// <summary>
        /// Nome da empresa.
        /// </summary>
        [Required]
        public String Nome { get; set; }
        /// <summary>
        /// Telefone da empresa.
        /// </summary>
        [Required]
        public String Telefone { get; set; }
        /// <summary>
        /// URL do site ou webpage.
        /// </summary>
        [Required]
        public String? URLSite { get; set; }
        /// <summary>
        /// Objetivo da empresa.
        /// </summary>
        [Required]
        public String Objetivo { get; set; }
        /// <summary>
        /// Endereço.
        /// </summary>
        [Required]
        public EnderecoDTO Endereco { get; set; }
        /// <summary>
        /// Listagem de redes sociais.
        /// </summary>
        [Required]
        public List<RedeSocialDTO> RedesSociais { get; set; }
        /// <summary>
        /// Conversão da entidade principal par ao DTO.
        /// </summary>
        /// <param name="entidade"></param>
        public static explicit operator EmpresaDTO(Empresa entidade)
        {
            return new EmpresaDTO()
            {
                Id = entidade.Id,
                Documento = entidade.Documento.Numero,
                NaturezaJuridicaId = entidade.NaturezaJuridica.Id,
                DescricaoNaturezaJuridica = entidade.NaturezaJuridica.Descricao,
                Abertura = entidade.Abertura,
                QuantidadeFuncionario = entidade.QuantidadeFuncionario,
                Nome = entidade.Nome,
                Telefone = entidade.Telefone.Numero,
                URLSite = entidade.URLSite,
                Objetivo = entidade.Objetivo,
                Endereco = (EnderecoDTO)entidade.Endereco,
                RedesSociais = entidade.RedesSociais.Select(e => (RedeSocialDTO)e).ToList()
            };
        }
    }
}
