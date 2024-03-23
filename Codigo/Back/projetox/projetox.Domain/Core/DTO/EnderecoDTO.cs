﻿namespace projetox.Domain.Core.DTO
{
    public class EnderecoDTO
    {
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string? Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string CEP { get; set; }
        public string CodIBGE { get; set; }
    }
}
