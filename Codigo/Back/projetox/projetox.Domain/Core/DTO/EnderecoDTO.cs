using projetox.Domain.Core.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace projetox.Domain.Core.DTO
{
    /// <summary>
    /// Endereço
    /// </summary>
    public struct EnderecoDTO
    {
        /// <summary>
        /// Logradouro ou rua
        /// </summary>
        [Required]
        public string Logradouro { get; set; }
        /// <summary>
        /// Numero
        /// </summary>
        [Required]
        public string Numero { get; set; }
        /// <summary>
        /// Complemento.
        /// </summary>
        public string? Complemento { get; set; }
        /// <summary>
        /// Bairro
        /// </summary>
        [Required]
        public string Bairro { get; set; }
        /// <summary>
        /// Cidade
        /// </summary>
        [Required]
        public string Cidade { get; set; }
        /// <summary>
        /// Estado
        /// </summary>
        [Required]
        public string Estado { get; set; }
        /// <summary>
        /// CEP
        /// </summary>
        [Required]
        public string CEP { get; set; }
        /// <summary>
        /// Código do municipio no IBGE.
        /// </summary>
        [Required]
        public string CodIBGE { get; set; }

        /// <summary>
        /// Conversão da classe concreta para o DTO.
        /// </summary>
        /// <param name="entidade"></param>
        public static explicit operator EnderecoDTO(Endereco entidade)
        {
            return new EnderecoDTO()
            {
                Logradouro = entidade.Logradouro,
                Numero = entidade.Numero,
                Complemento = entidade.Complemento,
                Bairro = entidade.Bairro,
                Cidade = entidade.Cidade,
                Estado = entidade.Estado,
                CEP = entidade.CEP,
                CodIBGE = entidade.CodIBGE,
            };
        }
    }
}
