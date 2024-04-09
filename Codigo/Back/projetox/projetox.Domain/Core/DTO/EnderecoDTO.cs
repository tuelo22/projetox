using projetox.Domain.Core.ValueObjects;

namespace projetox.Domain.Core.DTO
{
    public struct EnderecoDTO
    {
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string? Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string CEP { get; set; }
        public string CodIBGE { get; set; }

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
