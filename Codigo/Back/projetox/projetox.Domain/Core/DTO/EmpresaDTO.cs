using projetox.Domain.Core.Entidades;

namespace projetox.Domain.Core.DTO
{
    public struct EmpresaDTO
    {
        public Guid Id { get; set; }
        public string Documento { get; set; }
        public Guid NaturezaJuridicaId { get; set; }
        public string DescricaoNaturezaJuridica { get; set; }
        public DateTime Abertura { get; set; }
        public Int32 QuantidadeFuncionario { get; set; }
        public String Nome { get; set; }
        public String Telefone { get; set; }
        public String? URLSite { get; set; }
        public EnderecoDTO Endereco { get; set; }
        public List<RedeSocialDTO> RedesSociais { get; set; }

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
                Endereco = (EnderecoDTO)entidade.Endereco,
                RedesSociais = entidade.RedesSociais.Select(e => (RedeSocialDTO)e).ToList()
            };
        }
    }
}
